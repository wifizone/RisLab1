using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RisLab1;

namespace RisLab1Server
{
    class QueueMessageReceiver
    {
        private const string QueuePath = @"\private$\ServerQueue";
        private MessageQueue q = null;          // очередь сообщений
        public Thread ReceivingThread { get; set; } Thread t = null;                // поток, отвечающий за работу с очередью сообщений
        private bool _continue = true;          // флаг, указывающий продолжается ли работа с мэйлслотом
        public Form1 MyForm1 { get; set; }

        public QueueMessageReceiver(Form1 form1)
        {
            string path = Dns.GetHostName() + QueuePath;    // путь к очереди сообщений, Dns.GetHostName() - метод, возвращающий имя текущей машины

            // если очередь сообщений с указанным путем существует, то открываем ее, иначе создаем новую
            q = MessageQueue.Exists(path) ? new MessageQueue(path) : MessageQueue.Create(path);

            // задаем форматтер сообщений в очереди
            q.Formatter = new XmlMessageFormatter(new Type[] { typeof(List<DbEntry>) });

            MyForm1 = form1;

            // создание потока, отвечающего за работу с очередью сообщений
            ReceivingThread = new Thread(ReceiveMessage);
            ReceivingThread.Start();

        }

        public void ReceiveMessage()
        {
            if (q == null)
                return;

            System.Messaging.Message msg = null;

            // входим в бесконечный цикл работы с очередью сообщений
            while (_continue)
            {
                if (q.Peek() != null)   // если в очереди есть сообщение, выполняем его чтение, интервал до следующей попытки чтения равен 10 секундам
                    msg = q.Receive(TimeSpan.FromSeconds(10.0));

                MyForm1.notificationRichTextBox.Invoke((MethodInvoker)delegate
                {
                    if (msg != null)
                        MyForm1.notificationRichTextBox.Text += "Сообщение от : " + msg.Label + " получено" + "\n";     // выводим полученное сообщение на форму
                });

                DbInserter.InsertToDb((List<DbEntry>)msg.Body);

                Thread.Sleep(500);          // приостанавливаем работу потока перед тем, как приcтупить к обслуживанию очередного клиента
            }
        }

        public string GetQueuePath() => q.Path;
    }
}
