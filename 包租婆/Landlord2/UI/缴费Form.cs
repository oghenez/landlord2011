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
        private bool isNew;//是否新增标志，保存时，会涉及不同提示。

        public 缴费Form()
        {
            InitializeComponent();
            isNew = true;
        }
        public 缴费Form(Guid yfID)
        {
            InitializeComponent();
            isNew = true;
            this.yfID = yfID;
        }
        public 缴费Form(源房缴费明细 payDetail)
        {
            InitializeComponent();
            isNew = false;
            this.payDetail = payDetail;
        } 

        private void 缴费Form_Load(object sender, EventArgs e)
        {
            Text = string.Format("源房缴费[{0}]",isNew? "新增":"编辑");
            源房BindingSource.DataSource = 源房.GetYF_Current();

            if (isNew)//新增
            {
                BtnOkAndContinue.Visible = true;//保存并继续按钮可见
                payDetail = new 源房缴费明细();
                if (yfID == Guid.Empty)//未指定源房ID的新增
                {
                    payDetail.源房 = 源房BindingSource.Current as 源房;
                }
                else
                {
                    payDetail.源房ID = yfID;
                    cmbYF.SelectedValue = yfID;
                }
            }
            else//编辑
            {
                cmbYF.SelectedValue = payDetail.源房ID;
            }
            源房缴费明细BindingSource.DataSource = payDetail;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            源房缴费明细BindingSource.EndEdit();

            string check = payDetail.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }

            if (isNew)//新增
            {
                Main.context.源房缴费明细.AddObject(payDetail);
                string msg;
                if (Helper.saveData(payDetail, out msg))
                {
                    KryptonMessageBox.Show(msg, "成功新增缴费信息");
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg, "失败");
                    Main.context.源房缴费明细.Detach(payDetail);
                }
            }
            else//编辑
            {
                if (Main.context.ObjectStateManager.GetObjectStateEntry(payDetail).State == EntityState.Unchanged)
                {
                    Close(); //如果编辑状态下，未做任何修改，则直接退出
                }
                else
                {
                    string msg;
                    if (Helper.saveData(payDetail, out msg))
                    {
                        KryptonMessageBox.Show(msg, "成功编辑缴费信息");
                        Close();
                    }
                    else
                    {
                        KryptonMessageBox.Show(msg, "失败");
                    }
                }
            }

        }

        private void BtnOkAndContinue_Click(object sender, EventArgs e)
        {
            源房缴费明细BindingSource.EndEdit();

            string check = payDetail.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }

#if DEBUG
            System.Diagnostics.Debug.Assert(isNew);//只有新增状态才有此按钮
#endif
           
            Main.context.源房缴费明细.AddObject(payDetail);
            string msg;
            if (Helper.saveData(payDetail, out msg))
            {
                KryptonMessageBox.Show(string.Format("成功新增缴费信息。您可以继续添加！"), "成功新增缴费信息");
                源房缴费明细 old = payDetail;
                payDetail = new 源房缴费明细()
                {
                    源房 = old.源房
                };

                源房缴费明细BindingSource.DataSource = payDetail;
            }
            else
            {
                KryptonMessageBox.Show(msg, "失败");
                Main.context.源房缴费明细.Detach(payDetail);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 缴费Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isNew && Main.context.ObjectStateManager.GetObjectStateEntry(payDetail).State == EntityState.Modified)
            {
                Main.context.Refresh(System.Data.Objects.RefreshMode.StoreWins, payDetail);
                Main.context.AcceptAllChanges();
            }
        }

    }
}
