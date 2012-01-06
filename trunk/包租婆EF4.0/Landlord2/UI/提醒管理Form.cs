using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Landlord2.Data;

namespace Landlord2.UI
{
    public partial class 提醒管理Form : FormBase
    {
        public 提醒管理Form()
        {
            InitializeComponent();
        }

        private void 提醒管理Form_Load(object sender, EventArgs e)
        {
            源房BindingSource.DataSource = 源房.GetYF(context).Execute(System.Data.Objects.MergeOption.AppendOnly);
            客房BindingSource.DataSource = 
        }
    }
}
