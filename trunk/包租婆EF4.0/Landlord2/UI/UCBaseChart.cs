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
    public partial class UCBaseChart : Landlord2.UI.UCBase
    {
        protected MyContext context;
        public UCBaseChart()
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
    }
}
