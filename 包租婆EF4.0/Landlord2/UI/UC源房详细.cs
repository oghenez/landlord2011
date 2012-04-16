using System;
using System.Drawing;
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
        /// <summary>
        /// 此构造函数仅编辑器调用
        /// </summary>
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
        private void UC源房详细_Load(object sender, EventArgs e)
        {
            租赁协议照片1PictureBox.DataBindings["Image"].Format += new ConvertEventHandler(ByteArray2Image_Format);
            租赁协议照片2PictureBox.DataBindings["Image"].Format += new ConvertEventHandler(ByteArray2Image_Format);
            租赁协议照片3PictureBox.DataBindings["Image"].Format += new ConvertEventHandler(ByteArray2Image_Format);

            //如果ReadOnly状态，相应控件只读或不可用
            if (IsReadOnly)
            {
                labReadOnly.Visible = true;
                foreach (var con in BasePanel.Controls)
                {
                    if (con is KryptonTextBox)
                        (con as KryptonTextBox).ReadOnly = true;
                    else if (con is KryptonComboBox)
                        (con as KryptonComboBox).Enabled = false;
                    else if (con is KryptonCheckBox)
                        (con as KryptonCheckBox).Enabled = false;
                    else if (con is KryptonButton)
                        (con as KryptonButton).Enabled = false;
                }
                buttonSpecAny阶梯电价.Enabled = ButtonEnabled.False;
                buttonSpecAny阶梯水价.Enabled = ButtonEnabled.False;
                buttonSpecAny气单价.Enabled = ButtonEnabled.False;
                kryptonDataGridView1.ReadOnly = true;
                kryptonDataGridView1.AllowUserToAddRows = false;
                kryptonDataGridView1.AllowUserToDeleteRows = false;
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
                Image newImg = new Bitmap(oldImg.Width, oldImg.Height);
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
                        (源房BindingSource.DataSource as 源房).租赁协议照片1 = ms.ToArray();
                    }
                }
                else if (sender == btnOpenFile2)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        (源房BindingSource.DataSource as 源房).租赁协议照片2 = ms.ToArray();
                    }
                }
                else if (sender == btnOpenFile3)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        (源房BindingSource.DataSource as 源房).租赁协议照片3 = ms.ToArray();
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
                    string fileName = tfc.AddExtension("jpg",true);
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
            using (阶梯水价Form form = new 阶梯水价Form(yf.阶梯水价))
            {
                DialogResult dr = form.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    yf.阶梯水价 = form.ResultWaterValue;
                }
            }
        }

        private void buttonSpecAny阶梯电价_Click(object sender, EventArgs e)
        {
            源房 yf = 源房BindingSource.DataSource as 源房;
            using (阶梯电价Form f = new 阶梯电价Form(yf.阶梯电价))
            {
                DialogResult dr = f.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    yf.阶梯电价 = f.ResultElectricValue;
                }
            }
        }

        private void buttonSpecAny气单价_Click(object sender, EventArgs e)
        {
            源房 yf = 源房BindingSource.DataSource as 源房;
            yf.气单价 = Convert.ToDecimal(Landlord2.Properties.Resources.武汉市天然气价默认值);
        }

        private void 源房涨租协定BindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            源房涨租协定 obj = new 源房涨租协定();
            源房 temp = 源房BindingSource.DataSource as 源房;
            //obj.源房ID = temp.ID;
            obj.源房 = temp;//同步外键引用
            e.NewObject = obj;
        }
        #region 工具栏
        private void 新增源房_Click(object sender, EventArgs e)
        {
            (this.ParentForm as Main).新增源房_Click(sender, e);
        }

        private void 删除源房_Click(object sender, EventArgs e)
        {
            (this.ParentForm as Main).删除源房_Click(sender, e);
        }

        private void 编辑源房_Click(object sender, EventArgs e)
        {
            (this.ParentForm as Main).编辑源房_Click(sender, e);
        }

        private void 新增客房_Click(object sender, EventArgs e)
        {
            (this.ParentForm as Main).新增客房_Click(sender, e);
        }

        private void 源房缴费_Click(object sender, EventArgs e)
        {
            (this.ParentForm as Main).源房缴费_Click(sender, e);
        }

        private void 源房缴费明细_Click(object sender, EventArgs e)
        {
            (this.ParentForm as Main).源房缴费明细_Click(sender, e);
        }

        private void 源房抄表_Click(object sender, EventArgs e)
        {
            (this.ParentForm as Main).源房抄表_Click(sender, e);
        }

        private void 源房装修明细_Click(object sender, EventArgs e)
        {
            (this.ParentForm as Main).源房装修明细_Click(sender, e);
        }
        #endregion


    }
}
