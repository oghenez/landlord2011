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

namespace Landlord2.UI
{
    public partial class yfForm : KryptonForm
    {
        private 源房 yf;
        private bool isNew;//是否是新增

        /// <summary>
        /// 新增源房、编辑源房面板
        /// </summary>
        /// <param name="yf">yf=null则为新增操作</param>
        public yfForm(源房 yf)
        {
            this.yf = yf;
            InitializeComponent();
        }

        private void YF_Load(object sender, EventArgs e)
        {
            if (yf == null)
            {
                isNew = true;
                Text = "新增源房";
                yf = new 源房();
                uC源房详细1.源房BindingSource.DataSource = yf;
            }
            else
            {
                isNew = false;
                Text = "编辑源房";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string check = yf.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }
            if (isNew)
            {
                Main.context.AddTo源房(yf);
                string msg;
                if (Helper.saveData(Main.context.源房, out msg))
                {
                    KryptonMessageBox.Show(msg, "成功新增源房");
                    (this.Owner as Main).RefreshAndLocateTree(yf);//刷新TreeView，并定位到yf节点。
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg, "失败");
                    Main.context.Detach(yf);
                }
            }
            else
            { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
