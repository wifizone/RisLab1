using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RisLab1;
using SendMediator;

namespace RisLab1Server
{
    public partial class Form1 : Form
    {
        private Socket ClientSock;                      // клиентский сокет
        private TcpListener Listener;                   // сокет сервера
        private List<Thread> Threads = new List<Thread>();      // список потоков приложения (кроме родительского)
        private bool _continue = true;                          // флаг, указывающий продолжается ли работа с сокетами

        private QueueMessageReceiver queueMessageReceiver;

        public Form1()
        {
            InitializeComponent();

            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());    // информация об IP-адресах и имени машины, на которой запущено приложение
            IPAddress IP = hostEntry.AddressList[0];                        // IP-адрес, который будет указан при создании сокета
            int Port = 1010;                                                // порт, который будет указан при создании сокета

            // определяем IP-адрес машины в формате IPv4
            foreach (IPAddress address in hostEntry.AddressList)
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP = address;
                    break;
                }

            // вывод IP-адреса машины и номера порта в заголовок формы, чтобы можно было его использовать для ввода имени в форме клиента, запущенного на другом вычислительном узле
            this.Text += "     " + IP.ToString() + "  :  " + Port.ToString();

            // создаем серверный сокет (Listener для приема заявок от клиентских сокетов)
            Listener = new TcpListener(IP, Port);
            Listener.Start();

            // создаем и запускаем поток, выполняющий обслуживание серверного сокета
            Threads.Clear();
            Threads.Add(new Thread(ReceiveMessage));
            Threads[Threads.Count - 1].Start();
        }

        // работа с клиентскими сокетами
        private void ReceiveMessage()
        {
            // входим в бесконечный цикл для работы с клиентскими сокетом
            while (_continue)
            {
                ClientSock = Listener.AcceptSocket();           // получаем ссылку на очередной клиентский сокет
                Threads.Add(new Thread(ReadMessages));          // создаем и запускаем поток, обслуживающий конкретный клиентский сокет
                Threads[Threads.Count - 1].Start(ClientSock);
            }
        }

        private void ReadMessages(object ClientSock)
        {
            SocketMessage msg;        // полученное сообщение

            // входим в бесконечный цикл для работы с клиентским сокетом
            while (_continue)
            {
                byte[] buff = new byte[1024];                           // буфер прочитанных из сокета байтов
                ((Socket)ClientSock).Receive(buff);                     // получаем последовательность байтов из сокета в буфер buff
                msg = (SocketMessage)Serializer.ByteArrayToObject(buff);     // выполняем преобразование байтов в последовательность символов

                notificationRichTextBox.Invoke((MethodInvoker)delegate
                {
                    if (msg != null)
                        notificationRichTextBox.Text += "Сообщение по сокету получено " + msg + " \n";             // выводим полученное сообщение на форму
                });

                DbInserter.InsertToDb((List<DbEntry>)msg.DbEntries);

                Thread.Sleep(500);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            queueMessageReceiver = new QueueMessageReceiver(this);
            Text += "  " + queueMessageReceiver.GetQueuePath();


        }


        private void notificationRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (queueMessageReceiver != null)
            {
                queueMessageReceiver.ReceivingThread.Abort();
            }

            _continue = false;      // сообщаем, что работа с сокетами завершена

            // завершаем все потоки
            foreach (Thread t in Threads)
            {
                t.Abort();
                t.Join(500);
            }

            // закрываем клиентский сокет
            if (ClientSock != null)
                ClientSock.Close();

            // приостанавливаем "прослушивание" серверного сокета
            if (Listener != null)
                Listener.Stop();
        }
    }
}
