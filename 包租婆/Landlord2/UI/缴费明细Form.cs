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
    public partial class 缴费明细Form : KryptonForm
    {
        public 缴费明细Form()
        {
            InitializeComponent();
        }

        private void 缴费Form_Load(object sender, EventArgs e)
        {
            源房缴费明细BindingSource.DataSource = Main.context.源房缴费明细;
            bindingSource1.DataSource = Main.context.源房.Where(m => m.源房涨租协定.Max(n => n.期止) > DateTime.Now);
        }

        private void 缴费明细Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var changes = Main.context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified);
            if (changes.Count() > 0)
            {
                Main.context.Refresh(System.Data.Objects.RefreshMode.StoreWins, Main.context.源房缴费明细);
                Main.context.AcceptAllChanges();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            源房缴费明细BindingSource.EndEdit();

            var changes = Main.context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified);
            if (changes.Count() > 0)
            {
                //校验
                StringBuilder sb = new StringBuilder();
                List<Guid> errorIDs = new List<Guid>();//错误记录的ID号，高亮显示。
                foreach (ObjectStateEntry change in changes)
                {
                    //校验每一条更改的实体，最后联合显示错误信息。
                    源房缴费明细 entity = change.Entity as 源房缴费明细;
                    string result = entity.CheckRules();
                    if (!string.IsNullOrEmpty(result))//证明有错误
                    {
                        sb.Append(string.Format("-----[{0}][{1}][{2}]：该记录有误-----", entity.源房.房名, entity.缴费时间.ToShortDateString(), entity.缴费项) + Environment.NewLine);
                        sb.Append(result);
                        errorIDs.Add(entity.ID);
                    }
                }
                if (!string.IsNullOrEmpty(sb.ToString()))
                {
                    highLightRow(errorIDs);//高亮错误行
                    KryptonMessageBox.Show(sb.ToString(), "数据校验失败");
                    return;
                }

                string msg;
                if (Helper.saveData(Main.context.源房缴费明细, out msg))
                {
                    KryptonMessageBox.Show(msg, "成功保存");
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
        //高亮错误行
        private void highLightRow(List<Guid> guids)
        { 
            //kryptonDataGridView1中有一个隐藏列“ID”
            foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
            {
                if (guids.Contains((Guid)row.Cells["ID"].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Pink;
                }
            }
        }
        private void raBtn_CheckedChanged(object sender, EventArgs e)
        {
            kryptonDataGridView1.AllowUserToAddRows = raBtnOne.Checked;//选中单个源房时，允许添加。
            kryptonComboBox1.Enabled = raBtnOne.Checked;

            btnFilter.Text = "按 [缴费项] 筛选 - 所有";
            源房缴费明细BindingSource.Filter = string.Empty;
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void 源房缴费明细BindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
#if DEBUG
            System.Diagnostics.Debug.Assert(raBtnOne.Checked);
#endif
            源房缴费明细 yfPay = new 源房缴费明细();
            yfPay.源房ID = (Guid)kryptonComboBox1.SelectedValue;
            yfPay.缴费时间 = DateTime.Now.Date;
            e.NewObject = yfPay;
        }






    }
}
