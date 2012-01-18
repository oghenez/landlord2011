using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Landlord2.Data;
using ComponentFactory.Krypton.Toolkit;

namespace Landlord2.UI
{
    public partial class 日常损耗Form : FormBase
    {
        private 日常损耗 entity;
        private bool isNew;//是否新增操作

        public 日常损耗Form()
        {
            InitializeComponent();
            entity = new 日常损耗();
            isNew = true;
        }
        public 日常损耗Form(日常损耗 entity)
        {
            InitializeComponent();
            this.entity = context.日常损耗.FirstOrDefault(m => m.ID == entity.ID);
            isNew = false;
        }
        private void 日常损耗Form_Load(object sender, EventArgs e)
        {
            Text = string.Format("日常损耗 - {0}", isNew ? "新增" : "编辑");
            源房BindingSource.DataSource = 源房.GetYF(context).Include("客房").Execute(System.Data.Objects.MergeOption.NoTracking);//通过Include预先加载相关客房
            日常损耗BindingSource.DataSource = entity;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 源房BindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (源房BindingSource.Current == null)
                return;

            源房 selectedYF = 源房BindingSource.Current as 源房;
            List<客房> list = selectedYF.客房.ToList();
            list.Insert(0, new 客房() { ID = Guid.Empty, 命名 = "- 无 -" });
            客房BindingSource.DataSource = list;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            日常损耗BindingSource.EndEdit();

            if (entity.客房ID == Guid.Empty)//手动转换
                entity.客房ID = null;

            string check = entity.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }
            if (isNew)//新增
            {
                context.日常损耗.AddObject(entity);
                string msg;
                if (Helper.saveData(context, entity, out msg))
                {
                    KryptonMessageBox.Show(msg, "成功新增日常损耗");
                    if (this.Owner is 日常损耗管理Form)
                        (this.Owner as 日常损耗管理Form).RefreshAndLocate日常损耗(entity.ID);
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg, "失败");
                    context.日常损耗.DeleteObject(entity);
                }
            }
            else//编辑
            {
                if (context.ObjectStateManager.GetObjectStateEntry(entity).State == EntityState.Unchanged)
                {
                    Close();//如果编辑状态下，未做任何修改，则直接退出
                }
                else
                {
                    string msg;
                    if (Helper.saveData(context, entity, out msg))
                    {
                        KryptonMessageBox.Show(msg, "成功编辑日常损耗");
                        if (this.Owner is 日常损耗管理Form)
                            (this.Owner as 日常损耗管理Form).RefreshAndLocate日常损耗(entity.ID);
                        Close();
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
