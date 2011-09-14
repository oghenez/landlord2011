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
    public partial class 客房收租明细Form : KryptonForm
    {
        private 客房 kf;//当选择单套客房时所选择的客房

        public 客房收租明细Form()
        {
            InitializeComponent();
        }

        private void 客房收租明细Form_Load(object sender, EventArgs e)
        {
            客房租金明细BindingSource.DataSource = 客房租金明细.GetRentDetails(null).Execute(MergeOption.AppendOnly); 
        }

        private void 客房收租明细Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var changes = Main.context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified);
            if (changes.Count() > 0)
            {
                Main.context.Refresh(System.Data.Objects.RefreshMode.StoreWins, Main.context.客房租金明细);
                Main.context.AcceptAllChanges();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (kf == null)
            {
                KryptonMessageBox.Show("请先选择欲收租的客房!");
                return;
            }

            using (客房收租Form sz = new 客房收租Form(kf))
            {
                sz.ShowDialog(this);
                kf = sz.kf;//也许用户在新增收租里有一次更改了kf，此时回传
            }

            //最后，不管有没有更新，刷新DataGridView
            ChangeKF();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            客房租金明细BindingSource.EndEdit();

            var changes = Main.context.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted | EntityState.Modified);
            if (changes.Count() > 0)
            {
                //校验
                //此处省略校验逻辑，因为UI修改时只能修改“付款日期、实付金额、付款人、收款人、备注”，其他信息不可更改。

                string msg;
                if (Helper.saveData(Main.context.客房租金明细, out msg))
                {
                    KryptonMessageBox.Show(msg, "成功保存");
                    if (this.Owner is Main)
                        (this.Owner as Main).RefreshAndLocateTree(kf);//刷新TreeView，并定位到kf节点。
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg, "失败");
                }
            }
            else//未做更改
            {
                Close();
            }
        }

        private void raBtn_CheckedChanged(object sender, EventArgs e)
        {
            llbKF.Enabled = raBtnOne.Checked;
            BtnAdd.Visible = raBtnOne.Checked;

            if (raBtnAll.Checked)
            {
                客房租金明细BindingSource.DataSource = 客房租金明细.GetRentDetails(null).Execute(MergeOption.AppendOnly); 
                llbKF.Values.ExtraText = "<请选择>";
                kf = null;
            }
            else if (raBtnOne.Checked)
            {
                客房租金明细BindingSource.DataSource = null;
            }
        }

        private void 客房租金明细BindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (客房租金明细BindingSource.DataSource != null)
            {
                decimal total = 0.00M;
                foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
                {
                    object obj = row.Cells["实付金额DataGridViewTextBoxColumn"].Value;
                    total += (decimal)obj;
                }
                labCountMoney.Text = string.Format("当前[实付金额] 合计：{0} 元", total);
            }
            else
                labCountMoney.Text = string.Empty;
        }

        private void llbKF_LinkClicked(object sender, EventArgs e)
        {
            using (客房选择Form form = new 客房选择Form(客房筛选.客房收租))
            {
                var result = form.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (kf != form.selectedKF)
                    {
                        kf = form.selectedKF;
                        ChangeKF();
                    }
                }
            }      
        }

        private void ChangeKF()
        {
            llbKF.Values.ExtraText = string.Format("[{0}] - {1}", kf.源房.房名, kf.命名);
            客房租金明细BindingSource.DataSource = 客房租金明细.GetRentDetails(kf.ID).Execute(MergeOption.AppendOnly); 
        }

        private void kryptonDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)//首列
            {
                客房 k = e.Value as 客房;
                e.Value = string.Format("[{0}] - {1}", k.源房.房名, k.命名);
            }
        }

        private void kryptonDataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //只允许删除---该租户协议租期内，最近的一条记录
            客房租金明细 entity = 客房租金明细BindingSource.Current as 客房租金明细;
            DateTime recentTime = 客房租金明细.GetRentDetails(entity.客房ID).Max(n => n.起付日期);
            if (recentTime <= entity.客房.期始)//-----有问题：假设此时客房没租户，意味着没期始时间。
            {
                //不属于该租户的缴租记录
                KryptonMessageBox.Show("此条[收租明细信息]非当前租户协议期内记录，无法删除！\r\n<历史租户的收租明细记录无法直接删除，只有先删除相关的历史出租记录，那么相关历史协议期内的收租明细会自动清除。>");
                e.Cancel = true;
                return;
            }
            if (entity.起付日期 != recentTime)
            {
                //非当前租户最近记录
                KryptonMessageBox.Show("此条[收租明细信息]非当前租户最近一条记录，无法删除！\r\n<收租明细里的记录和之前的记录会相互关联并影响统计结果（例如：水电气止码、相关费用、应付金额等信息），所以只能针对当前租户的最近一次记录进行依次删除。>");
                e.Cancel = true;
                return;
            }
        }
    }
}
