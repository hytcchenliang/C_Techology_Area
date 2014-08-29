namespace FlyWords
{
    partial class UCFriend
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ucPicHeadImg = new System.Windows.Forms.PictureBox();
            this.uclabWName = new System.Windows.Forms.Label();
            this.ucLabshuo = new System.Windows.Forms.Label();
            this.timerjump = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ucPicHeadImg)).BeginInit();
            this.SuspendLayout();
            // 
            // ucPicHeadImg
            // 
            this.ucPicHeadImg.Image = global::FlyWords.Properties.Resources.Caitlyn_Square_0;
            this.ucPicHeadImg.Location = new System.Drawing.Point(0, 0);
            this.ucPicHeadImg.Name = "ucPicHeadImg";
            this.ucPicHeadImg.Size = new System.Drawing.Size(60, 60);
            this.ucPicHeadImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ucPicHeadImg.TabIndex = 1;
            this.ucPicHeadImg.TabStop = false;
            // 
            // uclabWName
            // 
            this.uclabWName.AutoSize = true;
            this.uclabWName.Location = new System.Drawing.Point(66, 10);
            this.uclabWName.Name = "uclabWName";
            this.uclabWName.Size = new System.Drawing.Size(29, 12);
            this.uclabWName.TabIndex = 2;
            this.uclabWName.Text = "枪手";
            // 
            // ucLabshuo
            // 
            this.ucLabshuo.AutoSize = true;
            this.ucLabshuo.Location = new System.Drawing.Point(66, 35);
            this.ucLabshuo.Name = "ucLabshuo";
            this.ucLabshuo.Size = new System.Drawing.Size(113, 12);
            this.ucLabshuo.TabIndex = 3;
            this.ucLabshuo.Text = "我是世界第一枪王。";
            // 
            // timerjump
            // 
            // 
            // UCFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucLabshuo);
            this.Controls.Add(this.uclabWName);
            this.Controls.Add(this.ucPicHeadImg);
            this.Name = "UCFriend";
            this.Size = new System.Drawing.Size(250, 65);
            this.Load += new System.EventHandler(this.UCFriend_Load);
            this.Click += new System.EventHandler(this.UCFriend_Click);
            ((System.ComponentModel.ISupportInitialize)(this.ucPicHeadImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ucPicHeadImg;
        private System.Windows.Forms.Label uclabWName;
        private System.Windows.Forms.Label ucLabshuo;
        public System.Windows.Forms.Timer timerjump;
    }
}
