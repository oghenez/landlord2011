using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Data.Objects;

namespace Landlord.GUI
{
    public partial class UC源房详细 : Landlord.GUI.UCBase
    {
        
        private 源房 yf = null;        

        //新增
        public UC源房详细()
        {
            InitializeComponent();
            radButton1.Text = "新 增";
            yf = new 源房() {
                ID = Guid.NewGuid(),//预分配ID
                期始=DateTime.Now,
                期止=DateTime.Now.AddYears(1),
                支付月数=3
            };            
            源房BindingSource.DataSource = yf;
        }

        //修改
        public UC源房详细(源房 old)
        {
            InitializeComponent();
            radButton1.Text = "修 改";
            yf = old;
            源房BindingSource.DataSource = yf;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            
            if (yf.EntityState == EntityState.Modified)//修改
            {
                saveData("修改");
            }
            else if(yf.EntityState == EntityState.Added )//新增
            {
                saveData("新增");
            }
            else if (yf.EntityState == EntityState.Detached)
            {
                Main.context.源房.AddObject(yf);
                saveData("新增");
            }

        }

        private void saveData(string txt)
        {
            try
            {
                int num = Main.context.SaveChanges();
                //mainForm.UpdateStatusStrip(string.Format("成功{0}{1}条源房信息", txt, num));
                //刷新树视图
            }
            catch (OptimisticConcurrencyException)
            {
                Main.context.Refresh(RefreshMode.ClientWins, yf);

                Main.context.SaveChanges();
                //mainForm.UpdateStatusStrip(string.Format("成功处理开放式并发异常，并{0}源房信息", txt));
            }
            catch (Exception ex)
            {
                string msg = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                //mainForm.UpdateStatusStrip(string.Format("{0}源房信息失败：{1}", txt, msg), Color.Red);
            }
        }
    }
}
