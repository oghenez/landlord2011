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
    public partial class 客房出租历史记录Form : KryptonForm
    {
        private 客房 kf;//当选择单套客房时所选择的客房
        public 客房出租历史记录Form()
        {
            InitializeComponent();
        }

        private void 客房出租历史记录Form_Load(object sender, EventArgs e)
        {
            客房出租历史记录BindingSource.DataSource = (Main.context.客房出租历史记录.OrderByDescending(m => m.操作日期) as ObjectQuery<客房出租历史记录>).Execute(MergeOption.AppendOnly);
        }

        private void kryptonDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)//首列
            {
                客房 k = e.Value as 客房;
                e.Value = string.Format("[{0}] - {1}", k.源房.房名, k.命名);
            }
        }

        private void 客房出租历史记录Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var changes = Main.context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified);
            if (changes.Count() > 0)
            {
                Main.context.Refresh(System.Data.Objects.RefreshMode.StoreWins, Main.context.客房出租历史记录);
                Main.context.AcceptAllChanges();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            客房出租历史记录BindingSource.EndEdit();

            var changes = Main.context.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted);
            if (changes.Count() > 0)
            {
                //校验
                //此处省略校验逻辑，因为UI限定此时只能删除。

                string msg1=string.Empty;
                string msg2=string.Empty;
                //删除某条出租历史记录后，相关的【客房收租明细】信息也自动删除。
                if (Helper.saveData(Main.context.客房出租历史记录, out msg1) && Helper.saveData(Main.context.客房租金明细, out msg2))
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

        private void kryptonDataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //只允许删除
            客房出租历史记录 entity = 客房出租历史记录BindingSource.Current as 客房出租历史记录;
            客房 kf = entity.客房;

        }
    }
}
