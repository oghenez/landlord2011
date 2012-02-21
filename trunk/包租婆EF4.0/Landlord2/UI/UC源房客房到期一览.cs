using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Landlord2.Data;

namespace Landlord2.UI
{
    public partial class UC源房客房到期一览 : Landlord2.UI.UCBaseChart
    {
        public UC源房客房到期一览()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            chart1.Series[0].YValueType = ChartValueType.DateTime;
            foreach (源房 yf in 源房.GetYF_NoHistory(context).Include("客房").Execute(System.Data.Objects.MergeOption.NoTracking))
            {
                
            }
        }
    }
}
