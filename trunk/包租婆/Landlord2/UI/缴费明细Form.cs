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
            源房缴费明细BindingSource.DataSource = 源房缴费明细.GetPayDetails();//初始情况，针对所有源房

            var query2 = Main.context.源房.Where(m => m.源房涨租协定.Max(n => n.期止) > DateTime.Now);
            bindingSource1.DataSource = 源房.GetYF_Current();// ((ObjectQuery<源房>)query2).Execute(MergeOption.NoTracking);           
        }

        private void 缴费明细Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var changes = Main.context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified);
            if (changes.Count() > 0)
            {
                Main.context.Refresh(System.Data.Objects.RefreshMode.StoreWins, Main.context.源房缴费明细);
                Main.context.AcceptAllChanges();
            }

            kryptonComboBox1.SelectedIndexChanged -= kryptonComboBox1_SelectedIndexChanged;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

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
            BtnAdd.Enabled = raBtnOne.Checked;//选中单个源房时，允许添加。
            kryptonComboBox1.Enabled = raBtnOne.Checked;

            if (raBtnAll.Checked)
            {
                源房缴费明细BindingSource.DataSource = 源房缴费明细.GetPayDetails();
            }
            else if (raBtnOne.Checked)
            {
                源房缴费明细BindingSource.DataSource = 源房缴费明细.GetPayDetails((Guid)kryptonComboBox1.SelectedValue);
            }
            
            btnFilter.Text = "按 [缴费项] 筛选 - 所有";
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            源房缴费明细BindingSource.DataSource = 源房缴费明细.GetPayDetails((Guid)kryptonComboBox1.SelectedValue);
            btnFilter.Text = "按 [缴费项] 筛选 - 所有";
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string txt = item.Text;
            Guid guid = (Guid)kryptonComboBox1.SelectedValue;
            switch (txt)
            {
                case "所有缴费项":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? 源房缴费明细.GetPayDetails(guid) : 源房缴费明细.GetPayDetails();
                    btnFilter.Text = "按 [缴费项] 筛选 - 所有";
                    break;
                case "房租":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? 源房缴费明细.GetPayDetails(guid, "房租") : 源房缴费明细.GetPayDetails("房租");
                    btnFilter.Text = "按 [缴费项] 筛选 - 房租";
                    break;
                case "物业费":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? 源房缴费明细.GetPayDetails(guid, "物业费") : 源房缴费明细.GetPayDetails("物业费");
                    btnFilter.Text = "按 [缴费项] 筛选 - 物业费";
                    break;
                case "水":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? 源房缴费明细.GetPayDetails(guid, "水") : 源房缴费明细.GetPayDetails("水");
                    btnFilter.Text = "按 [缴费项] 筛选 - 水";
                    break;
                case "电":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? 源房缴费明细.GetPayDetails(guid, "电") : 源房缴费明细.GetPayDetails("电");
                    btnFilter.Text = "按 [缴费项] 筛选 - 电";
                    break;
                case "气":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? 源房缴费明细.GetPayDetails(guid, "气") : 源房缴费明细.GetPayDetails("气");
                    btnFilter.Text = "按 [缴费项] 筛选 - 气";
                    break;
                case "宽带费":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? 源房缴费明细.GetPayDetails(guid, "宽带费") : 源房缴费明细.GetPayDetails("宽带费");
                    btnFilter.Text = "按 [缴费项] 筛选 - 宽带费";
                    break;
                case "中介费":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? 源房缴费明细.GetPayDetails(guid, "中介费") : 源房缴费明细.GetPayDetails("中介费");
                    btnFilter.Text = "按 [缴费项] 筛选 - 中介费";
                    break;
                case "押金":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? 源房缴费明细.GetPayDetails(guid, "押金") : 源房缴费明细.GetPayDetails("押金");
                    btnFilter.Text = "按 [缴费项] 筛选 - 押金";
                    break;
                case "其他":
                    {
                        var query = from p in raBtnOne.Checked ? 源房缴费明细.GetPayDetails(guid) : 源房缴费明细.GetPayDetails()
                                    where !(new[] { "房租", "物业费", "水", "电", "气", "宽带费", "中介费", "押金" }.Contains(p.缴费项))
                                    select p;
                        源房缴费明细BindingSource.DataSource = query;
                        btnFilter.Text = "按 [缴费项] 筛选 - 其他";
                    }
                    break;
                default:
                    break;
            }
        }

        private void 源房缴费明细BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            //var source = 源房缴费明细BindingSource.DataSource as ObjectQuery<源房缴费明细>;
            //if (source == null) 
            //    return;
            //var query = from o in source
            //            select new { o.缴费金额 };
            //decimal sum = source.Sum(m => m.缴费金额);
            //labCountMoney.Text = string.Format("当前合计金额： {0} 元", sum);
        }





    }
}
