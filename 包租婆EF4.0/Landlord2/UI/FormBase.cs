using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Landlord2.Data;

namespace Landlord2.UI
{
    public partial class FormBase : KryptonForm
    {
        /// <summary>
        /// 每个窗体有一个Context ，基类中Load时初始化，FormClosing中销毁。
        /// </summary>
        protected MyContext context;// = new MyContext();
        public FormBase()
        {
            InitializeComponent();
            try
            {
                context = new MyContext();
            }
            catch (Exception)
            {
                //! 窗体设计器初始化时会出问题，真正运行时不会到这里。
            }
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            
        }

        private void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            context.Dispose();
        }
    }
}
