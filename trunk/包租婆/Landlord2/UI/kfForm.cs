﻿using System;
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
            bindingSource1.DataSource = Main.context.源房.Where(m => m.源房涨租协定.Max(n => n.期止) > DateTime.Now);
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
            if (isNew)//新增
            {
                Main.context.AddTo客房(kf);
                string msg;
                if (Helper.saveData(kf, out msg))
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
            else//编辑
            {                
                if (Main.context.ObjectStateManager.GetObjectStateEntry(kf).State == EntityState.Unchanged)
                {
                    Close(); //如果编辑状态下，未做任何修改，则直接退出
                }
                else
                {
                    string msg;
                    if (Helper.saveData(kf, out msg))
                    {
                        KryptonMessageBox.Show(msg, "成功编辑客房");
                        (this.Owner as Main).RefreshAndLocateTree(kf);//刷新TreeView，并定位到kf节点。
                        Close();
                    }
                    else
                    {
                        KryptonMessageBox.Show(msg, "失败");
                        //Main.context.Refresh(System.Data.Objects.RefreshMode.StoreWins, yf);失败后这里不处理，关闭窗体时处理更改
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kfForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isNew && Main.context.ObjectStateManager.GetObjectStateEntry(kf).State == EntityState.Modified)
            {
                Main.context.Refresh(System.Data.Objects.RefreshMode.StoreWins, kf);
                Main.context.AcceptAllChanges();
            }
        }
    }
}
