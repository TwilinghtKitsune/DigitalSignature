namespace DigitalSignature
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Url_key = new TextBox();
            text_message = new TextBox();
            Signed = new Button();
            Check = new Button();
            Uploading_key = new Button();
            Url_message = new TextBox();
            Uploading_message = new Button();
            Save = new Button();
            Url_sign = new TextBox();
            Uploading_sign = new Button();
            New_Sign = new Button();
            SuspendLayout();
            // 
            // Url_key
            // 
            Url_key.Location = new Point(12, 20);
            Url_key.Name = "Url_key";
            Url_key.Size = new Size(236, 27);
            Url_key.TabIndex = 0;
            // 
            // text_message
            // 
            text_message.Location = new Point(10, 60);
            text_message.Multiline = true;
            text_message.Name = "text_message";
            text_message.Size = new Size(1244, 363);
            text_message.TabIndex = 1;
            // 
            // Signed
            // 
            Signed.Location = new Point(884, 429);
            Signed.Name = "Signed";
            Signed.Size = new Size(182, 42);
            Signed.TabIndex = 2;
            Signed.Text = "Подписать";
            Signed.UseVisualStyleBackColor = true;
            Signed.Click += Signed_Click;
            // 
            // Check
            // 
            Check.Location = new Point(1072, 429);
            Check.Name = "Check";
            Check.Size = new Size(182, 42);
            Check.TabIndex = 3;
            Check.Text = "Проверить";
            Check.UseVisualStyleBackColor = true;
            Check.Click += Check_Click;
            // 
            // Uploading_key
            // 
            Uploading_key.Location = new Point(254, 12);
            Uploading_key.Name = "Uploading_key";
            Uploading_key.Size = new Size(182, 42);
            Uploading_key.TabIndex = 4;
            Uploading_key.Text = "Загрузить ключ";
            Uploading_key.UseVisualStyleBackColor = true;
            Uploading_key.Click += Uploading_key_Click;
            // 
            // Url_message
            // 
            Url_message.Location = new Point(10, 437);
            Url_message.Name = "Url_message";
            Url_message.Size = new Size(236, 27);
            Url_message.TabIndex = 6;
            // 
            // Uploading_message
            // 
            Uploading_message.Location = new Point(252, 429);
            Uploading_message.Name = "Uploading_message";
            Uploading_message.Size = new Size(182, 42);
            Uploading_message.TabIndex = 7;
            Uploading_message.Text = "Загрузить сообщение";
            Uploading_message.UseVisualStyleBackColor = true;
            Uploading_message.Click += Uploading_message_Click;
            // 
            // Save
            // 
            Save.Location = new Point(1072, 12);
            Save.Name = "Save";
            Save.Size = new Size(182, 42);
            Save.TabIndex = 8;
            Save.Text = "Сохранить";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // Url_sign
            // 
            Url_sign.Location = new Point(462, 20);
            Url_sign.Name = "Url_sign";
            Url_sign.Size = new Size(236, 27);
            Url_sign.TabIndex = 9;
            // 
            // Uploading_sign
            // 
            Uploading_sign.Location = new Point(704, 12);
            Uploading_sign.Name = "Uploading_sign";
            Uploading_sign.Size = new Size(182, 42);
            Uploading_sign.TabIndex = 10;
            Uploading_sign.Text = "Загрузить подпись";
            Uploading_sign.UseVisualStyleBackColor = true;
            Uploading_sign.Click += Uploading_sign_Click;
            // 
            // New_Sign
            // 
            New_Sign.Location = new Point(677, 429);
            New_Sign.Name = "New_Sign";
            New_Sign.Size = new Size(201, 42);
            New_Sign.TabIndex = 11;
            New_Sign.Text = "Создать новую подпись";
            New_Sign.UseVisualStyleBackColor = true;
            New_Sign.Click += New_Sign_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 483);
            Controls.Add(New_Sign);
            Controls.Add(Uploading_sign);
            Controls.Add(Url_sign);
            Controls.Add(Save);
            Controls.Add(Uploading_message);
            Controls.Add(Url_message);
            Controls.Add(Uploading_key);
            Controls.Add(Check);
            Controls.Add(Signed);
            Controls.Add(text_message);
            Controls.Add(Url_key);
            Name = "Form1";
            Text = "ЭЦП";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Url_key;
        private TextBox text_message;
        private Button Signed;
        private Button Check;
        private Button Uploading_key;
        private TextBox Url_message;
        private Button Uploading_message;
        private Button Save;
        private TextBox Url_sign;
        private Button Uploading_sign;
        private Button New_Sign;
    }
}