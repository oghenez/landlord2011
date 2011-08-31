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
            源房缴费明细BindingSource.DataSource = GetPayDetails();//初始情况，针对所有源房

            var query2 = Main.context.源房.Where(m => m.源房涨租协定.Max(n => n.期止) > DateTime.Now);
            bindingSource1.DataSource = ((ObjectQuery<源房>)query2).Execute(MergeOption.NoTracking);           
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

            if (raBtnAll.Checked)
            {
                源房缴费明细BindingSource.DataSource = GetPayDetails();
            }
            else if (raBtnOne.Checked)
            {
                源房缴费明细BindingSource.DataSource = GetPayDetails((Guid)kryptonComboBox1.SelectedValue);
            }
            
            btnFilter.Text = "按 [缴费项] 筛选 - 所有";
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            源房缴费明细BindingSource.DataSource = GetPayDetails((Guid)kryptonComboBox1.SelectedValue);
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
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? GetPayDetails(guid) : GetPayDetails();
                    btnFilter.Text = "按 [缴费项] 筛选 - 所有";
                    break;
                case "房租":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? GetPayDetails(guid, "房租") : GetPayDetails("房租");
                    btnFilter.Text = "按 [缴费项] 筛选 - 房租";
                    break;
                case "物业费":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? GetPayDetails(guid, "物业费") : GetPayDetails("物业费");
                    btnFilter.Text = "按 [缴费项] 筛选 - 物业费";
                    break;
                case "水":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? GetPayDetails(guid, "水") : GetPayDetails("水");
                    btnFilter.Text = "按 [缴费项] 筛选 - 水";
                    break;
                case "电":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? GetPayDetails(guid, "电") : GetPayDetails("电");
                    btnFilter.Text = "按 [缴费项] 筛选 - 电";
                    break;
                case "气":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? GetPayDetails(guid, "气") : GetPayDetails("气");
                    btnFilter.Text = "按 [缴费项] 筛选 - 气";
                    break;
                case "宽带费":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? GetPayDetails(guid, "宽带费") : GetPayDetails("宽带费");
                    btnFilter.Text = "按 [缴费项] 筛选 - 宽带费";
                    break;
                case "中介费":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? GetPayDetails(guid, "中介费") : GetPayDetails("中介费");
                    btnFilter.Text = "按 [缴费项] 筛选 - 中介费";
                    break;
                case "押金":
                    源房缴费明细BindingSource.DataSource = raBtnOne.Checked ? GetPayDetails(guid, "押金") : GetPayDetails("押金");
                    btnFilter.Text = "按 [缴费项] 筛选 - 押金";
                    break;
                case "其他":
                    {
                        var query = from p in raBtnOne.Checked ? GetPayDetails(guid) : GetPayDetails()
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


        #region 预编译查询
        /// <summary>
        /// 预编译查询0 -- 查询所有
        /// </summary>
        static readonly Func<Entities, IEnumerable<源房缴费明细>> compiledQuery0 =
            CompiledQuery.Compile<Entities, IEnumerable<源房缴费明细>>(
            (context) => context.源房缴费明细);
        /// <summary>
        /// 预编译查询0 -- 查询所有
        /// </summary>
        private IEnumerable<源房缴费明细> GetPayDetails()
        {
            if (Main.context.源房缴费明细.HasAddedObject())
            {
                return Main.context.源房缴费明细.Local()  ;
            }
            else
            {
                return compiledQuery0.Invoke(Main.context); 
            }            
        }

        /// <summary>
        /// 预编译查询1 -- 根据源房ID和缴费项2个条件过滤
        /// </summary>
        static readonly Func<Entities, Guid, string, IEnumerable<源房缴费明细>> compiledQuery1 =
            CompiledQuery.Compile<Entities, Guid, string, IEnumerable<源房缴费明细>>(
            (context, guid, payItem) => context.源房缴费明细.Where(m => m.源房ID == guid && m.缴费项 == payItem));
        /// <summary>
        /// 预编译查询1 -- 根据源房ID和缴费项2个条件过滤
        /// </summary>
        private IEnumerable<源房缴费明细> GetPayDetails(Guid guid, string 缴费项)
        {
            if (Main.context.源房缴费明细.HasAddedObject())
            {
                return Main.context.源房缴费明细.Local().Where(m => m.源房ID == guid && m.缴费项 == 缴费项);
            }
            else
            {
                return compiledQuery1.Invoke(Main.context, guid, 缴费项);
            }             
        }

        /// <summary>
        /// 预编译查询2 -- 根据源房ID过滤
        /// </summary>
        static readonly Func<Entities, Guid, IEnumerable<源房缴费明细>> compiledQuery2 =
            CompiledQuery.Compile<Entities, Guid, IEnumerable<源房缴费明细>>(
            (context, guid) => context.源房缴费明细.Where(m => m.源房ID == guid));
        /// <summary>
        /// 预编译查询2 -- 根据源房ID过滤
        /// </summary>
        private IEnumerable<源房缴费明细> GetPayDetails(Guid guid)
        {
            if (Main.context.源房缴费明细.HasAddedObject())
            {
                return Main.context.源房缴费明细.Local().Where(m => m.源房ID == guid);
            }
            else
            {
                return compiledQuery2.Invoke(Main.context, guid);
            }   
            
        }

        /// <summary>
        /// 预编译查询3 -- 根据缴费项过滤
        /// </summary>
        static readonly Func<Entities, string, IEnumerable<源房缴费明细>> compiledQuery3 =
            CompiledQuery.Compile<Entities, string, IEnumerable<源房缴费明细>>(
            (context, payItem) => context.源房缴费明细.Where(m => m.缴费项 == payItem));
        /// <summary>
        /// 预编译查询3 -- 根据缴费项过滤
        /// </summary>
        private IEnumerable<源房缴费明细> GetPayDetails(string 缴费项)
        {
            if (Main.context.源房缴费明细.HasAddedObject())
            {
                return Main.context.源房缴费明细.Local().Where(m => m.缴费项 == 缴费项);
            }
            else
            {
                return compiledQuery3.Invoke(Main.context, 缴费项);
            }              
        } 
        #endregion



    }
}
