using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Landlord2.Data;
using System.Data.Objects;

namespace Landlord2.UI
{
    public partial class 源房Form : FormBase
    {
        private 源房 yf;
        private bool isNew;//是否是新增

        /// <summary>
        /// 新增源房 
        /// </summary>
        public 源房Form()
        {
            InitializeComponent();
            isNew = true;
            this.yf = new 源房();
            context.源房.AddObject(yf);
        }
        /// <summary>
        /// 编辑源房 
        /// </summary>
        public 源房Form(Guid yfID)
        {
            InitializeComponent();
            isNew = false;
            this.yf = context.源房.FirstOrDefault(m=>m.ID == yfID);
        }

        private void YF_Load(object sender, EventArgs e)
        {
            Text = string.Format("{0}源房", isNew ? "新增" : "编辑");

            uC源房详细1.源房BindingSource.DataSource = yf;
            uC源房详细1.源房涨租协定BindingSource.DataSource = 源房涨租协定.GetByYFid(context, yf.ID).Execute(MergeOption.AppendOnly);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            uC源房详细1.源房BindingSource.EndEdit();
            uC源房详细1.源房涨租协定BindingSource.EndEdit();

            string check = yf.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }
            if (isNew)//新增 
            {                
                string msg;
                if (Helper.saveData(context, yf, out msg))
                {
                    KryptonMessageBox.Show(msg, "成功新增源房");
                    if (this.Owner is Main)
                        (this.Owner as Main).RefreshAndLocateTree(yf);//刷新TreeView，并定位到yf节点。
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg, "失败");
                }
            }
            else //编辑
            {
                //如果编辑状态下，未做任何修改，则直接退出
                if (context.ObjectStateManager.GetObjectStateEntry(yf).State == EntityState.Unchanged)
                {
                    Close(); //如果编辑状态下，未做任何修改，则直接退出
                }
                else
                {
                    string msg;
                    if (Helper.saveData(context, yf, out msg))
                    {
                        KryptonMessageBox.Show(msg, "成功编辑源房");
                        if (this.Owner is Main)
                            (this.Owner as Main).RefreshAndLocateTree(yf);//刷新TreeView，并定位到yf节点。
                        Close();
                    }
                    else
                    {
                        KryptonMessageBox.Show(msg, "失败");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            Close();
        }

    }
}
