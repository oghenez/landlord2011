﻿using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Landlord2.Data;

namespace Landlord2.UI
{
    public partial class 客房出租Form : FormBase
    {
        private 客房 kf;
        public 客房出租Form(Guid kfID)
        {
            InitializeComponent();
            uC客房详细1.tbKfName.ReadOnly = true;//客房名字不许更改
            uC客房详细1.tbKfName.StateCommon.Content.Color1 = Color.Red;
            this.kf = context.客房.FirstOrDefault(m=>m.ID == kfID);
        }

        private void 出租Form_Load(object sender, EventArgs e)
        {
            uC客房详细1.客房BindingSource.DataSource = kf;
            kryptonHeader1.Values.Heading = kf.源房.房名;
            kryptonHeader1.Values.Description = kf.命名;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            uC客房详细1.客房BindingSource.EndEdit();

            //特殊校验: 必须有租户
            if (string.IsNullOrEmpty(kf.租户))
            {
                KryptonMessageBox.Show("请填写租户姓名!", "数据校验失败");
                return;
            }

            string check = kf.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }

            if (context.ObjectStateManager.GetObjectStateEntry(kf).State == EntityState.Unchanged)
            {
                Close(); //如果编辑状态下，未做任何修改，则直接退出
            }
            else
            {
                string msg;
                if (Helper.saveData(context, kf, out msg))
                {
                    DialogResult = DialogResult.OK;//传出成功标志，主界面会提示是否马上进行首期收租。
                    KryptonMessageBox.Show(msg, "成功出租客房");
                    if(this.Owner is Main)
                        (this.Owner as Main).RefreshAndLocateTree(kf);//刷新TreeView，并定位到kf节点。
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg, "失败");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
