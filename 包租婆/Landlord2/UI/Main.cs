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
using Landlord2.Data;
using Landlord2.Properties;

namespace Landlord2
{
    public partial class Main : KryptonForm
    {
        private int _widthLeftRight, _heightUpDown;
        public static Entities context;     
        public Main()
        {
            InitializeComponent();
            context = new Entities(Helper.CreateConnectString());
        }
        #region 线程安全的访问UI控件的方法

        public void DoThreadSafe(MethodInvoker function)
        {
            if (function == null) return;
            if (InvokeRequired) //UI以外的线程调用
                Invoke(function);
            else
                function();
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            AlarmTimer1.Enabled = true; //-- 测试闪动提醒图标
        }

        #region 闪动提醒图标
        private bool flag = false;
        private void AlarmTimer1_Tick(object sender, EventArgs e)
        {
            kryptonHeaderGroup3.ValuesPrimary.Image = (flag) ? Resources.idea_16_dis : Resources.idea_16_hot;
            flag = !flag;
        } 
        #endregion

        /// <summary>
        /// 源房、客房信息到TreeView控件
        /// </summary>
        private void LoadTreeView()
        {
            if (context.源房.Count() == 0)
            {
                treeView1.Nodes.Add("当前没有源房、客房信息");
                return;
            }
            var yfGroups = from o in context.源房
                           orderby o.源房涨租协定.Max(m=>m.期止)
                           group o by o.源房涨租协定.Max(m => m.期止) > DateTime.Now into temp
                           orderby temp.Key descending
                           select temp;
            foreach (var yfGroup in yfGroups)
            {
                if (yfGroup.Key == true) // 满足 '期止 > DateTime.Now'
                {
                    TreeNode root1 = new TreeNode("当前源房信息");
                    treeView1.Nodes.Add(root1);
                    foreach (var yf in yfGroup)
                        AddYuanFangToTree(root1, yf);

                    root1.ExpandAll();
                }
                else
                {
                    TreeNode root2 = new TreeNode("历史源房信息");
                    treeView1.Nodes.Add(root2);
                    foreach (var yf in yfGroup)
                        AddYuanFangToTree(root2, yf);
                }
            }
        }
        /// <summary>
        /// 加入一个树节点
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="yf"></param>
        private void AddYuanFangToTree(TreeNode parent, 源房 yf)
        {
            TreeNode yfNode = new TreeNode();
            yfNode.Text = yf.房名;
            yfNode.Tag = yf;
            //yfNode.Image = Resources.house_24;
            parent.Nodes.Add(yfNode);

            var kfs = yf.客房;
            foreach (var kf in kfs)
            {
                TreeNode kfNode = new TreeNode();
                kfNode.Text = kf.命名;
                kfNode.Tag = kf;
                //kfNode.Image = (kf.期止 < DateTime.Now) ? Resources.house_2__2_ : Resources.House__6_;/*是否到期*/
                yfNode.Nodes.Add(kfNode);
            }
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

                _heightUpDown = kryptonHeaderGroup3.Height;

                int newHeight = kryptonHeaderGroup3.PreferredSize.Height;

                kryptonSplitContainer2.Panel2MinSize = newHeight;
                kryptonSplitContainer2.SplitterDistance = kryptonSplitContainer2.Height;

                //收缩后按钮不可用
                foreach (var btn in kryptonHeaderGroup3.ButtonSpecs)
                {
                    if(!string.IsNullOrEmpty(btn.Text))//除去扩展按钮<其按钮没Text>
                        btn.Enabled = ButtonEnabled.False;
                }
            }
            else
            {
                kryptonSplitContainer2.IsSplitterFixed = false;

                kryptonSplitContainer2.Panel2MinSize = _heightUpDown;

                kryptonSplitContainer2.SplitterDistance = kryptonSplitContainer2.Height - _heightUpDown - kryptonSplitContainer2.SplitterWidth;

                //还原后按钮可用
                foreach (var btn in kryptonHeaderGroup3.ButtonSpecs)
                {
                    if (!string.IsNullOrEmpty(btn.Text))//除去扩展按钮<其按钮没Text>
                        btn.Enabled = ButtonEnabled.True;
                }
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
            //uc.Dock = DockStyle.Fill;
            LoadUC(uc, "测试源房详细。。。");
        }

        #region 使加载的控件居中
        private void kryptonHeaderGroup2_Panel_Layout(object sender, LayoutEventArgs e)
        {
            if (kryptonHeaderGroup2.Panel.Controls.Count == 0)
                return;
            var control = kryptonHeaderGroup2.Panel.Controls[0];
            if (control.Dock != DockStyle.Fill)
            {
                int x = (kryptonHeaderGroup2.Panel.Width - control.Width) / 2;
                int y = (kryptonHeaderGroup2.Panel.Height - control.Height) / 2;
                x = (x > 0) ? x : 0;
                y = (y > 0) ? y : 0;
                control.SetBounds(x, y, control.Width, control.Height);
            }
        } 
        #endregion

    }
}
