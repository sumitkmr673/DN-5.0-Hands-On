namespace KafkaChatApp
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
            label1 = new Label();
            txtMessages = new RichTextBox();
            btnCancel = new Button();
            btnSend = new Button();
            txtMessageInput = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 372);
            label1.Name = "label1";
            label1.Size = new Size(223, 20);
            label1.TabIndex = 0;
            label1.Text = "Please Enter Your Message Here:";
            // 
            // txtMessages
            // 
            txtMessages.Location = new Point(12, 12);
            txtMessages.Name = "txtMessages";
            txtMessages.ReadOnly = true;
            txtMessages.Size = new Size(1357, 344);
            txtMessages.TabIndex = 1;
            txtMessages.Text = "";
            txtMessages.TextChanged += txtMessages_TextChanged;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(1275, 452);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += button1_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(1275, 404);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += button2_Click;
            // 
            // txtMessageInput
            // 
            txtMessageInput.Location = new Point(12, 404);
            txtMessageInput.Name = "txtMessageInput";
            txtMessageInput.Size = new Size(1245, 77);
            txtMessageInput.TabIndex = 4;
            txtMessageInput.Text = "";
            txtMessageInput.TextChanged += txtMessageInput_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1381, 493);
            Controls.Add(txtMessageInput);
            Controls.Add(btnSend);
            Controls.Add(btnCancel);
            Controls.Add(txtMessages);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox txtMessages;
        private Button btnCancel;
        private Button btnSend;
        private RichTextBox txtMessageInput;
    }
}
