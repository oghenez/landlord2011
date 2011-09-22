using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.CodeDom.Compiler;
using System.Drawing.Drawing2D;
using System.IO;
using Landlord2.Data;
using System.Linq;
using System.Data.Objects;
using System.Data.Entity;

namespace Landlord2.UI
{
    public partial class UC客房详细 : Landlord2.UI.UCBase
    {
        private Landlord2Entities parentContext;
        private bool IsReadOnly = false;
        /// <summary>
        ///  此构造函数仅编辑器调用
        /// </summary>
        public UC客房详细()
        {
            InitializeComponent();
            Controls.Remove(toolStrip1);
            kryptonPanel1.Controls.Remove(kryptonDataGridView1);
            kryptonPanel1.Height -= kryptonDataGridView1.Height;
        }
        public UC客房详细(bool isReadOnly,Landlord2Entities context)
        {
            InitializeComponent();
            IsReadOnly = isReadOnly;
            parentContext = context;
        }

        private void UC客房详细_Load(object sender, EventArgs e)
        {          
            租赁协议照片1PictureBox.DataBindings["Image"].Format += new ConvertEventHandler(ByteArray2Image_Format);
            租赁协议照片2PictureBox.DataBindings["Image"].Format += new ConvertEventHandler(ByteArray2Image_Format);
            租赁协议照片3PictureBox.DataBindings["Image"].Format += new ConvertEventHandler(ByteArray2Image_Format);

            //如果ReadOnly状态，相应控件只读或不可用
            if (IsReadOnly)
            {
                labReadOnly.Visible = true;
                foreach (var con in kryptonPanel1.Controls)
                {
                    if (con is KryptonTextBox)
                        (con as KryptonTextBox).ReadOnly = true;
                    else if (con is KryptonDateTimePicker)
                        (con as KryptonDateTimePicker).Enabled = false;
                    else if (con is KryptonCheckBox)
                        (con as KryptonCheckBox).Enabled = false;
                    else if (con is KryptonButton)
                        (con as KryptonButton).Enabled = false;
                }
            }
        }

        void ByteArray2Image_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value == null)
                return;

            Byte[] bytes = e.Value as Byte[];
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image oldImg = Image.FromStream(ms);
                Image newImg = new Bitmap(oldImg.Width,oldImg.Height);
                Graphics draw = Graphics.FromImage(newImg);
                draw.DrawImage(oldImg, 0, 0);
                e.Value = newImg;
                draw.Dispose();
                oldImg.Dispose();
                //e.Value = Image.FromStream(ms);因为ms流的关闭，造成后面会出现GDI+ 错误
            }
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
                    //租赁协议照片1PictureBox.Image = img;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        (客房BindingSource.DataSource as GuestRoom).租赁协议照片1 = ms.ToArray();
                    }
                }
                else if (sender == btnOpenFile2)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        (客房BindingSource.DataSource as GuestRoom).租赁协议照片2 = ms.ToArray();
                    }
                }
                else if (sender == btnOpenFile3)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        (客房BindingSource.DataSource as GuestRoom).租赁协议照片3 = ms.ToArray();
                    }
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
                    e.Graphics.DrawString("双击打开图像", f, linGrBrush, 2, 2);
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
                    tfc.KeepFiles = true;
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

        private void 客房BindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            GuestRoom kf = 客房BindingSource.DataSource as GuestRoom;
            kf.GuestRoomRentalDetail.AsQueryable().Load();
            客房租金明细BindingSource.DataSource = parentContext.GuestRoomRentalDetail
                .Local.Where(m=>m.客房ID==kf.ID).OrderByDescending(m => m.起付日期);
        }

    }
}
