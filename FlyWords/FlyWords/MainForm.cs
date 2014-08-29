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
        private ChatForm chatform;
        public Panel getfriendList(){
            return this.paFriendList;
        }
        public ChatForm Chatform
        {
            get { return chatform; }
            set { chatform = value; }
        }
        public List<friend> friendlist = new List<friend>();
        public List<UCFriend> ucfriendlist = new List<UCFriend>();
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
            sendmsg(1);
           
            
            
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
            byte[] bmsg=Encoding.Default.GetBytes(message);
            uc.Send(bmsg,bmsg.Length,ipep);
         }
         public void addUcf(friend f) {
             UCFriend ucf = new UCFriend();
             ucf.Frm = this;//此语句使Frm有this的属性（能使用HeadImages）
             ucf.Curfriend = f;   
             ucf.Top = this.paFriendList.Controls.Count * ucf.Height;
             this.paFriendList.Controls.Add(ucf);
             this.ucfriendlist.Add(ucf);
             ucf.timerjump.Enabled = true;
         }
         public IPAddress getmyIp()
         {
             IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
             foreach (IPAddress ip in ips)
             {
                 if (ip.AddressFamily == AddressFamily.InterNetwork)
                 {
                     return ip;
                 }
             }
             return null;
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
                     if (ipep.Address.ToString() == getmyIp().ToString())
                     {
                         continue;
                     }
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

                     UdpClient uc1 = new UdpClient();
                     string alsommsg = "ALSOON|"+ this.labNickName.Text + "|2|我来了";
                     byte[] balsommsg = Encoding.Default.GetBytes(alsommsg);
                     uc1.Send(balsommsg, balsommsg.Length, new IPEndPoint(ipep.Address, 9527));
                 }
                
                 //ChatForm chafrm = new ChatForm();

                 if (stron[0] == "MSG")
                 {
                     //chatform = chafrm;
                     foreach(friend item in friendlist)
                     {
                         if(item.IP.ToString()==ipep.Address.ToString())
                         {
                             item.fchat.chathistory.AppendText(stron[2]+"\r\n"+stron[1]+"\r\n");

                         }
                     }
                     Panel pacrefri = this.getfriendList();

                     foreach (UCFriend ufc1 in pacrefri.Controls)
                     {
                         if (ufc1.Curfriend.IP.ToString() == ipep.Address.ToString())
                         {
                           
                         }
                     }

                 }
                 
                 if(stron[0]=="ALSOON"){
                     if (ipep.Address.ToString() == getmyIp().ToString())
                     {
                         continue;
                     }
                     if (stron.Length != 4)
                     {
                         continue;
                     }
                     friend alsofriend = new friend();
                     int alsocuImg = Convert.ToInt32(stron[2]);
                     if (alsocuImg < 0 || alsocuImg >= this.HeadImgs.Images.Count)
                     {
                         alsocuImg = 0;
                     }
                     alsofriend.headImg = alsocuImg;
                     alsofriend.NickName = stron[1];
                     alsofriend.shuoshuo = stron[3];
                     alsofriend.IP = ipep.Address;
                     alsofriend.isopen = false;

                     object[] pars = new object[1];
                     pars[0] = alsofriend;
                     this.Invoke(new deAddFriend(addUcf), pars);
                 }
                 if (stron[0] == "LOGOUT")
                 {
                     Panel pacrefri = this.getfriendList();
                     int delenumber=0;
                     foreach(UCFriend ufc in pacrefri.Controls)
                     {
                         if(ufc.Curfriend.IP.ToString()==ipep.Address.ToString())
                         {
                             pacrefri.Controls.Remove(ufc);
                         }
                         delenumber++;
                     }
                     for (int i = delenumber; i < pacrefri.Controls.Count; i++)
                     {
                         pacrefri.Controls[i].Top=pacrefri.Controls[0].Height*i;
                     }
                 }
             }
         }

         private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
         {
             sendmsg(2);
             //th.Abort();
             Application.Exit();
         }
    }
}
