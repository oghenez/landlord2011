using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Landlord.GUI
{
    public partial class UC源房管理 : UCBase
    {
        public UC源房管理() { InitializeComponent(); }
        public UC源房管理(Main main):base(main,DockStyle.Fill)
        {
            InitializeComponent();            
            源房BindingSource.DataSource = mainForm.context.源房;
        }
    }
}
