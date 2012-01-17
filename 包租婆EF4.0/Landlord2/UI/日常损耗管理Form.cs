using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Landlord2.Data;
using Equin.ApplicationFramework;
using ComponentFactory.Krypton.Toolkit;

namespace Landlord2.UI
{
    public partial class 日常损耗管理Form : FormBase
    {
        private BindingListView<日常损耗> blv;//【日常损耗BindingSource】的数据源，涉及到过滤，所以这里单独提出来。 

        public 日常损耗管理Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据条件过滤
        /// </summary>
        private void FilterData()
        {
            List<Predicate<日常损耗>> predicateList = new List<Predicate<日常损耗>>();

            if (cmbFilter源房.SelectedItem != null && !string.IsNullOrEmpty(cmbFilter源房.SelectedItem.ToString()))
                predicateList.Add(m => m.源房ID == ((源房)cmbFilter源房.SelectedItem).ID);

            if (cmbFilter客房.SelectedValue != null && !string.IsNullOrEmpty(cmbFilter客房.SelectedItem.ToString()))
                predicateList.Add(m => m.客房ID == ((客房)cmbFilter客房.SelectedItem).ID);

            if (!string.IsNullOrEmpty(tbFilter项目.Text))
                predicateList.Add(m => m.项目 != null && m.项目.Contains(tbFilter项目.Text.Trim()));

            if (!string.IsNullOrEmpty(tbFilter备注.Text))
                predicateList.Add(m => m.备注 != null && m.备注.Contains(tbFilter备注.Text.Trim()));

            if (dtpFilterBegin.Checked)
                predicateList.Add(m => m.支出日期.HasValue && m.支出日期.Value.Date >= dtpFilterBegin.Value.Date);

            if (dtpFilterEnd.Checked)
                predicateList.Add(m => m.支出日期.HasValue && m.支出日期.Value.Date <= dtpFilterEnd.Value.Date);

            if (nudFilterBegin.Value > 0)
                predicateList.Add(m => m.支出金额.HasValue && m.支出金额.Value >= nudFilterBegin.Value);

            if (nudFilterEnd.Value < 999999)
                predicateList.Add(m => m.支出金额.HasValue && m.支出金额.Value <= nudFilterEnd.Value);

            //将多个条件合并成最终的一个条件：delegate bool Predicate<in T>
            Predicate<日常损耗> filter = (m) =>
            {
                foreach (Predicate<日常损耗> predicate in predicateList)
                {
                    if (!predicate(m))
                        return false;
                }
                return true;
            };

            blv.ApplyFilter(filter);
        }

        private void 日常损耗管理Form_Load(object sender, EventArgs e)
        {
            源房[] yuanFang = 源房.GetYF(context).Execute(System.Data.Objects.MergeOption.NoTracking).ToArray();
            源房BindingSource.DataSource = yuanFang;
            客房BindingSource.DataSource = context.客房.Execute(System.Data.Objects.MergeOption.NoTracking);
            RefreshAndLocate日常损耗(null);

            cmbFilter源房.Items.Add("");//先加一个空行
            Array.ForEach(yuanFang,m =>{ cmbFilter源房.Items.Add(m);});
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterData();
            CaculateSumMoney();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cmbFilter源房.SelectedIndex = 0;
            cmbFilter客房.SelectedIndex = 0;
            tbFilter项目.Text = "";
            tbFilter备注.Text = "";
            dtpFilterBegin.Checked = false;
            dtpFilterEnd.Checked = false;
            nudFilterBegin.Value = 0;
            nudFilterEnd.Value = 999999;
            blv.RemoveFilter();
            CaculateSumMoney();
        }
        public void RefreshAndLocate日常损耗(Guid? entityID)
        {
            blv = context.日常损耗.Execute(System.Data.Objects.MergeOption.OverwriteChanges).ToBindingListView();//这里用NoTracking那么无法删除（因为context未保存对应记录）；用AppendOnly那么当编辑后无法刷新
            日常损耗BindingSource.DataSource = blv;
            FilterData();

            if (entityID != null)
                日常损耗BindingSource.Position = blv.Find("ID", entityID);
        }

        private void 日常损耗BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            bindingNavigatorEditItem.Enabled = 日常损耗BindingSource.Current != null;
            bindingNavigatorDeleteItem.Enabled = 日常损耗BindingSource.Current != null;
            CaculateSumMoney();
        }

        private void 日常损耗BindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            bindingNavigatorEditItem.Enabled = 日常损耗BindingSource.Current != null;
            bindingNavigatorDeleteItem.Enabled = 日常损耗BindingSource.Current != null;
            CaculateSumMoney();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            using (日常损耗Form form = new 日常损耗Form())
            {
                form.ShowDialog(this);
            }
        }

        private void bindingNavigatorEditItem_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        private void kryptonDataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EditItem();
        }

        private void EditItem()
        {
            ObjectView<日常损耗> view = 日常损耗BindingSource.Current as ObjectView<日常损耗>;
            if (view != null && view.Object != null)
            {
                using (日常损耗Form form = new 日常损耗Form(view.Object))
                {
                    form.ShowDialog(this);
                }
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var result = KryptonMessageBox.Show("删除当前选中记录？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                ObjectView<日常损耗> view = 日常损耗BindingSource.Current as ObjectView<日常损耗>;
                if (view != null && view.Object != null)
                {
                    context.日常损耗.DeleteObject(view.Object);

                    string msg;
                    if (Helper.saveData(context, view.Object, out msg))
                    {
                        日常损耗BindingSource.RemoveCurrent();//如果成功删除数据库中指定项，那么同步删除界面中当前选中项，避免再次Load数据库和刷新界面。
                    }
                    else
                    {
                        KryptonMessageBox.Show(msg, "失败");
                    }

                }
            }
        }
        private void CaculateSumMoney()
        {
            if (日常损耗BindingSource.DataSource != null)
            {
                decimal total = 0.00M;
                foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
                {
                    object obj = row.Cells["支出金额DataGridViewTextBoxColumn"].Value;
                    total += Convert.ToDecimal(obj);
                }
                kryptonHeaderGroup1.ValuesSecondary.Description = string.Format("{0} 元", decimal.Round(total, 2));
            }
            else
                kryptonHeaderGroup1.ValuesSecondary.Description = "0.00 元";
        }

        private void cmbFilter源房_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter源房.SelectedIndex > 0)//第一项为‘无’
            {
                源房 selectedYF = cmbFilter源房.SelectedItem as 源房;
                客房[] keFang = selectedYF.客房.ToArray();

                cmbFilter客房.Items.Clear();
                cmbFilter客房.Items.Add("");//先加一个空行
                Array.ForEach(keFang, m => { cmbFilter客房.Items.Add(m); });
            }
        }
    }
}
