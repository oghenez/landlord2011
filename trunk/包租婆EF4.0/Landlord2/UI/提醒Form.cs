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
            提醒BindingSource.EndEdit();

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
                context.提醒.AddObject(entity);
                string msg;
                if (Helper.saveData(context, entity, out msg))
                {
                    KryptonMessageBox.Show(msg, "成功新增提醒");
                    if (this.Owner is Main)
                    {
                        (this.Owner as Main).RefreshCustomAlarmData();
                    }
                    else if (this.Owner is 提醒管理Form)
                    {
                        (this.Owner as 提醒管理Form).RefreshAndLocate提醒(entity.ID);
                        (this.Owner.Owner as Main).RefreshCustomAlarmData();
                    }
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg, "失败");
                    context.提醒.DeleteObject(entity);
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
                        KryptonMessageBox.Show(msg, "成功编辑提醒");
                        if (this.Owner is Main)
                        {
                            (this.Owner as Main).RefreshCustomAlarmData();
                        }
                        else if (this.Owner is 提醒管理Form)
                        {
                            (this.Owner as 提醒管理Form).RefreshAndLocate提醒(entity.ID);
                            (this.Owner.Owner as Main).RefreshCustomAlarmData();
                        }
                        Close();
                    }
                    else
                    {
                        KryptonMessageBox.Show(msg, "失败");
                    }
                }
            }
        }

        private void BtnOkAndContinue_Click(object sender, EventArgs e)
        {
            提醒BindingSource.EndEdit();

            if (entity.客房ID == Guid.Empty)//手动转换
                entity.客房ID = null;

            string check = entity.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;            
            }
#if DEBUG
            System.Diagnostics.Debug.Assert(isNew);//只有新增状态才有此按钮
#endif
            context.提醒.AddObject(entity);
            string msg;
            if (Helper.saveData(context, entity, out msg))
            {
                KryptonMessageBox.Show("成功新增提醒，您可以继续添加。", "成功新增提醒");
                if (this.Owner is Main)
                {
                    (this.Owner as Main).RefreshCustomAlarmData();
                }
                else if (this.Owner is 提醒管理Form)
                {
                    (this.Owner as 提醒管理Form).RefreshAndLocate提醒(entity.ID);
                    (this.Owner.Owner as Main).RefreshCustomAlarmData();
                }

                提醒 old = entity;
                entity = new 提醒()
                {
                    客房ID = old.客房ID,
                    源房ID = old.源房ID,
                    提醒时间 = old.提醒时间
                };
                提醒BindingSource.DataSource = entity;
            }
            else
            {
                KryptonMessageBox.Show(msg, "失败");
                context.提醒.DeleteObject(entity);
            }
        }
    }
}
