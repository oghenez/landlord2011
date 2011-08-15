using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Landlord2.Data;

namespace Landlord2.UI
{
    public partial class UC源房操作菜单 : UserControl
    {
        private 源房 yf;
        public UC源房操作菜单()
        {
            InitializeComponent();
            MessageBox.Show("UC源房操作菜单--默认构造函数仅调试使用！");
        }
        public UC源房操作菜单(源房 yf)
        {
            InitializeComponent();
            this.yf = yf;
        }

        private void yfBtnAdd_Click(object sender, EventArgs e)
        {
            //新增源房
            MessageBox.Show("新增源房");
        }

        private void yfBtnDel_Click(object sender, EventArgs e)
        {
            //删除源房
            MessageBox.Show("删除源房");
        }

        private void yfBtnEdit_Click(object sender, EventArgs e)
        {
            //编辑源房
            MessageBox.Show("编辑源房");
        }

        private void yfBtnAddKeFang_Click(object sender, EventArgs e)
        {
            //增加客房
            MessageBox.Show("增加客房");
        }

        private void yfBtnPay_Click(object sender, EventArgs e)
        {
            //缴费
            MessageBox.Show("缴费");
        }

        private void yfBtnPayDetail_Click(object sender, EventArgs e)
        {
            //缴费明细
            MessageBox.Show("缴费明细");
        }

        private void yfBtnSdq_Click(object sender, EventArgs e)
        {
            //抄表
            MessageBox.Show("抄表");
        }

        private void yfBtnSdqDetail_Click(object sender, EventArgs e)
        {
            //抄表明细
            MessageBox.Show("抄表明细");
        }

        private void yfBtnZhuangXiuDetail_Click(object sender, EventArgs e)
        {
            //装修明细
            MessageBox.Show("装修明细");
        }
    }
}
