using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Landlord2.Data;
using System.Data.Objects;

namespace Landlord2.UI
{
    public partial class Form1 : Form
    {
        MyContext context = new MyContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            客房 kf = 客房BindingSource.Current as 客房;
            if (kf != null)
            {
                MyContext context2 = new MyContext();
                客房 kf2 =  context2.GetObjectByKey(kf.EntityKey) as 客房;
                context2.客房.DeleteObject(kf2);
                context2.SaveChanges();

                源房BindingSource.DataSource = context.源房.Execute(MergeOption.NoTracking);

                
            }
            bool kkk = ((源房)源房BindingSource.Current).客房.IsLoaded;
            MessageBox.Show(context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified| EntityState.Unchanged | EntityState.Added | EntityState.Deleted).Count().ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            源房BindingSource.DataSource = context.源房.Execute(MergeOption.NoTracking);
            //var kkk = context.客房.Execute(MergeOption.AppendOnly);
            //MessageBox.Show(context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified | EntityState.Unchanged | EntityState.Added | EntityState.Deleted).Count().ToString());

        }
    }
}
