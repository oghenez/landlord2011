using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace Landlord.GUI
{
    public partial class Main : RadForm
    {
        public Main()
        {
            InitializeComponent();
            ThemeResolutionService.ApplicationThemeName = "Windows7"; 
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UC源房详细 uc = new UC源房详细();
            splitPanel2.Controls.Add(uc);
        }

        /// <summary>
        /// 载入房源、客源信息到TreeView控件
        /// </summary>
        private void LoadTreeView()
        { 

        }
    }
}
