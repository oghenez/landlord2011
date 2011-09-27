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
    public partial class 源房缴费明细Form : FormBase
    {
        public 源房缴费明细Form()
        {
            InitializeComponent();
        }

        private void 缴费Form_Load(object sender, EventArgs e)
        {
            源房缴费明细BindingSource.DataSource = 源房缴费明细.GetPayDetails(context, null, null).Execute(MergeOption.AppendOnly);//初始情况，针对所有源房
            源房BindingSource.DataSource = 源房.GetYF(context).Execute(MergeOption.NoTracking);           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(raBtnOne.Checked && cmbYF.SelectedValue != null)
                using (源房缴费Form jf = new 源房缴费Form((Guid)cmbYF.SelectedValue))
                {
                    jf.ShowDialog(this);
                }
            else
                using (源房缴费Form jf = new 源房缴费Form())
                {
                    jf.ShowDialog(this);
                }

            //最后，不管有没有更新，刷新DataGridView
            raBtn_CheckedChanged(null, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            源房缴费明细BindingSource.EndEdit();

            var changes = context.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted | EntityState.Modified);
            if (changes.Count() > 0)
            {
                //校验
                StringBuilder sb = new StringBuilder();
                Dictionary<Guid, string> errors = new Dictionary<Guid, string>();//记录错误的ID号，和对应错误信息。
                foreach (ObjectStateEntry change in changes)
                {
                    //校验每一条更改的实体，最后联合显示错误信息。
                    源房缴费明细 entity = change.Entity as 源房缴费明细;
                    string result = entity.CheckRules();
                    if (!string.IsNullOrEmpty(result))//证明有错误
                    {
                        string err = string.Format("-----[{0}][{1}][{2}]：该记录有误-----\r\n{3}", 
                            entity.源房.房名, entity.缴费时间.ToShortDateString(), entity.缴费项,result);
                        sb.Append(err);
                        errors.Add(entity.ID,err);
                    }
                }
                if (!string.IsNullOrEmpty(sb.ToString()))
                {
                    highLightRow(errors);//高亮错误行
                    KryptonMessageBox.Show(sb.ToString(), "数据校验失败");
                    return;
                }

                string msg;
                if (Helper.saveData(context, context.源房缴费明细, out msg))
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
        private void highLightRow(Dictionary<Guid, string> errors)
        { 
            //kryptonDataGridView1中有一个隐藏列“ID”
            foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
            {
                if (errors.Keys.Contains((Guid)row.Cells["ID"].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.Pink;
                    row.ErrorText = errors[(Guid)row.Cells["ID"].Value];
                }
                else
                {
                    row.DefaultCellStyle.BackColor = kryptonDataGridView1.RowsDefaultCellStyle.BackColor;
                    row.ErrorText = string.Empty;
                }
            }
        }
        private void raBtn_CheckedChanged(object sender, EventArgs e)
        {
            cmbYF.Enabled = raBtnOne.Checked;

            if (raBtnAll.Checked)
            {
                源房缴费明细BindingSource.DataSource = context.源房缴费明细.Local2();//源房缴费明细.GetPayDetails(context, null, null).Execute(MergeOption.AppendOnly);
            }
            else if (raBtnOne.Checked)
            {
                源房缴费明细BindingSource.DataSource = context.源房缴费明细.Local().Where(m => m.源房ID == (Guid)cmbYF.SelectedValue); //源房缴费明细.GetPayDetails(context, (Guid)cmbYF.SelectedValue, null).Execute(MergeOption.AppendOnly);
            }
            btnFilter.Text = "按 [缴费项] 筛选 - 所有缴费项";
        }

        private void cmbYF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYF.SelectedValue != null)
            {
                源房缴费明细BindingSource.DataSource = context.源房缴费明细.Local().Where(m => m.源房ID == (Guid)cmbYF.SelectedValue); //源房缴费明细.GetPayDetails(context, (Guid?)cmbYF.SelectedValue, null).Execute(MergeOption.AppendOnly);
                btnFilter.Text = "按 [缴费项] 筛选 - 所有缴费项";
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string txt = item.Text;
            Guid? guid = raBtnOne.Checked ? (Guid?)cmbYF.SelectedValue : null;

            btnFilter.Text = string.Format("按 [缴费项] 筛选 - {0}",txt);
            //先过滤是否针对某个源房ID
            var filterGuid = guid.HasValue ? context.源房缴费明细.Local().Where(m => m.源房ID == guid) : context.源房缴费明细.Local();
            switch (txt)
            {
                case "所有缴费项":
                    源房缴费明细BindingSource.DataSource = filterGuid; //源房缴费明细.GetPayDetails(context, guid, null).Execute(MergeOption.AppendOnly);
                    break;
                case "其他":
                    {
                        var query = from p in filterGuid//源房缴费明细.GetPayDetails(context, guid, null)
                                    where !(new[] { "房租", "物业费", "水", "电", "气", "宽带费", "中介费", "押金" }.Contains(p.缴费项))
                                    select p;
                        源房缴费明细BindingSource.DataSource = query;
                    }
                    break;
                default:
                    源房缴费明细BindingSource.DataSource = filterGuid.Where(m=>m.缴费项 == txt);//源房缴费明细.GetPayDetails(context, guid, txt).Execute(MergeOption.AppendOnly);
                    break;
            }
        }

        private void CaculateSumMoney()
        {
            if (源房缴费明细BindingSource.DataSource != null && 源房缴费明细BindingSource.Count > 0)
            {
                decimal total = 0.00M;
                foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
                {
                    object obj = row.Cells["缴费金额DataGridViewTextBoxColumn"].Value;
                    total += (decimal)obj;
                }
                labCountMoney.Text = string.Format("当前合计：{0} 元", total);
            }
            else
                labCountMoney.Text = string.Empty;
        }

        private void 源房缴费明细BindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            CaculateSumMoney();
        }

        private void kryptonDataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            CaculateSumMoney();
        }

        private void kryptonDataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)//缴费金额更改
            {
                CaculateSumMoney();
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            var current = 源房缴费明细BindingSource.Current;
            if (current != null)
            {
                源房缴费明细BindingSource.RemoveCurrent();
            }
        }

    }
}
