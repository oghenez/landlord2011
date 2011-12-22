using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using ComponentFactory.Krypton.Toolkit;
using Landlord2.Data;

namespace Landlord2.UI
{
    public partial class 装修分类Form : FormBase
    {
        public 装修分类Form(MyContext context)
        {
            InitializeComponent();
            this.context = context;//覆盖掉基类的context，这样修改或新增后不用刷新父窗体
        }

        private void 装修分类Form_Load(object sender, EventArgs e)
        {
            装修分类BindingSource.DataSource = context.装修分类.Execute(MergeOption.AppendOnly);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            装修分类BindingSource.EndEdit();
            try
            {
                context.SaveChanges();
                Close();
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show(ex.Message+"\r\n请确保所有装修分类不重复！", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
