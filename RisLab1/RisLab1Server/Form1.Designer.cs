namespace RisLab1Server
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
            this.notificationRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // notificationRichTextBox
            // 
            this.notificationRichTextBox.Location = new System.Drawing.Point(13, 13);
            this.notificationRichTextBox.Name = "notificationRichTextBox";
            this.notificationRichTextBox.Size = new System.Drawing.Size(259, 236);
            this.notificationRichTextBox.TabIndex = 0;
            this.notificationRichTextBox.Text = "";
            this.notificationRichTextBox.TextChanged += new System.EventHandler(this.notificationRichTextBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.notificationRichTextBox);
            this.Name = "Form1";
            this.Text = "Лабораторная 1 сервер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox notificationRichTextBox;
    }
}

