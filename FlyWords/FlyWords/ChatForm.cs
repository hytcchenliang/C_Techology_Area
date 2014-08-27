using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace FlyWords
{
    public partial class ChatForm : Form
    {
        public ChatForm()
        {
            InitializeComponent();
        }
        
        private void ChatForm_Load(object sender, EventArgs e)
        {

        }
        private MainForm fm1;//MainForm类型的容器

        public MainForm Fm1
        {
            get { return fm1; }
            set { fm1 = value; }
        }
        private friend curfriend1;//friend类型的容器，curfriend1就有了friend的所有属性

        public friend Curfriend
        {   
            get { return curfriend1; }
            set { 
                curfriend1 = value;//把哪种类型的值付给容器，容器就有哪种类型值的属性
                this.chatname.Text = value.NickName;
                this.chatpic.Image = this.fm1.HeadImgs.Images[value.headImg];
                this.chatshuo.Text = value.shuoshuo;
             }
        }
        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.curfriend1.isopen = false;
        }

        private void sendbtn_Click(object sender, EventArgs e)
        {
            UdpClient uc = new UdpClient();
            string msg = "PUBLIC|"+this.teboxmsg.Text;
            byte[] bmsg = Encoding.Default.GetBytes(msg);
            string IP = "255.255.255.255";
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP),9527);
            string[] str = msg.Split('|');
            uc.Send(bmsg,bmsg.Length,iep);
            this.chathistory.AppendText("hollis : "+str[1]+"\r\n");
        }

    }
}
