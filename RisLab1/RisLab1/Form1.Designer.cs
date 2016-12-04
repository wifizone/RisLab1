namespace RisLab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSendQueue = new System.Windows.Forms.Button();
            this.sendSocketBtn = new System.Windows.Forms.Button();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSendQueue
            // 
            this.buttonSendQueue.Location = new System.Drawing.Point(54, 12);
            this.buttonSendQueue.Name = "buttonSendQueue";
            this.buttonSendQueue.Size = new System.Drawing.Size(174, 23);
            this.buttonSendQueue.TabIndex = 0;
            this.buttonSendQueue.Text = "Отправить в очередь";
            this.buttonSendQueue.UseVisualStyleBackColor = true;
            this.buttonSendQueue.Click += new System.EventHandler(this.button1_Click);
            // 
            // sendSocketBtn
            // 
            this.sendSocketBtn.Location = new System.Drawing.Point(54, 120);
            this.sendSocketBtn.Name = "sendSocketBtn";
            this.sendSocketBtn.Size = new System.Drawing.Size(174, 23);
            this.sendSocketBtn.TabIndex = 1;
            this.sendSocketBtn.Text = "Отправить socket";
            this.sendSocketBtn.UseVisualStyleBackColor = true;
            this.sendSocketBtn.Click += new System.EventHandler(this.buttonSendSocket_Click);
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(97, 50);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(100, 20);
            this.ipTextBox.TabIndex = 2;
            this.ipTextBox.TextChanged += new System.EventHandler(this.ipTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP:";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(54, 91);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(174, 23);
            this.connectBtn.TabIndex = 4;
            this.connectBtn.Text = "Соединиться";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 160);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.sendSocketBtn);
            this.Controls.Add(this.buttonSendQueue);
            this.Name = "Form1";
            this.Text = "Лабораторная 1 клиент";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSendQueue;
        private System.Windows.Forms.Button sendSocketBtn;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectBtn;
    }
}

