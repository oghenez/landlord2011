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
            源房缴费明细BindingSource.DataSource = 源房缴费明细.GetPayDetails(null, null).Execute(MergeOption.AppendOnly);//初始情况，针对所有源房
            源房BindingSource.DataSource = 源房.GetYF().Execute(MergeOption.NoTracking);           
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(raBtnOne.Checked && cmbYF.SelectedValue != null)
                using (缴费Form jf = new 缴费Form((Guid)cmbYF.SelectedValue))
                {
                    jf.ShowDialog(this);
                }
            else
                using (缴费Form jf = new 缴费Form())
                {
                    jf.ShowDialog(this);
                }

            //最后，不管有没有更新，刷新DataGridView
            raBtn_CheckedChanged(null, null);
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
                    row.DefaultCellStyle.BackColor = Color.Pink;
                else
                    row.DefaultCellStyle = kryptonDataGridView1.RowTemplate.DefaultCellStyle;
            }
        }
        private void raBtn_CheckedChanged(object sender, EventArgs e)
        {
            cmbYF.Enabled = raBtnOne.Checked;

            if (raBtnAll.Checked)
            {
                源房缴费明细BindingSource.DataSource = 源房缴费明细.GetPayDetails(null, null).Execute(MergeOption.AppendOnly);
            }
            else if (raBtnOne.Checked)
            {
                源房缴费明细BindingSource.DataSource = 源房缴费明细.GetPayDetails((Guid)cmbYF.SelectedValue, null).Execute(MergeOption.AppendOnly);
            }
            btnFilter.Text = "按 [缴费项] 筛选 - 所有缴费项";
        }

        private void cmbYF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYF.SelectedValue != null)
            {
                源房缴费明细BindingSource.DataSource = 源房缴费明细.GetPayDetails((Guid?)cmbYF.SelectedValue, null).Execute(MergeOption.AppendOnly);
                btnFilter.Text = "按 [缴费项] 筛选 - 所有缴费项";
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string txt = item.Text;
            Guid? guid = raBtnOne.Checked ? (Guid?)cmbYF.SelectedValue : null;

            btnFilter.Text = string.Format("按 [缴费项] 筛选 - {0}",txt);
            switch (txt)
            {
                case "所有缴费项":
                    源房缴费明细BindingSource.DataSource = 源房缴费明细.GetPayDetails(guid,null).Execute(MergeOption.AppendOnly);
                    break;
                case "其他":
                    {
                        var query = (from p in 源房缴费明细.GetPayDetails(guid,null)
                                    where !(new[] { "房租", "物业费", "水", "电", "气", "宽带费", "中介费", "押金" }.Contains(p.缴费项))
                                    select p) as ObjectQuery<源房缴费明细>;
                        源房缴费明细BindingSource.DataSource = query.Execute(MergeOption.AppendOnly);
                    }
                    break;
                default:
                    源房缴费明细BindingSource.DataSource = 源房缴费明细.GetPayDetails(guid, txt).Execute(MergeOption.AppendOnly);
                    break;
            }
        }
    }
}
