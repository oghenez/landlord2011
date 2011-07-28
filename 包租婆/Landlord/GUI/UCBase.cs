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
        public Main mainForm;
        private DockStyle dockStyle;
        public UCBase() { InitializeComponent(); }
        public UCBase(Main main ,DockStyle ds)
        {
            InitializeComponent();
            mainForm = main;
            dockStyle = ds;            
            main.Layout += new LayoutEventHandler(main_Layout);
            
        }

        public void main_Layout(object sender, LayoutEventArgs e)
        {
            if (dockStyle == DockStyle.None)
            {
                if (Parent == null) return;
                SetBounds((Parent.Width - this.Width) / 2, (Parent.Height - this.Height) / 2, this.Width, this.Height);
            }
            else if (dockStyle == DockStyle.Fill)
            {
                this.Dock = DockStyle.Fill;
            }
        }
    }
}
