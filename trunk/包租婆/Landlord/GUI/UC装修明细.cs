using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI.Localization;

namespace Landlord.GUI
{
    public partial class UC装修明细 : Landlord.GUI.UCBase
    {
        private 源房 yf = null;
        public UC装修明细() { InitializeComponent(); }
        public UC装修明细( 源房 yf) : base(DockStyle.Fill)
        {
            InitializeComponent();
            this.yf = yf;

            RadGridLocalizationProvider.CurrentProvider = new MyChsRadGridLocalizationProvider();
            radGridView1.Columns["小计"].Expression = "数量 * 单价";

            源房BindingSource.DataSource = Main.context.源房;
            装修分类BindingSource.DataSource = Main.context.装修分类;
            装修明细BindingSource.DataSource = Main.context.装修明细;

        }
    }
}
