using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Landlord2
{
    public partial class Form1 : KryptonForm
    {
        private int _widthLeftRight;
        
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region 左侧自动缩近、扩展
        private void OnLeftRight(object sender, EventArgs e)
        {
            // 暂停界面更新
            kryptonSplitContainer1.SuspendLayout();

            // 正常状态未锁定splitter(用户可以移动)
            if (kryptonSplitContainer1.IsSplitterFixed == false)
            {
                kryptonSplitContainer1.IsSplitterFixed = true;

                _widthLeftRight = kryptonHeaderGroup1.Width;

                int newWidth = kryptonHeaderGroup1.PreferredSize.Height;

                kryptonSplitContainer1.Panel1MinSize = newWidth;
                kryptonSplitContainer1.SplitterDistance = newWidth;

                kryptonHeaderGroup1.HeaderPositionPrimary = VisualOrientation.Right;
                kryptonHeaderGroup1.ButtonSpecs[0].Edge = PaletteRelativeEdgeAlign.Near;
            }
            else
            {
                kryptonSplitContainer1.IsSplitterFixed = false;

                kryptonSplitContainer1.Panel1MinSize = _widthLeftRight;

                kryptonSplitContainer1.SplitterDistance = _widthLeftRight;

                kryptonHeaderGroup1.HeaderPositionPrimary = VisualOrientation.Top;
                kryptonHeaderGroup1.ButtonSpecs[0].Edge = PaletteRelativeEdgeAlign.Far;
            }
            //恢复界面更新
            kryptonSplitContainer1.ResumeLayout();
        } 
        #endregion

        #region 右下侧自动缩放
        private void OnUpDown(object sender, EventArgs e)
        {
            kryptonSplitContainer2.SuspendLayout();

            if (kryptonSplitContainer2.IsSplitterFixed == false)
            {
                kryptonSplitContainer2.IsSplitterFixed = true;
                kryptonSplitContainer2.Panel2Collapsed = true;
            }
            else
            {
                kryptonSplitContainer2.IsSplitterFixed = false;
                kryptonSplitContainer2.Panel2Collapsed = false;
            }

            kryptonSplitContainer2.ResumeLayout();
        } 
        #endregion

        private void kryptonCheckSet1_CheckedButtonChanged(object sender, EventArgs e)
        {
            kryptonHeaderGroup1.ValuesPrimary.Heading = kryptonCheckSet1.CheckedButton.Values.Text;
        }
    }
}
