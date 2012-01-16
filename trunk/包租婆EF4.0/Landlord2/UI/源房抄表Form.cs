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
    public partial class 源房抄表Form : FormBase
    {
        private 源房抄表 entity;
        private bool isNew;//是否新增操作

        public 源房抄表Form()//新增
        {
            InitializeComponent();
            entity = new 源房抄表();
            isNew = true;
        }
        public 源房抄表Form(源房抄表 entity)//编辑
        {
            InitializeComponent();
            this.entity = context.源房抄表.FirstOrDefault(m => m.ID == entity.ID);
            isNew = false;
        }
                
        private void 源房抄表Form_Load(object sender, EventArgs e)
        {
            Text = string.Format("源房抄表 - {0}", isNew ? "新增" : "编辑");
            源房BindingSource.DataSource = 源房.GetYF(context).Execute(System.Data.Objects.MergeOption.NoTracking);
            源房抄表BindingSource.DataSource = entity;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            源房抄表BindingSource.EndEdit();

            string check = entity.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }
            if (isNew)//新增
            {
                context.源房抄表.AddObject(entity);
                string msg;
                if (Helper.saveData(context, entity, out msg))
                {
                    KryptonMessageBox.Show(msg, "成功新增源房抄表");
                    if (this.Owner is 源房抄表明细Form)
                        (this.Owner as 源房抄表明细Form).RefreshAndLocate源房抄表(entity.ID);
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg, "失败");
                    context.源房抄表.DeleteObject(entity);
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
                        KryptonMessageBox.Show(msg, "成功编辑源房抄表");
                        if (this.Owner is 源房抄表明细Form)
                            (this.Owner as 源房抄表明细Form).RefreshAndLocate源房抄表(entity.ID);
                        Close();
                    }
                    else
                    {
                        KryptonMessageBox.Show(msg, "失败");
                    }
                }
            }
        }

        private void Number_Validating(object sender, CancelEventArgs e)
        {
            KryptonTextBox tb = sender as KryptonTextBox;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = null;
            }
        }

    }
}
