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

namespace Landlord2.UI
{
    public partial class yfForm : KryptonForm
    {
        private 源房 yf;
        private bool isNew;//是否是新增

        /// <summary>
        /// 新增源房、编辑源房面板
        /// </summary>
        /// <param name="yf">yf=null则为新增操作</param>
        public yfForm(源房 yf)
        {
            this.yf = yf;
            InitializeComponent();
        }

        private void YF_Load(object sender, EventArgs e)
        {
            if (yf == null)
            {
                isNew = true;
                Text = "新增源房";
                yf = new 源房();                
            }
            else
            {
                isNew = false;
                Text = "编辑源房";
            }
            uC源房详细1.源房BindingSource.DataSource = yf;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string check = yf.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }
            if (isNew)//新增 
            {
                Main.context.AddTo源房(yf);
                string msg;
                if (Helper.saveData(yf, out msg))
                {
                    KryptonMessageBox.Show(msg, "成功新增源房");
                    (this.Owner as Main).RefreshAndLocateTree(yf);//刷新TreeView，并定位到yf节点。
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg, "失败");
                    Main.context.Detach(yf);
                }
            }
            else //编辑
            {
                //如果编辑状态下，未做任何修改，则直接退出
                if (Main.context.ObjectStateManager.GetObjectStateEntry(yf).State == EntityState.Unchanged)
                {
                    Close(); //如果编辑状态下，未做任何修改，则直接退出
                }
                else
                {
                    string msg;
                    if (Helper.saveData(yf, out msg))
                    {
                        KryptonMessageBox.Show(msg, "成功编辑源房");
                        (this.Owner as Main).RefreshAndLocateTree(yf);//刷新TreeView，并定位到yf节点。
                        Close();
                    }
                    else
                    {
                        KryptonMessageBox.Show(msg, "失败");
                        //Main.context.Refresh(System.Data.Objects.RefreshMode.StoreWins, yf);失败后这里不处理，关闭窗体时处理更改
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void yfForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isNew && Main.context.ObjectStateManager.GetObjectStateEntry(yf).State == EntityState.Modified)
            {
                Main.context.Refresh(System.Data.Objects.RefreshMode.StoreWins, yf);
                Main.context.AcceptAllChanges();
            }
        }
    }
}
