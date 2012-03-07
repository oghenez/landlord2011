using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 二房东信息提取器
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

            if (!File.Exists("Customers.xml"))
                Root.customerList = new BindingList<Customer>();
            else
            {
                Root.customerList = Root.Deserialize<BindingList<Customer>>();
            }

        }

        private void tbDragDrop(object sender, DragEventArgs e)
        {
            object obj = e.Data.GetData(DataFormats.Text);
            (sender as TextBox).Text = obj.ToString();
        }

        private void tbDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Author form = new Author())
            {
                form.ShowDialog(this);
            }
            linkLabel1.Text = "采集者：" + Root.AuthorName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Information form = new Information())
            {
                form.ShowDialog(this);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while(string.IsNullOrEmpty(Root.AuthorName))
            {
                MessageBox.Show("请先指定采集者");
                linkLabel1_LinkClicked(null, null);
            }
            //简单校验
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                DialogResult result = MessageBox.Show("存在空值，是否继续？", "空值询问", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (result == System.Windows.Forms.DialogResult.No)
                    return;
            }

            Root.customerList.Add(new Customer()
            {
                Address = textBox3.Text.Trim(),
                Author = Root.AuthorName,
                ModifyTime = DateTime.Now,
                Name = textBox1.Text.Trim(),
                Phone = textBox2.Text.Trim()
            });

            Root.Serialize<BindingList<Customer>>(Root.customerList);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            //校验电话
            var customer = Root.customerList.FirstOrDefault(m => m.Phone == textBox2.Text.Trim());
            if(customer != null)
                errorProvider1.SetError(textBox2, string.Format("{0} {1}\r\n{2} {3}\r\n{4}",
                    customer.Name,customer.Phone,customer.ModifyTime.ToString("yyyy-MM-dd HH:mm:ss"),customer.Author,customer.Address));
            else
                errorProvider1.SetError(textBox2,string.Empty);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            //校验姓名
            var customer = Root.customerList.FirstOrDefault(m => m.Name == textBox1.Text.Trim());
            if (customer != null)
                errorProvider1.SetError(textBox1, string.Format("{0} {1}\r\n{2} {3}\r\n{4}",
                    customer.Name, customer.Phone, customer.ModifyTime.ToString("yyyy-MM-dd HH:mm:ss"), customer.Author, customer.Address));
            else
                errorProvider1.SetError(textBox1, string.Empty);
        }
    }
}
