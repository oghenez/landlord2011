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
        public UC源房详细() { InitializeComponent(); }
        //新增
        public UC源房详细(Main main)
            : base(main, DockStyle.None)
        {
            InitializeComponent();
            radButton1.Text = "新 增";
            yf = new 源房();
            yf.ID = -1;//预分配ID
            源房BindingSource.DataSource = yf;
        }
        //修改
        public UC源房详细(源房 old, Main main)
            : base(main, DockStyle.None)
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
            else if(yf.EntityState == EntityState.Added)//新增
            {
                saveData("新增");
            }
        }

        private void saveData(string txt)
        {
            try
            {
                int num = mainForm.context.SaveChanges();
                mainForm.UpdateStatusStrip(string.Format("成功{0}{1}条源房信息",txt,num));
            }
            catch (OptimisticConcurrencyException)
            {
                mainForm.context.Refresh(RefreshMode.ClientWins, yf);

                mainForm.context.SaveChanges();
                mainForm.UpdateStatusStrip(string.Format("成功处理开放式并发异常，并{0}源房信息",txt));
            }
            catch (Exception ex)
            {
                mainForm.UpdateStatusStrip(string.Format("{0}源房信息失败：{1}",txt, ex.Message),Color.Red);
            }
        }
    }
}
