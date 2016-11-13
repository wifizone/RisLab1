using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RisLab1Server
{
    public partial class Form1 : Form
    {

        private Thread t = null;                // поток, отвечающий за работу с очередью сообщений
        private bool _continue = true;          // флаг, указывающий продолжается ли работа с мэйлслотом
        private QueueMessageReceiver queueMessageReceiver;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            queueMessageReceiver = new QueueMessageReceiver(this);
            this.Text += "  " + queueMessageReceiver.GetQueuePath();
        }


        private void notificationRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {


            queueMessageReceiver.ReceivingThread.Abort();
        }
    }
}
