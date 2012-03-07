using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 二房东信息提取器
{
    public partial class Author : Form
    {
        public Author()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Root.AuthorName = textBox1.Text.Trim();
            Close();
        }

        private void Author_Load(object sender, EventArgs e)
        {
            textBox1.Text = Root.AuthorName;
        }
    }
}
