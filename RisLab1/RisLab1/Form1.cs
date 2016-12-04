using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendMediator;

namespace RisLab1
{
    public partial class Form1 : Form
    {
        private TcpClient Client = new TcpClient();     // клиентский сокет
        private IPAddress IP;                           // IP-адрес клиента

        public Form1()
        {
            InitializeComponent();

            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());    // информация об IP-адресах и имени машины, на которой запущено приложение
            IP = hostEntry.AddressList[0];                                  // IP-адрес, который будет указан в заголовке окна для идентификации клиента

            // определяем IP-адрес машины в формате IPv4
            foreach (IPAddress address in hostEntry.AddressList)
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP = address;
                    break;
                }

            Text += "     " + IP.ToString();                           // выводим IP-адрес текущей машины в заголовок формы
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QueueMessageSender queueMessager = new QueueMessageSender();
            queueMessager.SendMessage(new CsvParser().GetDbEntries());
        }

        private void buttonSendSocket_Click(object sender, EventArgs e)
        {
            CsvParser parser = new CsvParser();
            byte[] buff = Serializer.ObjectToByteArray(parser.GetSocketMessage(IP.ToString()));   // выполняем преобразование сообщения (вместе с идентификатором машины) в последовательность байт
            Stream stm = Client.GetStream();                                                    // получаем файловый поток клиентского сокета
            stm.Write(buff, 0, buff.Length);                                                    // выполняем запись последовательности байт
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int Port = 1010;                                // номер порта, через который выполняется обмен сообщениями
                IPAddress IP = IPAddress.Parse(ipTextBox.Text);      // разбор IP-адреса сервера, указанного в поле tbIP
                Client.Connect(IP, Port);                       // подключение к серверному сокету
                connectBtn.Enabled = false;
                sendSocketBtn.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Введен некорректный IP-адрес");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Client.Close();
        }

        private void ipTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
