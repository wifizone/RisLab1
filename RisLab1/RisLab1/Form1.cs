﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RisLab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QueueMessageSender queueMessager = new QueueMessageSender();
            queueMessager.SendMessage(new CsvParser().GetDbEntries());
        }

        private void buttonSendSocket_Click(object sender, EventArgs e)
        {

        }
    }
}
