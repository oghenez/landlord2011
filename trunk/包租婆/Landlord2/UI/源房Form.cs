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
using System.ComponentModel.DataAnnotations;

namespace Landlord2.UI
{
    public partial class 源房Form : FormBase
    {
        private SourceRoom yf;
        private bool isNew;//是否是新增

        /// <summary>
        /// 新增源房 
        /// </summary>
        public 源房Form()
        {
            InitializeComponent();
            isNew = true;
            this.yf = SourceRoom.MyCreate();
            context.SourceRoom.Add(yf);
        }
        /// <summary>
        /// 编辑源房 
        /// </summary>
        public 源房Form(SourceRoom yf)
        {
            InitializeComponent();
            isNew = false;
            this.yf = yf;
        }

        private void YF_Load(object sender, EventArgs e)
        {
            Text = string.Format("{0}源房", isNew ? "新增" : "编辑");

            uC源房详细1.源房BindingSource.DataSource = yf;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Validate();

            string check = Helper.ValidationResult2String(context.GetValidationErrors());
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }
            if (isNew)//新增 
            {                
                string msg;
                if (Helper.saveData(context,yf, out msg))
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
                if (context.Entry(yf).State == EntityState.Unchanged)
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
