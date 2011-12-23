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
            源房BindingSource.DataSource = 源房.GetYF(context).Execute(System.Data.Objects.MergeOption.NoTracking);
            RefreshAndLocate装修明细(null);
        }

        private void 装修明细BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            bindingNavigatorEditItem.Enabled = 装修明细BindingSource.Current != null;
            bindingNavigatorDeleteItem.Enabled = 装修明细BindingSource.Current != null;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            using (装修明细详情Form form = new 装修明细详情Form())
            {
                form.ShowDialog(this);
            }
        }

        private void 装修明细BindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            bindingNavigatorEditItem.Enabled = 装修明细BindingSource.Current != null;
            bindingNavigatorDeleteItem.Enabled = 装修明细BindingSource.Current != null;
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
                using (装修明细详情Form form = new 装修明细详情Form(view.Object))
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
    }
}
