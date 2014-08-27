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
        
        private Thread th;
        private void Main_Load(object sender, EventArgs e)
        {
            MainForm.CheckForIllegalCrossThreadCalls = false;
            th = new Thread(new ThreadStart(listen));
            Thread.Sleep(100);
            th.IsBackground = true;
            th.Start();
           
            
            
        }    
         private void sendmsg( int kind){
            UdpClient uc=new UdpClient();
            string IP = "255.255.255.255";
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(IP),9527);
            string message="";
             if(kind==1){
                 message = "LOGIN|" + this.labNickName.Text + "|2|我来了";
             }
             if(kind==2){
                 message = "LOGOUT";
             }
             if(kind==3){
                 message = "PUBLIC";
             }
            byte[] bmsg=Encoding.Default.GetBytes(message);
            uc.Send(bmsg,bmsg.Length,ipep);
         }

         public void addUcf(friend f) {
             UCFriend ucf = new UCFriend();
             ucf.Frm = this;//此语句使Frm有this的属性（能使用HeadImages）
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
                
                 if (stron[0] == "LOGIN")
                 {
                     if (stron.Length != 4)
                     {
                         continue;
                     }
                     friend friend = new friend();
                     int cuImg= Convert.ToInt32(stron[2]);
                     if(cuImg<0||cuImg>=this.HeadImgs.Images.Count){
                         cuImg = 0;
                     }
                     friend.headImg = cuImg;
                     friend.NickName=stron[1];
                     friend.shuoshuo = stron[3];
                     friend.IP = ipep.Address;
                     friend.isopen = false;

                     object[] pars = new object[1];
                     pars[0] = friend;
                     this.Invoke(new deAddFriend(addUcf),pars);
                 }

             }
         }

         private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
         {
             
             //th.Abort();
             Application.Exit();
         }

         private void button1_Click(object sender, EventArgs e)
         {
             sendmsg(1);
         }

         private void button2_Click(object sender, EventArgs e)
         {
             sendmsg(2);
         }
    }
}
