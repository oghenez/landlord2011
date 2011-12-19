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
    public partial class 客房出租历史记录Form : FormBase
    {
        private 客房 kf;//当选择单套客房时所选择的客房
        public 客房出租历史记录Form()
        {
            InitializeComponent();
        }

        private void 客房出租历史记录Form_Load(object sender, EventArgs e)
        {
            客房出租历史记录BindingSource.DataSource = 客房出租历史记录.GetKfHistoryDetails(context, null).Execute(MergeOption.AppendOnly);
        }

        private void kryptonDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)//首列
            {
                客房 k = e.Value as 客房;
                e.Value = string.Format("[{0}] - {1}", k.源房.房名, k.命名);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            客房出租历史记录BindingSource.EndEdit();

            var changes = context.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted);
            if (changes.Count() > 0)
            {
                //校验
                //此处省略校验逻辑，因为UI限定此时只能删除。

                string msg1=string.Empty;
                string msg2=string.Empty;
                //删除某条出租历史记录后，相关的【客房收租明细】信息也自动删除。
                if (Helper.saveData(context, context.客房出租历史记录, out msg1) && Helper.saveData(context, context.客房租金明细, out msg2))
                {
                    KryptonMessageBox.Show(msg1 + Environment.NewLine + msg2, "成功保存"); 
                    if (this.Owner is Main)
                        (this.Owner as Main).RefreshAndLocateTree(kf);//刷新TreeView，并定位到kf节点。
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg1 + Environment.NewLine + msg2, "失败");
                }
            }
            else//未做更改
            {
                Close();
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            客房出租历史记录 entity = 客房出租历史记录BindingSource.Current as 客房出租历史记录;
            if (entity == null)
                return;

            客房 tempKF = entity.客房;

            ////只允许删除“历史”客户的记录。因为[续租]后当前租户相关租房信息转到‘客房出租历史记录’表里，那么如果
            ////欲删除的记录是当前客户上次续租的合约记录的话，以后的退租操作无法正常进行（退租时要计算该客户整个
            ////签约期内的款项、押金等等，多退少补）。*/
            if (tempKF.租户 == entity.租户 && tempKF.身份证号 == entity.身份证号)
            {
                KryptonMessageBox.Show("此条【客房出租历史记录】相关信息涉及到当前租户，无法删除。\r\n（当前租户退租后，才能删除此租户相关的【客房出租历史记录】。）", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else//删除某条出租历史记录后，相关的【客房收租明细】信息也自动删除。
            {

                //删除当前选中的‘客房出租历史记录’
                //删除关联的‘客房收租明细’
            }

        }
        private void raBtn_CheckedChanged(object sender, EventArgs e)
        {
            llbKF.Enabled = raBtnOne.Checked;

            if (raBtnAll.Checked)
            {
                客房出租历史记录BindingSource.DataSource = 客房出租历史记录.GetKfHistoryDetails(context, null).Execute(MergeOption.AppendOnly); 
                llbKF.Values.ExtraText = "<请选择>";
                kf = null;
            }
            else if (raBtnOne.Checked)
            {
                客房出租历史记录BindingSource.DataSource = null;
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
            客房出租历史记录BindingSource.DataSource = 客房出租历史记录.GetKfHistoryDetails(context, kfID).Execute(MergeOption.AppendOnly);
        }
    }
}
