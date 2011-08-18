using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Landlord2.Data;
using ComponentFactory.Krypton.Toolkit;

namespace Landlord2.UI
{
    public partial class UC源房详细 : Landlord2.UI.UCBase
    {
        //private 源房 yf;
        public UC源房详细()
        {
            InitializeComponent();
        }

        //public UC源房详细(源房 yf)
        //{
        //    InitializeComponent();
        //    this.yf = yf;
        //    源房BindingSource.DataSource = yf;
            
        //}

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg文件 (*.jpg)|*.jpg|bmp文件 (*.bmp)|*.bmp|png文件 (*.png)|*.png|所有文件 (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                Image img = Image.FromFile(ofd.FileName);
                if (sender == btnOpenFile1)
                {
                    租赁协议照片1PictureBox.Image = img;
                }
                else if (sender == btnOpenFile2)
                {
                    租赁协议照片2PictureBox.Image = img;
                }
                else if (sender == btnOpenFile3)
                {
                    租赁协议照片3PictureBox.Image = img;
                }
            }
            catch (Exception)
            {
                
                 KryptonMessageBox.Show("加载图像出错！");
            }
        }

        private PictureBox tempPicBox;
        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pbox = sender as PictureBox;
            if (pbox.Image == null)
                return;

            if (tempPicBox == null)
                tempPicBox = new PictureBox();
            //tempPicBox.Size = 
            
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
