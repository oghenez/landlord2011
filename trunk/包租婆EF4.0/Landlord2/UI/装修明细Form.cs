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
    public partial class 装修明细Form : FormBase
    {
        private BindingListView<装修明细> blv;//【装修明细BindingSource】的数据源，涉及到过滤，所以这里单独提出来。 
        public 装修明细Form()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 根据条件过滤
        /// </summary>
        private void FilterData()
        {
            List<Predicate<装修明细>> predicateList = new List<Predicate<装修明细>>();

            if(cmbFilter源房.SelectedItem!=null && !string.IsNullOrEmpty(cmbFilter源房.SelectedItem.ToString()))
                predicateList.Add(m => m.源房.房名 == cmbFilter源房.SelectedItem.ToString());
            
            if (cmbFilter装修分类.SelectedItem!=null && !string.IsNullOrEmpty(cmbFilter装修分类.SelectedItem.ToString()))
                predicateList.Add(m => m.装修分类 == cmbFilter装修分类.SelectedItem.ToString());

            if (!string.IsNullOrEmpty(tbFilter规格.Text))
                predicateList.Add(m => m.规格!=null && m.规格.Contains(tbFilter规格.Text.Trim()));

            if (!string.IsNullOrEmpty(tbFilter地点.Text))
                predicateList.Add(m => m.购买地点!=null && m.购买地点.Contains(tbFilter地点.Text.Trim()));

            if (dtpFilterBegin.Checked)
                predicateList.Add(m => m.日期.Date >= dtpFilterBegin.Value.Date);

            if (dtpFilterEnd.Checked)
                predicateList.Add(m => m.日期.Date <= dtpFilterEnd.Value.Date);

            if (nudFilterBegin.Value > 0)
                predicateList.Add(m => m.单价 * m.数量 >= nudFilterBegin.Value);

            if (nudFilterEnd.Value < 999999)
                predicateList.Add(m => m.单价 * m.数量 <= nudFilterEnd.Value);

            //将多个条件合并成最终的一个条件：delegate bool Predicate<in T>
            Predicate<装修明细> filter = (m) =>
            {
                foreach (Predicate<装修明细> predicate in predicateList)
                {
                    if (!predicate(m))
                        return false;
                }
                return true;
            };

            blv.ApplyFilter(filter);
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterData();
            CaculateSumMoney();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cmbFilter源房.SelectedIndex = -1;
            cmbFilter装修分类.SelectedIndex = -1;
            tbFilter规格.Text = "";
            tbFilter地点.Text = "";
            dtpFilterBegin.Checked = false;
            dtpFilterEnd.Checked = false;
            nudFilterBegin.Value = 0;
            nudFilterEnd.Value = 999999;
            //FilterData(); 
            blv.RemoveFilter();
            CaculateSumMoney();
        }
        public void RefreshAndLocate装修明细(Guid? entityID)
        {
            blv =  context.装修明细.Execute(System.Data.Objects.MergeOption.OverwriteChanges).ToBindingListView();//这里用NoTracking那么无法删除（因为context未保存对应记录）；用AppendOnly那么当编辑后无法刷新
            装修明细BindingSource.DataSource = blv;
            FilterData();

            if (entityID != null)
                装修明细BindingSource.Position = blv.Find("ID", entityID);
        }
        private void 装修明细Form_Load(object sender, EventArgs e)
        {
            源房[] yuanFang = 源房.GetYF(context).Execute(System.Data.Objects.MergeOption.NoTracking).ToArray();
            源房BindingSource.DataSource = yuanFang;
            RefreshAndLocate装修明细(null);

            cmbFilter源房.Items.Add("");//先加一个空行
            cmbFilter源房.Items.AddRange(yuanFang.Select(m => m.房名).ToArray());

            cmbFilter装修分类.Items.Add("");
            cmbFilter装修分类.Items.AddRange(context.装修分类.Execute(System.Data.Objects.MergeOption.NoTracking).Select(m => m.类别).ToArray());
        }

        private void 装修明细BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            bindingNavigatorEditItem.Enabled = 装修明细BindingSource.Current != null;
            bindingNavigatorDeleteItem.Enabled = 装修明细BindingSource.Current != null;
            CaculateSumMoney();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            using (装修Form form = new 装修Form())
            {
                form.ShowDialog(this);
            }
        }

        private void 装修明细BindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            bindingNavigatorEditItem.Enabled = 装修明细BindingSource.Current != null;
            bindingNavigatorDeleteItem.Enabled = 装修明细BindingSource.Current != null;
            CaculateSumMoney();
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
            ObjectView<装修明细> view = 装修明细BindingSource.Current as ObjectView<装修明细>;
            if (view != null && view.Object != null)
            {
                using (装修Form form = new 装修Form(view.Object))
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
                ObjectView<装修明细> view = 装修明细BindingSource.Current as ObjectView<装修明细>;
                if (view != null && view.Object != null)
                {
                    context.装修明细.DeleteObject(view.Object);

                    string msg;
                    if (Helper.saveData(context, view.Object, out msg))
                    {
                        装修明细BindingSource.RemoveCurrent();//如果成功删除数据库中指定项，那么同步删除界面中当前选中项，避免再次Load数据库和刷新界面。
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
            if (装修明细BindingSource.DataSource != null)
            {
                decimal total = 0.00M;
                foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
                {
                    object obj = row.Cells["数量DataGridViewTextBoxColumn"].Value;
                    object obj2 = row.Cells["单价DataGridViewTextBoxColumn"].Value;
                    total += Convert.ToDecimal(obj) * Convert.ToDecimal(obj2);
                }
                kryptonHeaderGroup1.ValuesSecondary.Description = string.Format("{0} 元", decimal.Round(total,2));
            }
            else
                kryptonHeaderGroup1.ValuesSecondary.Description = "0.00 元";
        }


    }
}
