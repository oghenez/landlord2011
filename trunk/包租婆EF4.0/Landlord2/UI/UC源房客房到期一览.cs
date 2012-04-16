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
            BasePanel.BackgroundImage = bmp;
            ////test
            //Graphics.FromImage(bmp).Clear(Color.Red);
            //bufferimage = bmp;
            //this.AutoScrollMinSize = new Size(bmp.Width+20, bmp.Height+20);//上下左右各留10px

            //调整载入bmp的起始点
            //y = 10;//y值固定
            //int width = bufferimage.Width;
            //int height = bufferimage.Height;
            ////父容器过小，则上下左右最少各留出10px空隙；父容器过大，则居中
            //int parentWidth = Parent.Width;
            //int parentHeight = Parent.Height;
            //if (10 + width + 10 < parentWidth)
            //    x = (parentWidth - 10 - width) / 2;
            //else
            //{
            //    x = 10;
            //}
            //x = BasePanel.Location.X;
            //y = BasePanel.Location.Y;
            
            //Invalidate();
        }

        //private void UC源房客房到期一览_Paint(object sender, PaintEventArgs e)
        //{
        //    if (bufferimage != null)
        //    {
        //        Graphics g = e.Graphics;

        //        //平移坐标系
        //        g.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);

        //        //把画布贴到画面上
        //        e.Graphics.DrawImage(bufferimage, x, y);
        //    }
        //    //e.Graphics.DrawString("testing...", new Font("宋体", 14), new SolidBrush(Color.Red), 10, 10);
        //}

        //private void LoadDataOld()
        //{            
        //    //chart1.Series[0].YValueType = ChartValueType.DateTime;
        //    List<源房> yfList = 源房.GetYF_NoHistory(context).Include("客房").Include("源房涨租协定").Execute(MergeOption.NoTracking).ToList();
        //    int yfCount = yfList.Count;
        //    if (yfCount <= 0)
        //        return;

        //    var yfSeriesPoints = chart1.Series["Series源房"].Points;
        //    var kfSeriesList = new List<Series>();//每个源房的第一个客房作为一个序列；第二个作为一个序列，依此类推。
            
        //    DateTime min=DateTime.Now;
        //    DateTime max=DateTime.Now;
        //    for (int index = 0; index < yfCount; index++)
        //    {
        //        foreach(var yfzzxd in yfList[index].源房涨租协定)
        //        {
        //            if(yfzzxd.期始 < min)
        //                min = yfzzxd.期始;
        //            if(yfzzxd.期止 > max)
        //                max = yfzzxd.期止;
        //            yfSeriesPoints.AddXY(index, yfzzxd.期始, yfzzxd.期止);
        //        }
        //        List<客房> kfList = yfList[index].客房.ToList();
        //        for (int i = 0; i < kfList.Count ;i++ )
        //        {
        //            if (kfSeriesList.Count <= i)
        //            {
        //                Series kfSeries = new Series("Series客房"+i);
        //                kfSeries.ChartArea = "Default";
        //                kfSeries.ChartType = SeriesChartType.RangeBar;
        //                kfSeries.YValueType = ChartValueType.DateTime;
        //                kfSeries.YValuesPerPoint = 2;
        //                kfSeries["DrawingStyle"] = "Cylinder";
        //                kfSeries["DrawSideBySide"] = "true";
        //                kfSeries["PointWidth"] = "0.6";
        //                kfSeriesList.Add(kfSeries);
        //            }
        //            kfSeriesList[i].Points.AddXY(index, kfList[i].期始, kfList[i].期止);
        //        }

        //        yfSeriesPoints[index].AxisLabel = yfList[index].房名;
        //    }

        //    kfSeriesList.ForEach(m => chart1.Series.Add(m));

        //    chart1.ChartAreas[0].AxisY.Minimum = min.ToOADate();
        //    chart1.ChartAreas[0].AxisY.Maximum = max.ToOADate();
        //    //chart1.ChartAreas[0].AxisY.Interval 
        //    chart1.ChartAreas[0].AxisY.LabelStyle.Format = "yyyy/MM/dd";

        //}
    }
}
