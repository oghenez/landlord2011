using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Landlord2.Data;

namespace Landlord2.UI
{
    public partial class UC源房详细 : Landlord2.UI.UCBase
    {
        private 源房 yf;
        public UC源房详细()
        {
            InitializeComponent();
            MessageBox.Show("UC源房详细--默认构造函数仅调试使用！");
        }
        public UC源房详细(源房 yf)
        {
            InitializeComponent();
            this.yf = yf;
        }
    }
}
