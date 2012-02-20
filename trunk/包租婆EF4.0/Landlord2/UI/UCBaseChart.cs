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
            this.kryptonPanel1.Controls.Clear();//移除基类Panel的4条边线。
            try
            {
                context = new MyContext();
            }
            catch (Exception)
            {
                //! 窗体设计器初始化时会出问题，真正运行时不会到这里。
            }
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                }                
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
