using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Landlord2.Properties;

namespace Landlord2.UI
{
    public partial class 阶梯电价Form : KryptonForm
    {
        public string ResultElectricValue = null;
        public 阶梯电价Form(string electricValueString)
        {
            InitializeComponent();
            ResultElectricValue = electricValueString;
        }

        private void 阶梯电价Form_Load(object sender, EventArgs e)
        {
            if (ResultElectricValue == null)
            {
                kryptonNumericUpDown1.Value = Convert.ToDecimal(Resources.武汉市阶梯电价默认值) ;//如果初始为null，载入默认值
            }
            else
            {
                kryptonNumericUpDown1.Value = Convert.ToDecimal(ResultElectricValue);
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            //目前未实行阶梯电价，先仅定义电单价
            kryptonNumericUpDown1.Value = Convert.ToDecimal(Resources.武汉市阶梯电价默认值);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ResultElectricValue = kryptonNumericUpDown1.Value.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }








    }
}
