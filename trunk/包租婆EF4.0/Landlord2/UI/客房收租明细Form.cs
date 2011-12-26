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
    public partial class 客房收租明细Form : FormBase
    {
        private 客房 kf;//当选择单套客房时所选择的客房
        private IEnumerable<客房租金明细> willBeDeletedList;//临时存储，在用户删除某条记录后，该记录之前的欲删除记录集合

        public 客房收租明细Form()
        {
            InitializeComponent();
        }

        private void 客房收租明细Form_Load(object sender, EventArgs e)
        {
            客房租金明细BindingSource.DataSource = 客房租金明细.GetRentDetails(context, null).Execute(MergeOption.AppendOnly); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            客房租金明细BindingSource.EndEdit();

            var changes = context.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted | EntityState.Modified);
            if (changes.Count() > 0)
            {
                //校验
                //此处省略校验逻辑，因为UI修改时只能修改“付款日期、实付金额、付款人、收款人、备注”，其他信息不可更改。

                string msg;
                if (Helper.saveData(context, context.客房租金明细, out msg))
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

            if (raBtnAll.Checked)
            {
                客房租金明细BindingSource.DataSource = 客房租金明细.GetRentDetails(context, null).Execute(MergeOption.AppendOnly); 
                llbKF.Values.ExtraText = "<请选择>";
                kf = null;
            }
            else if (raBtnOne.Checked)
            {
                客房租金明细BindingSource.DataSource = null;
            }
        }

        private void llbKF_LinkClicked(object sender, EventArgs e)
        {
            using (客房选择Form form = new 客房选择Form(context, 客房筛选.客房收租))
            {
                var result = form.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (kf != form.selectedKF)
                    {
                        kf = form.selectedKF;
                        ChangeKF(kf.ID);
                    }
                }
            }      
        }

        private void ChangeKF(Guid kfID)
        {
            llbKF.Values.ExtraText = string.Format("[{0}] - {1}", kf.源房.房名, kf.命名);
            客房租金明细BindingSource.DataSource = 客房租金明细.GetRentDetails(context, kfID).Execute(MergeOption.AppendOnly); 
        }

        private void kryptonDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)//首列
            {
                客房 k = e.Value as 客房;
                if (k != null) 
                    e.Value = string.Format("[{0}] - {1}", k.源房.房名, k.命名);
            }
        }
        
        private void CaculateSumMoney()
        {
            if (客房租金明细BindingSource.DataSource != null)
            {
                decimal total = 0.00M;
                foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
                {
                    object obj = row.Cells["实付金额DataGridViewTextBoxColumn"].Value;
                    total += (decimal)obj;
                }
                labCountMoney.Text = string.Format("当前【实付金额】合计：{0} 元", decimal.Round(total,2));
            }
            else
                labCountMoney.Text = string.Empty;
        }

        private void 客房租金明细BindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            CaculateSumMoney();
        }

        private void kryptonDataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)//实付金额更改
            {
                CaculateSumMoney();
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            //只允许删除---只能针对当前租户，删除某条记录，则该记录起的后续记录都将被删除！
            客房租金明细 current = 客房租金明细BindingSource.Current as 客房租金明细;
            if (current == null)
                return;

            List<客房租金明细> currentList = 客房租金明细.GetRentDetails_Current2(current.客房);
            if (!currentList.Contains(current))
            {
                string msg;
                if (string.IsNullOrEmpty(current.客房.租户))
                    msg = "此条【收租明细信息】属于历史租户历史协议期内信息，无法删除！（详见上方操作说明）";
                else
                    msg = string.Format("此条【收租明细信息】非‘当前租户[{0}]、当前协议期内[{1}]’的记录，无法删除！",
                        current.客房.租户,
                        current.客房.期始.Value.ToShortDateString() + "~" + current.客房.期止.Value.ToShortDateString());
                KryptonMessageBox.Show(msg);
                return;
            }
            else
            {
                willBeDeletedList = currentList.Where(m => m.起付日期 > current.起付日期);
                int num = willBeDeletedList.Count();
                string msg = string.Format("删除此条记录，该记录的后续收租明细信息[{0}条]都将被删除！\r\n(详见上方操作说明)\r\n是否删除？", num);
                if (KryptonMessageBox.Show(msg, "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    //删除当前选中
                    客房租金明细BindingSource.RemoveCurrent();
                    //删除涉及到的
                    foreach (var o in willBeDeletedList)
                    {
                        context.客房租金明细.DeleteObject(o);
                    }
                    willBeDeletedList = null;//删除后置空
                    CaculateSumMoney();
                }
            }            
        }
    }
}
