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
using System.Threading;

namespace FlyWords
{
    public partial class MainForm : Form
    {
        public delegate void deAddFriend(friend friend);
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void Main_Load(object sender, EventArgs e)
        {
            sendmsg();
            MainForm.CheckForIllegalCrossThreadCalls = false;
            Thread th = new Thread(new ThreadStart(listen));
            Thread.Sleep(100);
            th.IsBackground = true;
            th.Start();
            
        }    
         private void sendmsg(){
            UdpClient uc=new UdpClient();
            string IP = "255.255.255.255";
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(IP),9527);
            string message="";
            message = "LOGIN|" + this.labNickName.Text + "|2|我来了";
            byte[] bmsg=Encoding.Default.GetBytes(message);
            uc.Send(bmsg,bmsg.Length,ipep);
         }
         public void addUcf(friend f) {
             UCFriend ucf = new UCFriend();
             ucf.Frm = this;
             ucf.Curfriend = f;
             ucf.Top = this.paFriendList.Controls.Count * ucf.Height;
             this.paFriendList.Controls.Add(ucf);
         }

         private void listen() {
             UdpClient uc = new UdpClient(9527);
             
             while(true){
                 IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
                 byte[] Gotmsg = uc.Receive(ref ipep);
                 string SGotmsg = Encoding.Default.GetString(Gotmsg);
                 string[] stron = SGotmsg.Split('|');
                 if (stron.Length != 4)
                 {
                     continue;
                 }
                 if (stron[0] == "LOGIN")
                 {
                     
                     friend friend = new friend();
                     int cuImg= Convert.ToInt32(stron[2]);
                     if(cuImg<0||cuImg>=this.HeadImgs.Images.Count){
                         cuImg = 0;
                     }
                     friend.headImg = cuImg;
                     friend.NickName=stron[1];
                     friend.shuoshuo = stron[3];

                     object[] pars = new object[1];
                     pars[0] = friend;
                     this.Invoke(new deAddFriend(this.addUcf),pars[0]);
                 }
             }
         }

         private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
         {
             Application.Exit();
         } 

    }
}
