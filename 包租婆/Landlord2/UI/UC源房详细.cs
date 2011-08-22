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
        private bool IsReadOnly = false;
        public UC源房详细()
        {
            InitializeComponent();
            Controls.Remove(toolStrip1);
        }
        public UC源房详细(bool isReadOnly)
        {
            InitializeComponent();
            IsReadOnly = isReadOnly;
        }

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

        private void buttonSpecAny阶梯水价_Click(object sender, EventArgs e)
        {
            源房 yf = 源房BindingSource.DataSource as 源房;
            阶梯水价Form form = new 阶梯水价Form(yf.阶梯水价);
            DialogResult dr = form.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                yf.阶梯水价 = form.ResultWaterValue;
            }
        }

        private void buttonSpecAny阶梯电价_Click(object sender, EventArgs e)
        {
            源房 yf = 源房BindingSource.DataSource as 源房;
            阶梯电价Form f = new 阶梯电价Form(yf.阶梯电价);
            DialogResult dr = f.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                yf.阶梯电价 = f.ResultElectricValue;
            }
        }

        #region 如果仅仅显示实体值而不需更改时，处理这2个事件，丢弃当前模型的更新值。
        private void UC源房详细_ParentChanged(object sender, EventArgs e)
        {

        }

        private void 源房BindingSource_DataSourceChanged(object sender, EventArgs e)
        {

        } 
        #endregion
    }
}
