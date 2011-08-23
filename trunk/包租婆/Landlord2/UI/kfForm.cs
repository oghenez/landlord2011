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
    public partial class kfForm : KryptonForm
    {
        private 客房 kf;
        private bool isNew;//是否新增操作
        public kfForm(客房 kf)
        {
            this.kf = kf;
            InitializeComponent();
        }

        private void kfForm_Load(object sender, EventArgs e)
        {
            if (kf == null)
            {
                isNew = true;
                Text = "新增客房";
                kf = new 客房();
                uC客房详细1.客房BindingSource.DataSource = kf;
            }
            else
            {
                isNew = false;
                Text = "编辑客房";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string check = kf.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }
            if (isNew)
            {
                Main.context.AddTo客房(kf);
                string msg;
                if (Helper.saveData(Main.context.源房, out msg))
                {
                    KryptonMessageBox.Show(msg, "成功新增客房");
                    (this.Owner as Main).RefreshAndLocateTree(kf);//刷新TreeView，并定位到kf节点。
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg, "失败");
                    Main.context.Detach(kf);
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
