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
        private Guid yfGuid;//客房隶属的源房Guid
        private bool isNew;//是否新增操作

        public kfForm(客房 kf)
        {
            this.kf = kf;
            InitializeComponent();
        }

        public kfForm(Guid yfGuid)
        {
            this.yfGuid = yfGuid;
            InitializeComponent();
        }

        private void kfForm_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = Main.context.源房.Where(m => m.源房涨租协定.Max(n => n.期止) > DateTime.Now);
            if (kf == null)
            {
                isNew = true;
                Text = "新增客房";
                BtnOkAndContinue.Visible = true;//保存并继续按钮可见
                kf = new 客房();
                if (yfGuid == Guid.Empty)
                    kf.源房 = bindingSource1.Current as 源房;
                else
                {
                    kf.源房ID = yfGuid;
                    kryptonComboBox1.SelectedValue = yfGuid;
                }
            }
            else
            {
                isNew = false;
                Text = "编辑客房";
                kryptonComboBox1.SelectedValue = kf.源房ID;
            }
            uC客房详细1.客房BindingSource.DataSource = kf;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            uC客房详细1.客房BindingSource.EndEdit();

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
        private void BtnOkAndContinue_Click(object sender, EventArgs e)
        {
            string check = kf.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }

#if DEBUG
            System.Diagnostics.Debug.Assert(isNew);//只有新增状态才有此按钮
#endif

            Main.context.AddTo客房(kf);
            string msg;
            if (Helper.saveData(kf, out msg))
            {
                KryptonMessageBox.Show(string.Format("成功新增客房[{0}]。您可以继续添加客房！", kf.命名), "成功新增客房");
                (this.Owner as Main).RefreshAndLocateTree(kf);//刷新TreeView，并定位到kf节点。
                客房 old = kf;
                kf = new 客房()
                {
                    面积=old.面积,
                    含厨房 = old.含厨房,
                    含卫生间=old.含卫生间,
                    源房=old.源房
                };
                
                uC客房详细1.客房BindingSource.DataSource = kf;
            }
            else
            {
                KryptonMessageBox.Show(msg, "失败");
                Main.context.Detach(kf);
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

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(kryptonComboBox1.SelectedValue != null)
                kf.源房ID = (Guid)kryptonComboBox1.SelectedValue;
        }


    }
}
