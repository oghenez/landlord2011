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
    public partial class 源房抄表明细Form : FormBase
    {
        private BindingListView<源房抄表> blv;//【源房抄表BindingSource】的数据源，涉及到过滤，所以这里单独提出来。 
        public 源房抄表明细Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据条件过滤
        /// </summary>
        private void FilterData()
        {
            List<Predicate<源房抄表>> predicateList = new List<Predicate<源房抄表>>();

            if (cmbFilter源房.SelectedItem != null && !string.IsNullOrEmpty(cmbFilter源房.SelectedItem.ToString()))
                predicateList.Add(m => m.源房.房名 == cmbFilter源房.SelectedItem.ToString());
            
            if (dtpFilterBegin.Checked)
                predicateList.Add(m => m.抄表时间.Date >= dtpFilterBegin.Value.Date);

            if (dtpFilterEnd.Checked)
                predicateList.Add(m => m.抄表时间.Date <= dtpFilterEnd.Value.Date);

            //将多个条件合并成最终的一个条件：delegate bool Predicate<in T>
            Predicate<源房抄表> filter = (m) =>
            {
                foreach (Predicate<源房抄表> predicate in predicateList)
                {
                    if (!predicate(m))
                        return false;
                }
                return true;
            };

            blv.ApplyFilter(filter);
        }
        private void 源房抄表明细Form_Load(object sender, EventArgs e)
        {
            源房[] yuanFang = 源房.GetYF(context).Execute(System.Data.Objects.MergeOption.NoTracking).ToArray();
            源房BindingSource.DataSource = yuanFang;
            RefreshAndLocate源房抄表(null);

            cmbFilter源房.Items.Add("");//先加一个空行
            cmbFilter源房.Items.AddRange(yuanFang.Select(m => m.房名).ToArray());
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterData();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cmbFilter源房.SelectedIndex = -1;
            dtpFilterBegin.Checked = false;
            dtpFilterEnd.Checked = false;
            blv.RemoveFilter();
        }

        public void RefreshAndLocate源房抄表(Guid? entityID)
        {
            blv = 源房抄表.GetYFCB(context,null).Execute(System.Data.Objects.MergeOption.OverwriteChanges).ToBindingListView();//这里用NoTracking那么无法删除（因为context未保存对应记录）；用AppendOnly那么当编辑后无法刷新
            源房抄表BindingSource.DataSource = blv;
            FilterData();

            if (entityID != null)
                源房抄表BindingSource.Position = blv.Find("ID", entityID);
        }

        private void 源房抄表BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            bindingNavigatorEditItem.Enabled = 源房抄表BindingSource.Current != null;
            bindingNavigatorDeleteItem.Enabled = 源房抄表BindingSource.Current != null;
        }

        private void 源房抄表BindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            bindingNavigatorEditItem.Enabled = 源房抄表BindingSource.Current != null;
            bindingNavigatorDeleteItem.Enabled = 源房抄表BindingSource.Current != null;

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            using (源房抄表Form form = new 源房抄表Form())
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
            ObjectView<源房抄表> view = 源房抄表BindingSource.Current as ObjectView<源房抄表>;
            if (view != null && view.Object != null)
            {
                using (源房抄表Form form = new 源房抄表Form(view.Object))
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
                ObjectView<源房抄表> view = 源房抄表BindingSource.Current as ObjectView<源房抄表>;
                if (view != null && view.Object != null)
                {
                    context.源房抄表.DeleteObject(view.Object);

                    string msg;
                    if (Helper.saveData(context, view.Object, out msg))
                    {
                        源房抄表BindingSource.RemoveCurrent();//如果成功删除数据库中指定项，那么同步删除界面中当前选中项，避免再次Load数据库和刷新界面。
                    }
                    else
                    {
                        KryptonMessageBox.Show(msg, "失败");
                    }

                }
            }
        }

  
    }
}
