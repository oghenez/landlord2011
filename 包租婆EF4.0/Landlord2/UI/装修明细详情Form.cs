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
    public partial class 装修明细详情Form : FormBase
    {
        private 装修明细 entity;
        private bool isNew;//是否新增操作

        public 装修明细详情Form()//新增操作
        {
            InitializeComponent();
            entity = new 装修明细();
            isNew = true;
        }

        public 装修明细详情Form( 装修明细 entity)//编辑操作
        {
            InitializeComponent();
            this.entity = context.装修明细.FirstOrDefault(m => m.ID == entity.ID);            
            isNew = false;
        }
        public void Refresh装修分类()
        {
            装修分类BindingSource.DataSource = context.装修分类.Execute(System.Data.Objects.MergeOption.NoTracking);
        }
        private void 装修明细详情Form_Load(object sender, EventArgs e)
        {
            if (isNew)
            {
                BtnOkAndContinue.Visible = true;//保存并继续按钮可见
            }

            Text = string.Format("装修明细详情 - {0}", isNew ? "新增" : "编辑");
            Refresh装修分类();
            源房BindingSource.DataSource = 源房.GetYF(context).Execute(System.Data.Objects.MergeOption.NoTracking);
            装修明细BindingSource.DataSource = entity;
        }

        private void btn装修分类_Click(object sender, EventArgs e)
        {
            //装修分类
            using (装修分类Form decorate = new 装修分类Form())
            {
                DialogResult result = decorate.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Refresh装修分类();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            装修明细BindingSource.EndEdit();

            string check = entity.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }
            if (isNew)//新增
            {
                context.装修明细.AddObject(entity);
                string msg;
                if (Helper.saveData(context, entity, out msg))
                {
                    KryptonMessageBox.Show(msg, "成功新增装修明细");
                    if (this.Owner is 装修明细Form)
                        (this.Owner as 装修明细Form).RefreshAndLocate装修明细(entity.ID);
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg, "失败");
                    context.装修明细.DeleteObject(entity);
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
                        KryptonMessageBox.Show(msg, "成功编辑装修明细");
                        if (this.Owner is 装修明细Form)
                            (this.Owner as 装修明细Form).RefreshAndLocate装修明细(entity.ID);
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
            装修明细BindingSource.EndEdit();
            string check = entity.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }
#if DEBUG
            System.Diagnostics.Debug.Assert(isNew);//只有新增状态才有此按钮
#endif
            context.装修明细.AddObject(entity);
            string msg;
            if (Helper.saveData(context, entity, out msg))
            {
                KryptonMessageBox.Show("成功新增装修明细，您可以继续添加。", "成功新增装修明细");
                if (this.Owner is 装修明细Form)
                    (this.Owner as 装修明细Form).RefreshAndLocate装修明细(entity.ID);

                装修明细 old = entity;
                entity = new 装修明细()
                {
                    日期 = old.日期,
                    源房ID = old.源房ID,
                    购买地点 = old.购买地点,
                    装修分类 = old.装修分类,
                    备注 = old.备注
                };
                装修明细BindingSource.DataSource = entity;
            }
            else
            {
                KryptonMessageBox.Show(msg, "失败");
                context.装修明细.DeleteObject(entity);
            }
        }

        /// <summary>
        /// 计算小计金额
        /// </summary>
        private void Caculate()
        {
            decimal sum = kryptonNumericUpDown1.Value * kryptonNumericUpDown2.Value;
            lbl小计.Text = decimal.Round(sum, 2).ToString("F2");
        }

        private void kryptonNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Caculate();
        }


    }
}
