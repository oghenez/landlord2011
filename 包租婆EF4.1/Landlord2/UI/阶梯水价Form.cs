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
    public partial class 阶梯水价Form : KryptonForm
    {
        //最后返回的值
        public string ResultWaterValue = null;

        public 阶梯水价Form(string waterValueString)
        {
            InitializeComponent();
            ResultWaterValue = waterValueString;
        }

        private void 阶梯水价Form_Load(object sender, EventArgs e)
        {
            if (ResultWaterValue == null)
            {
                btnDefault_Click(null, null);//如果初始为null，载入默认值
            }
            else
            {
                Dictionary<string, decimal> dic = Helper.trans阶梯水价(ResultWaterValue);
                if (dic.Count == 1)//用户原来设定的是：不使用阶梯水价
                {
                    raBtnNoUse.Checked = true;
                    kryptonNumericUpDown1.Value = dic["k1"];
                }
                else
                {
                    raBtnUse.Checked = true;
                    setControlValueByDictionary(dic);
                }
            }
        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Resources.武汉市城市供水价格表);
        }

        private void kryptonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            kryptonNumericUpDown10.Enabled =
                kryptonNumericUpDown11.Enabled =
                kryptonNumericUpDown2.Enabled =
                kryptonNumericUpDown20.Enabled =
                kryptonNumericUpDown21.Enabled =
                kryptonNumericUpDown3.Enabled =
                kryptonNumericUpDown30.Enabled = raBtnUse.Checked;
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            //武汉市阶梯水价默认值
            Dictionary<string, decimal> dic = Helper.trans阶梯水价(Resources.武汉市阶梯水价默认值);
            setControlValueByDictionary(dic);
        }
        //通过解析后回传的Dictionary，给控件赋值
        private void setControlValueByDictionary(Dictionary<string, decimal> dic)
        {
            kryptonNumericUpDown1.Value = dic["k1"];
            kryptonNumericUpDown10.Value = dic["k10"];
            kryptonNumericUpDown11.Value = dic["k11"];
            kryptonNumericUpDown2.Value = dic["k2"];
            kryptonNumericUpDown20.Value = dic["k20"];
            kryptonNumericUpDown21.Value = dic["k21"];
            kryptonNumericUpDown3.Value = dic["k3"];
            kryptonNumericUpDown30.Value = dic["k30"];
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string result = Check();
            if (string.IsNullOrEmpty(result))//校验规则通过
            {
                if (raBtnUse.Checked)
                {
                    ResultWaterValue = string.Format("{0},{1},{2};{3},{4},{5};{6},{7}",
                        kryptonNumericUpDown1.Value,
                        kryptonNumericUpDown10.Value,
                        kryptonNumericUpDown11.Value,
                        kryptonNumericUpDown2.Value,
                        kryptonNumericUpDown20.Value,
                        kryptonNumericUpDown21.Value,
                        kryptonNumericUpDown3.Value,
                        kryptonNumericUpDown30.Value);
                }
                else
                {
                    ResultWaterValue = kryptonNumericUpDown1.Value.ToString();
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
            {
                KryptonMessageBox.Show(result, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //规则判定: 如果出错返回错误信息
        private string Check()
        {
            StringBuilder sb = new StringBuilder();
            if (raBtnUse.Checked)//使用阶梯水价
            {
                if (kryptonNumericUpDown1.Value > kryptonNumericUpDown2.Value || kryptonNumericUpDown2.Value > kryptonNumericUpDown3.Value)
                    sb.Append("阶梯水价不是递增序列，请检查各个阶梯价格值！" + Environment.NewLine);
                if (kryptonNumericUpDown11.Value != kryptonNumericUpDown20.Value || kryptonNumericUpDown21.Value != kryptonNumericUpDown30.Value)
                    sb.Append("用水量范围不连续，请检查用水量值！"+Environment.NewLine);
            }            
            return sb.ToString();
        }

    }
}
