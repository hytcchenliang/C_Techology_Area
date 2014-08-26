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

        private friend curfriend;

        public friend Curfriend
        {
            get { return curfriend; }
            set { 
                curfriend = value;
                this.uclabWName.Text= value.NickName;
                this.ucLabshuo.Text = value.shuoshuo;
                this.ucPicHeadImg.Image = this.frm.HeadImgs.Images[value.headImg];
            }
        }
        public UCFriend()
        {
            InitializeComponent();
        }

        private void UCFriend_Load(object sender, EventArgs e)
        {

        }
    }
}
