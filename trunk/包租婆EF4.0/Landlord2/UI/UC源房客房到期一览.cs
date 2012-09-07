using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Landlord2.Data;
using System.Linq;
using System.Data.Objects;

namespace Landlord2.UI
{
    public partial class UC源房客房到期一览 : Landlord2.UI.UCBaseChart
    {
        //private Bitmap bufferimage;
        //private int x;
        //private int y;

        public UC源房客房到期一览()
        {
            InitializeComponent();
            
        }

        //加载或更新bmp并根据图像大小调整父容器
        public void LoadAndResize(Bitmap bmp)
        {
            //Graphics.FromImage(bmp).Clear(Color.Red);

            BasePanel.Size = bmp.Size;
            BasePanel.BackgroundImageLayout = ImageLayout.None;
            BasePanel.BackgroundImage = bmp;

        }


    }
}
