using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Messaging;
using System.Messaging.Design;
using System.Windows.Forms;

namespace RisLab1
{
    class QueueMessageSender
    {
        private MessageQueue _q;
        private const string QueuePath = @".\private$\ServerQueue";

        private void ConnectToQueue(string queuePath)
        {
            if (MessageQueue.Exists(queuePath))
            {
                // если очередь, путь к которой указан в поле tbPath существует, то открываем ее
                _q = new MessageQueue(queuePath);
            }
            else
                MessageBox.Show("Указан неверный путь к очереди, либо очередь не существует");
        }

        public void SendMessage(List<DbEntry> dbEntries)
        {
            ConnectToQueue(QueuePath);
            _q.Send(dbEntries, Dns.GetHostName());
        }
    }
}
