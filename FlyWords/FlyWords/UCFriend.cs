using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlyWords
{
    public partial class UCFriend : UserControl
    {
        private MainForm frm;

        public MainForm Frm
        {
            get { return frm; }
            set { frm = value; }
        }

        private friend curfriend2;//定义friend类型的curfriend容器，它就有了friend的所有属性

        public friend Curfriend
        {   

            get { return curfriend2; }
            set { 
                curfriend2 = value;
                this.uclabWName.Text= value.NickName;
                this.ucLabshuo.Text = value.shuoshuo;
                this.ucPicHeadImg.Image = this.frm.HeadImgs.Images[value.headImg];
                this.Curfriend.isopen = false;
            }
        }
        public UCFriend()
        {
            InitializeComponent();
        }

        private void UCFriend_Load(object sender, EventArgs e)
        {
          
        }

        private void UCFriend_Click(object sender, EventArgs e)
        {
            if (this.curfriend2.isopen == false)
            {
                ChatForm chafrm = new ChatForm();
                chafrm.Show();
                this.curfriend2.isopen = true;
                chafrm.Fm1 = this.frm;//此语句使Fm1有frm的属性（能使用HeadImages）
                chafrm.Curfriend = this.curfriend2;
            }
        }
    }
}
