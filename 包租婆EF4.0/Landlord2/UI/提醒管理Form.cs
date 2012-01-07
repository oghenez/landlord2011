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
    public partial class 提醒管理Form : FormBase
    {
        private BindingListView<提醒> blv;
        public 提醒管理Form()
        {
            InitializeComponent();
        }

        public void RefreshAndLocate提醒(Guid? entityID)
        {
            blv = 提醒.GetTX(context).Execute(System.Data.Objects.MergeOption.OverwriteChanges).ToBindingListView();//这里用NoTracking那么无法删除（因为context未保存对应记录）；用AppendOnly那么当编辑后无法刷新
            提醒BindingSource.DataSource = blv;
            if (entityID != null)
                提醒BindingSource.Position = blv.Find("ID", entityID);
        }

        private void 提醒管理Form_Load(object sender, EventArgs e)
        {
            源房BindingSource.DataSource = 源房.GetYF(context).Include("客房").Execute(System.Data.Objects.MergeOption.AppendOnly);//通过Include预先加载相关客房
            客房BindingSource.DataSource = context.客房.Execute(System.Data.Objects.MergeOption.AppendOnly);
            RefreshAndLocate提醒(null);
        }

        private void 提醒BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            bindingNavigatorEditItem.Enabled = 提醒BindingSource.Current != null;
            bindingNavigatorDeleteItem.Enabled = 提醒BindingSource.Current != null;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            using (提醒Form form = new 提醒Form())
            {
                form.ShowDialog(this);
            }
        }

        private void 提醒BindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            bindingNavigatorEditItem.Enabled = 提醒BindingSource.Current != null;
            bindingNavigatorDeleteItem.Enabled = 提醒BindingSource.Current != null;
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
            ObjectView<提醒> view = 提醒BindingSource.Current as ObjectView<提醒>;
            if (view != null && view.Object != null)
            {
                using (提醒Form form = new 提醒Form(view.Object))
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
                ObjectView<提醒> view = 提醒BindingSource.Current as ObjectView<提醒>;
                if (view != null && view.Object != null)
                {
                    context.提醒.DeleteObject(view.Object);

                    string msg;
                    if (Helper.saveData(context, view.Object, out msg))
                    {
                        提醒BindingSource.RemoveCurrent();//如果成功删除数据库中指定项，那么同步删除界面中当前选中项，避免再次Load数据库和刷新界面。
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
