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
    public partial class 源房缴费Form : FormBase
    {
        private Guid yfID;//源房ID
        private 源房缴费明细 payDetail;//编辑状态 - 传入源房缴费明细
        private bool isNew;//是否新增标志，保存时，会涉及不同提示。

        public 源房缴费Form()
        {
            InitializeComponent();
            isNew = true;
        }
        public 源房缴费Form(Guid yfID)
        {
            InitializeComponent();
            isNew = true;
            this.yfID = yfID;
        }
        public 源房缴费Form(源房缴费明细 payDetail)
        {
            InitializeComponent();
            isNew = false;
            this.payDetail = context.源房缴费明细.FirstOrDefault(m=>m.ID == payDetail.ID);
        } 

        private void 缴费Form_Load(object sender, EventArgs e)
        {
            Text = string.Format("源房缴费[{0}]",isNew? "新增":"编辑");
            源房BindingSource.DataSource = 源房.GetYF(context).Execute(MergeOption.NoTracking);

            if (isNew)//新增
            {
                BtnOkAndContinue.Visible = true;//保存并继续按钮可见
                payDetail = new 源房缴费明细();
                payDetail.源房ID = this.yfID;
                context.源房缴费明细.AddObject(payDetail);//此操作后可实现外键同步
            }
            else//编辑
            {
                //cmbYF.SelectedValue = payDetail.源房ID;//已经直接绑定了
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
                string msg;
                if (Helper.saveData(context, payDetail, out msg))
                {
                    KryptonMessageBox.Show(msg, "成功新增缴费信息");
                    if (this.Owner is Main)
                        (this.Owner as Main).RefreshAndLocateTree(payDetail.源房);//刷新TreeView，并定位到yf节点。
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg, "失败");
                }
            }
            else//编辑
            {
                if (context.ObjectStateManager.GetObjectStateEntry(payDetail).State == EntityState.Unchanged)
                {
                    Close(); //如果编辑状态下，未做任何修改，则直接退出
                }
                else
                {
                    string msg;
                    if (Helper.saveData(context, payDetail, out msg))
                    {
                        KryptonMessageBox.Show(msg, "成功编辑缴费信息");
                        if (this.Owner is Main)
                            (this.Owner as Main).RefreshAndLocateTree(payDetail.源房);//刷新TreeView，并定位到yf节点。
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
           
            string msg;
            if (Helper.saveData(context, payDetail, out msg))
            {
                KryptonMessageBox.Show(string.Format("成功新增缴费信息。您可以继续添加！"), "成功新增缴费信息");
                if (this.Owner is Main)
                    (this.Owner as Main).RefreshAndLocateTree(payDetail.源房);//刷新TreeView，并定位到kf节点。
                源房缴费明细 old = payDetail;
                payDetail = new 源房缴费明细();
                payDetail.源房ID = old.源房ID;
                context.源房缴费明细.AddObject(payDetail);//此操作后可实现外键同步

                源房缴费明细BindingSource.DataSource = payDetail;
            }
            else
            {
                KryptonMessageBox.Show(msg, "失败");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbYF_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }
        private void cmbPayItem_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void FilterDataGridView()
        {
            if (cmbYF.SelectedValue != null)
            {
                ObjectQuery<源房缴费明细> result = 源房缴费明细.GetPayDetails(context, (Guid)cmbYF.SelectedValue, cmbPayItem.Text);
                参考历史BindingSource.DataSource = result.Execute(MergeOption.NoTracking);
            }
        }


    }
}
