using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Landlord2.Data;
using ComponentFactory.Krypton.Toolkit;
using System.Drawing.Drawing2D;
using System.IO;
using System.CodeDom.Compiler;

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

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            if (e.AssociatedControl is PictureBox)
            {
                Image img = ((PictureBox)e.AssociatedControl).Image;
                if (img != null)
                {
                    //开始绘制图像
                    e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                    e.Graphics.DrawImage(img, e.Bounds);

                    LinearGradientBrush linGrBrush = new LinearGradientBrush(
                                                   new Point(0, 10),
                                                   new Point(200, 10),
                                                   Color.FromArgb(255, 255, 0, 0),   // Opaque red
                                                   Color.FromArgb(255, 0, 0, 255));  // Opaque blue
                    Font f = new Font("宋体", 10, FontStyle.Bold);
                    e.Graphics.DrawString("双击打开图像", f, linGrBrush,2,2);
                    return;
                }
            }

            //其他控件，或PictureBox无图像时
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            if (e.AssociatedControl is PictureBox)
            {
                Image img = ((PictureBox)e.AssociatedControl).Image;
                if (img != null)
                {
                    //宽、高设定在240像素之内
                    int toolTipWidth, toolTipHeight;
                    if (img.Width <= 240 && img.Height <= 240)
                    {
                        toolTipWidth = img.Width;
                        toolTipHeight = img.Height;
                    }
                    else
                    {
                        if (img.Width > img.Height)
                        {
                            toolTipWidth = 240;
                            toolTipHeight = 240 * img.Height / img.Width;
                        }
                        else
                        {
                            toolTipHeight = 240;
                            toolTipWidth = 240 * img.Width / img.Height;
                        }
                    }
                    e.ToolTipSize = new Size(toolTipWidth, toolTipHeight); 
                }
            }
        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox picBox = sender as PictureBox;
            Image img = picBox.Image;
            if (img != null)
            {
                //使用默认设置初始化集合的默认构造函数。默认情况下，此临时文件集合将文件存储在默认临时目录中，并在生成和使用临时文件后将其删除。
                using (TempFileCollection tfc = new TempFileCollection())
                {
                    string fileName = tfc.AddExtension("jpg");
                    try
                    {
                        img.Save(fileName);
                        System.Diagnostics.Process.Start(fileName);
                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
