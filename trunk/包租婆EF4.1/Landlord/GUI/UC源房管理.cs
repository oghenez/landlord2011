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
        public UC源房管理():base(DockStyle.Fill)
        {
            InitializeComponent();
            源房BindingSource.DataSource = Main.context.源房;
        }
    }
}
