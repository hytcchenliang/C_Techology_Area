namespace FlyWords
{
    partial class ChatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chathistory = new System.Windows.Forms.TextBox();
            this.teboxmsg = new System.Windows.Forms.TextBox();
            this.sendbtn = new System.Windows.Forms.Button();
            this.chatname = new System.Windows.Forms.Label();
            this.chatpic = new System.Windows.Forms.PictureBox();
            this.chatshuo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chatpic)).BeginInit();
            this.SuspendLayout();
            // 
            // chathistory
            // 
            this.chathistory.Location = new System.Drawing.Point(3, 81);
            this.chathistory.Multiline = true;
            this.chathistory.Name = "chathistory";
            this.chathistory.Size = new System.Drawing.Size(504, 230);
            this.chathistory.TabIndex = 0;
            // 
            // teboxmsg
            // 
            this.teboxmsg.Location = new System.Drawing.Point(3, 327);
            this.teboxmsg.Multiline = true;
            this.teboxmsg.Name = "teboxmsg";
            this.teboxmsg.Size = new System.Drawing.Size(504, 35);
            this.teboxmsg.TabIndex = 1;
            // 
            // sendbtn
            // 
            this.sendbtn.Location = new System.Drawing.Point(427, 378);
            this.sendbtn.Name = "sendbtn";
            this.sendbtn.Size = new System.Drawing.Size(75, 23);
            this.sendbtn.TabIndex = 2;
            this.sendbtn.Text = "发送";
            this.sendbtn.UseVisualStyleBackColor = true;
            this.sendbtn.Click += new System.EventHandler(this.sendbtn_Click);
            // 
            // chatname
            // 
            this.chatname.AutoSize = true;
            this.chatname.Location = new System.Drawing.Point(105, 16);
            this.chatname.Name = "chatname";
            this.chatname.Size = new System.Drawing.Size(29, 12);
            this.chatname.TabIndex = 3;
            this.chatname.Text = "name";
            // 
            // chatpic
            // 
            this.chatpic.Location = new System.Drawing.Point(3, 12);
            this.chatpic.Name = "chatpic";
            this.chatpic.Size = new System.Drawing.Size(60, 60);
            this.chatpic.TabIndex = 4;
            this.chatpic.TabStop = false;
            // 
            // chatshuo
            // 
            this.chatshuo.AutoSize = true;
            this.chatshuo.Location = new System.Drawing.Point(105, 48);
            this.chatshuo.Name = "chatshuo";
            this.chatshuo.Size = new System.Drawing.Size(53, 12);
            this.chatshuo.TabIndex = 5;
            this.chatshuo.Text = "shuoshuo";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 413);
            this.Controls.Add(this.chatshuo);
            this.Controls.Add(this.chatpic);
            this.Controls.Add(this.chatname);
            this.Controls.Add(this.sendbtn);
            this.Controls.Add(this.teboxmsg);
            this.Controls.Add(this.chathistory);
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.Load += new System.EventHandler(this.ChatForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chatpic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox chathistory;
        private System.Windows.Forms.TextBox teboxmsg;
        private System.Windows.Forms.Button sendbtn;
        private System.Windows.Forms.Label chatname;
        private System.Windows.Forms.PictureBox chatpic;
        private System.Windows.Forms.Label chatshuo;
    }
}