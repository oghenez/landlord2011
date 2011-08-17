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
        }
        public UC源房详细(源房 yf)
        {
            InitializeComponent();
            this.yf = yf;
            源房BindingSource.DataSource = yf;
            
        }
    }
}
