namespace Landlord2.UI
{
    partial class UC源房客房到期一览
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.chart1);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea源房";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 40F;
            chartArea1.Position.Width = 20F;
            chartArea1.Position.X = 80F;
            chartArea1.Position.Y = 10F;
            chartArea2.AxisY.ScrollBar.BackColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.ScrollBar.ButtonColor = System.Drawing.Color.Gray;
            chartArea2.AxisY.ScrollBar.LineColor = System.Drawing.Color.Black;
            chartArea2.Name = "ChartArea客房";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 85F;
            chartArea2.Position.Width = 80F;
            chartArea2.Position.Y = 5F;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.DockedToChartArea = "ChartArea源房";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.IsDockedInsideChartArea = false;
            legend1.Name = "Legend源房";
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.DockedToChartArea = "ChartArea客房";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.IsDockedInsideChartArea = false;
            legend2.Name = "Legend客房";
            this.chart1.Legends.Add(legend1);
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea源房";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100;
            series1.Legend = "Legend源房";
            series1.LegendText = "今日占比";
            series1.Name = "Series源房今日百分比";
            series2.ChartArea = "ChartArea源房";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100;
            series2.Legend = "Legend源房";
            series2.LegendText = "缴费截止日占比";
            series2.Name = "Series源房缴费截止日百分比";
            series3.ChartArea = "ChartArea源房";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100;
            series3.Legend = "Legend源房";
            series3.LegendText = "协议截止日占比";
            series3.Name = "Series源房协议截止日百分比";
            series4.ChartArea = "ChartArea客房";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series4.Legend = "Legend客房";
            series4.LegendText = "今日";
            series4.Name = "Series客房今日";
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series5.ChartArea = "ChartArea客房";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series5.Legend = "Legend客房";
            series5.LegendText = "本期收租截止日";
            series5.Name = "Series客房本期收租截止日";
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series6.ChartArea = "ChartArea客房";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series6.Legend = "Legend客房";
            series6.LegendText = "协议截止日";
            series6.Name = "Series客房协议截止日";
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(816, 462);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.DockedToChartArea = "ChartArea客房";
            title1.DockingOffset = 3;
            title1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            title1.IsDockedInsideChartArea = false;
            title1.Name = "Title1";
            title1.Text = "客房时间图";
            title2.DockedToChartArea = "ChartArea源房";
            title2.DockingOffset = 1;
            title2.IsDockedInsideChartArea = false;
            title2.Name = "Title2";
            title2.Text = "源房时间点百分比图";
            this.chart1.Titles.Add(title1);
            this.chart1.Titles.Add(title2);
            // 
            // UC源房客房到期一览
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "UC源房客房到期一览";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

    }
}
