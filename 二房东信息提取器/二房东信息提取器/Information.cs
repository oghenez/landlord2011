using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace 二房东信息提取器
{
    public partial class Information : Form
    {
        

        public Information()
        {
            InitializeComponent();
        }              

        private void Information_Load(object sender, EventArgs e)
        {  
            customerBindingSource.DataSource = Root.customerList;
        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            customerBindingSource.EndEdit();
            Root.Serialize<BindingList<Customer>>(Root.customerList);
        }

    }
}
