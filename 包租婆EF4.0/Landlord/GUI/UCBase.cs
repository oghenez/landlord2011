using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Landlord.GUI
{
    public partial class UCBase : UserControl
    {
        public UCBase()
        {
            InitializeComponent();
            Dock = DockStyle.None;                     
        }
        public UCBase(DockStyle ds)
        {
            InitializeComponent();           
            Dock = ds;
        }      

    }

}
