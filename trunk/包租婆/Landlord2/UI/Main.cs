using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Landlord2.UI;

namespace Landlord2
{
    public partial class Main : KryptonForm
    {
        private int _widthLeftRight;
        
        public Main()
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

        #region 载入用户控件
        private void LoadUC(UCBase uc, string text)
        {
            ////载入控件时，测试检测是否有未保存数据
            //var changes = context.ObjectStateManager.GetObjectStateEntries(
            //    EntityState.Added |
            //    EntityState.Deleted |
            //    //EntityState.Detached |
            //    EntityState.Modified);
            //if (changes != null)
            //    MessageBox.Show("[测试] 当前存在数据修改。");

            kryptonHeaderGroup2.Panel.Controls.Clear();
            kryptonHeaderGroup2.ValuesPrimary.Heading = text;
            kryptonHeaderGroup2.Panel.Controls.Add(uc);
        }
        #endregion
        private void 新建NToolStripButton_Click(object sender, EventArgs e)
        {
            //测试用.....
            UC源房详细 uc = new UC源房详细();
            LoadUC(uc, "测试源房详细。。。");
        }
    }
}
