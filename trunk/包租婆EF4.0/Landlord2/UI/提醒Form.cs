using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Landlord2.Data;

namespace Landlord2.UI
{
    public partial class 提醒Form : FormBase
    {
        private 提醒 entity;
        private bool isNew;//是否新增操作

        public 提醒Form()
        {
            InitializeComponent();
            entity = new 提醒();
            isNew = true;
        }
        public 提醒Form(提醒 entity)
        {
            InitializeComponent();
            this.entity = context.提醒.FirstOrDefault(m => m.ID == entity.ID);
            isNew = false;
        }
        private void 提醒Form_Load(object sender, EventArgs e)
        {
            if (isNew)
            {
                BtnOkAndContinue.Visible = true;//保存并继续按钮可见
            }

            Text = string.Format("提醒 - {0}", isNew ? "新增" : "编辑");
            源房BindingSource.DataSource = 源房.GetYF(context).Include("客房").Execute(System.Data.Objects.MergeOption.AppendOnly);//通过Include预先加载相关客房
            提醒BindingSource.DataSource = entity;
        }

        private void cmb源房_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb源房.SelectedIndex == -1)
            {
                客房BindingSource.DataSource = null;
                return;
            }

            源房 selectedYF = cmb源房.SelectedItem as 源房;
            List<客房> list = selectedYF.客房.ToList();
            list.Insert(0, new 客房() { ID =Guid.Empty, 命名 = "- 无 -" });
            客房BindingSource.DataSource = list;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Close();
        }
    }
}
