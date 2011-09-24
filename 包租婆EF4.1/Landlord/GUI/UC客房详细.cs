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
    public partial class UC客房详细 : Landlord.GUI.UCBase
    {
        private 客房 kf = null;       

        //新增
        public UC客房详细( )
        {
            InitializeComponent();
            radButton1.Text = "新 增";
            kf = new 客房() { 
                ID = Guid.NewGuid(),
                期始=DateTime.Now,
                期止=DateTime.Now.AddYears(1),
                支付月数=3
            };
            客房BindingSource.DataSource = kf;
        }

        //修改
        public UC客房详细(客房 old)
        {
            InitializeComponent();
            radButton1.Text = "修 改";
            kf = old;
            客房BindingSource.DataSource = kf;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (kf.EntityState == EntityState.Modified)//修改
            {
                saveData("修改");
            }
            else if (kf.EntityState == EntityState.Added)//新增
            {
                saveData("新增");
            }
            else if (kf.EntityState == EntityState.Detached)
            {
                Main.context.客房.AddObject(kf);
                saveData("新增");
            }
        }
        private void saveData(string txt)
        {
            try
            {
                int num = Main.context.SaveChanges();
                //mainForm.UpdateStatusStrip(string.Format("成功{0}{1}条客房信息", txt, num));
                //刷新树视图
            }
            catch (OptimisticConcurrencyException)
            {
                Main.context.Refresh(RefreshMode.ClientWins, kf);

                Main.context.SaveChanges();
                //mainForm.UpdateStatusStrip(string.Format("成功处理开放式并发异常，并{0}客房信息", txt));
            }
            catch (Exception ex)
            {
                string msg = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                //mainForm.UpdateStatusStrip(string.Format("{0}客房信息失败：{1}", txt, msg), Color.Red);
            }
        }
    }
}
