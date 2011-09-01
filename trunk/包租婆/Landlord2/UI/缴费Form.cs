using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Landlord2.Data;
using System.Data.Objects;

namespace Landlord2.UI
{
    public partial class 缴费Form : KryptonForm
    {
        private Guid yfID;//源房ID
        private 源房缴费明细 payDetail;//编辑状态 - 传入源房缴费明细
        public 缴费Form()
        {
            InitializeComponent();
            Text = "源房缴费[新增]";
        }
        public 缴费Form(Guid yfID)
        {
            InitializeComponent();
            Text = "源房缴费[新增]";
            this.yfID = yfID;
        }
        public 缴费Form(源房缴费明细 payDetail)
        {
            InitializeComponent();
            Text = "源房缴费[编辑]";
            this.payDetail = payDetail;
        } 

        private void 缴费Form_Load(object sender, EventArgs e)
        {
            源房BindingSource.DataSource = 源房.GetYF_Current();//Main.context.源房.Execute(MergeOption.AppendOnly);//
        }
    }
}
