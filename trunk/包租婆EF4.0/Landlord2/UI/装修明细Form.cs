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

namespace Landlord2.UI
{
    public partial class 装修明细Form : FormBase
    {
        public 装修明细Form()
        {
            InitializeComponent();
        }
        public void RefreshAndLocate装修明细(Guid? entityID)
        {
            BindingListView<装修明细> blv =  context.装修明细.Execute(System.Data.Objects.MergeOption.NoTracking).ToBindingListView();
            装修明细BindingSource.DataSource = blv;
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
            if (装修明细BindingSource.Current != null)
            {
                using (装修明细详情Form form = new 装修明细详情Form((装修明细)装修明细BindingSource.Current))
                {
                    form.ShowDialog(this);
                }
            }
        }
    }
}
