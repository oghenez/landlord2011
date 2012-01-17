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
        private double?[] nearestVal;//最近一次抄表值，里面有3个值，对应水电气
        private bool IsFirstLoad;//是否初次加载，优化初次启动时间，避免多次触发最近抄表值查询
        public 源房抄表Form()//新增
        {
            InitializeComponent();
            entity = new 源房抄表();
            isNew = true;
            IsFirstLoad = true;
        }
        public 源房抄表Form(源房抄表 entity)//编辑
        {
            InitializeComponent();
            this.entity = context.源房抄表.FirstOrDefault(m => m.ID == entity.ID);
            isNew = false;
            IsFirstLoad = true;
        }
                
        private void 源房抄表Form_Load(object sender, EventArgs e)
        {
            //手动调整TextBox双向绑定中Parse过程，允许Null值的存入
            ktb水止码.DataBindings["Text"].Parse += new ConvertEventHandler(Nullable_Parse);
            ktb电止码.DataBindings["Text"].Parse += new ConvertEventHandler(Nullable_Parse);
            ktb气止码.DataBindings["Text"].Parse += new ConvertEventHandler(Nullable_Parse);
            ktb水余额.DataBindings["Text"].Parse += new ConvertEventHandler(Nullable_Parse);
            ktb电余额.DataBindings["Text"].Parse += new ConvertEventHandler(Nullable_Parse);

            Text = string.Format("源房抄表 - {0}", isNew ? "新增" : "编辑");
            源房BindingSource.DataSource = 源房.GetYF(context).Execute(System.Data.Objects.MergeOption.NoTracking);
            源房抄表BindingSource.DataSource = entity;

            IsFirstLoad = false;//第一次加载结束
        }

        void Nullable_Parse(object sender, ConvertEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Value.ToString()))
                e.Value = null;
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

            //对比最近水电气抄表值
            StringBuilder sbMsg = new StringBuilder();
            if (nearestVal[0].HasValue && entity.水止码 < nearestVal[0].Value)
                sbMsg.Append("水止码小于上次抄表值，请确认！" + Environment.NewLine);
            if (nearestVal[1].HasValue && entity.电止码 < nearestVal[1].Value)
                sbMsg.Append("电止码小于上次抄表值，请确认！" + Environment.NewLine);
            if (nearestVal[2].HasValue && entity.气表剩余字数 > nearestVal[2].Value)
                sbMsg.Append("气止码大于上次抄表值，请确认！" + Environment.NewLine);

            if (sbMsg.Length > 0)
            {
                var result = KryptonMessageBox.Show(sbMsg.ToString(), "请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Cancel)
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

        private void buttonSpecAny_Close_Click(object sender, EventArgs e)
        {
            ButtonSpecAny bsa = sender as ButtonSpecAny;
            KryptonTextBox tb = bsa.Owner as KryptonTextBox;
            tb.Text = null;
        }
        
        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kryptonComboBox1.SelectedValue == null)
                return;

            nearestVal = 源房抄表.GetNearestValue(context, (Guid)kryptonComboBox1.SelectedValue,entity.抄表时间);
            kryptonLabel1.Values.ExtraText = string.Format("【水：{0}】【电：{1}】【气：{2}】",
                        nearestVal[0].HasValue ? nearestVal[0].ToString() : "无",
                        nearestVal[1].HasValue ? nearestVal[1].ToString() : "无",
                        nearestVal[2].HasValue ? nearestVal[2].ToString() : "无");

        }

        private void kryptonDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!IsFirstLoad && entity.源房ID != Guid.Empty)
            {
                nearestVal = 源房抄表.GetNearestValue(context, entity.源房ID, kryptonDateTimePicker1.Value);
                kryptonLabel1.Values.ExtraText = string.Format("【水：{0}】【电：{1}】【气：{2}】",
                            nearestVal[0].HasValue ? nearestVal[0].ToString() : "无",
                            nearestVal[1].HasValue ? nearestVal[1].ToString() : "无",
                            nearestVal[2].HasValue ? nearestVal[2].ToString() : "无");
            }
        }
    }
}
