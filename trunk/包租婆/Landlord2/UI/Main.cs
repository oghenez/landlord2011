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
using System.Data.Objects.DataClasses;

namespace Landlord2
{
    public partial class Main : KryptonForm
    {
        private int _widthLeftRight, _heightUpDown;
        public static Entities context;
        private UC源房详细 yfUC = new UC源房详细(true) { Dock = DockStyle.Fill };

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
            LoadTreeView(null);
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

        //根据数据源，刷新数，并定位到指定对象所对应的节点。（新增、修改、删除等操作后）
        public void RefreshAndLocateTree(EntityObject obj)
        {
            LoadTreeView(obj);
        }
        /// <summary>
        /// 加载源房、客房信息到TreeView控件。
        /// 同时如果传入了EntityObject[例如：某个源房、客房对象]，加载后则选中之。
        /// </summary>
        private void LoadTreeView(EntityObject obj)
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            if (context.源房.Count() > 0)
            {
                var yfGroups = from o in context.源房
                               orderby o.源房涨租协定.Max(m => m.期止)
                               group o by o.源房涨租协定.Max(m => m.期止) > DateTime.Now into temp
                               orderby temp.Key descending
                               select temp;
                foreach (var yfGroup in yfGroups)
                {
                    if (yfGroup.Key == true) // 满足 '期止 > DateTime.Now'
                    {
                        TreeNode root1 = new TreeNode("当前源房信息");
                        root1.NodeFont = new System.Drawing.Font("宋体", 10, FontStyle.Bold);
                        root1.ImageIndex = 0;
                        treeView1.Nodes.Add(root1);
                        foreach (var yf in yfGroup)
                            AddYuanFangToTree(root1, yf,false,obj);

                        root1.ExpandAll();
                    }
                    else
                    {
                        TreeNode root2 = new TreeNode("历史源房信息");
                        root2.NodeFont = new System.Drawing.Font("宋体", 10, FontStyle.Bold);
                        root2.ForeColor = Color.DimGray;
                        root2.ImageIndex = 1;
                        treeView1.Nodes.Add(root2);
                        foreach (var yf in yfGroup)
                            AddYuanFangToTree(root2, yf,true,obj);
                    }
                }
            }
            else
            {
                treeView1.Nodes.Add("当前没有源房、客房信息");
            }
            treeView1.EndUpdate();
        }
        /// <summary>
        /// 加入一个树节点
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="yf"></param>
        /// <param name="isHistory">是否是历史源房（历史源房下的客房不管到期与否都置灰）</param>
        private void AddYuanFangToTree(TreeNode parent, 源房 yf, bool isHistory,EntityObject obj)
        {
            TreeNode yfNode = new TreeNode();
            yfNode.Text = yf.房名;
            yfNode.Tag = yf;
            yfNode.ImageIndex = isHistory ? 5 : 2;//历史源房5：当前有效源房2
            parent.Nodes.Add(yfNode);
            if (yf == obj)
                yfNode.TreeView.SelectedNode = yfNode ;

            var kfs = yf.客房;
            foreach (var kf in kfs)
            {
                TreeNode kfNode = new TreeNode();
                kfNode.Text = kf.命名;
                kfNode.Tag = kf;
                if (isHistory)
                    kfNode.ImageIndex = 6;//历史客房
                else
                    kfNode.ImageIndex = (kf.期止 < DateTime.Now) ? 4 : 3;//已租3：未租4
                yfNode.Nodes.Add(kfNode);
                if (kf == obj)
                    kfNode.TreeView.SelectedNode = kfNode;
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

        #region 加载或刷新用户控件（例如：上次和当前都是点击的‘源房’，那么仅仅刷新而不重复加载）
        private void LoadOrRefreshUC(object entity)
        {
            if (entity == null)
                return;
            
            //这里直接丢弃更改，因为加载后的

            if (entity is 源房)
            {
                if (kryptonHeaderGroup2.Panel.Controls.Count > 0)
                { }
                else
                {
                    yfUC.源房BindingSource.DataSource = entity;
                    kryptonHeaderGroup2.Panel.Controls.Add(yfUC);
                }
            }
            else if (entity is 客房)
            { }


        }
        #endregion
        //private void 新建NToolStripButton_Click(object sender, EventArgs e)
        //{
        //    //测试用.....
        //    UC源房操作菜单 ucc = new UC源房操作菜单(); ucc.Dock = DockStyle.Top;
        //    kryptonHeaderGroup2.Panel.Controls.Add(ucc);
        //    UC源房详细 uc = new UC源房详细();            
        //    LoadUC(uc, "测试源房详细。。。");

        //}

        #region 使加载的控件居中
        private void kryptonHeaderGroup2_Panel_Layout(object sender, LayoutEventArgs e)
        {
            switch (kryptonHeaderGroup2.Panel.Controls.Count)
            {
                case 0:
                    break;
                case 1://唯一加载控件
                    {
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
                    break;
                case 2://2个控件，第一个为菜单，第二个才是需要调整的
                    {
                        var control0 = kryptonHeaderGroup2.Panel.Controls[0];
                        var control1 = kryptonHeaderGroup2.Panel.Controls[1];
                        if (control1.Dock != DockStyle.Fill)
                        {
                            int x = (kryptonHeaderGroup2.Panel.Width - control1.Width) / 2;
                            int y = (kryptonHeaderGroup2.Panel.Height - control1.Height - control0.Height) / 2;
                            x = (x > 0) ? x : 0;
                            y = (y > 0) ? y : 0;
                            control1.SetBounds(x, y + control0.Height, control1.Width, control1.Height);
                        }
                    }
                    break;
                default:
                    {
                        KryptonMessageBox.Show("超过2个控件的加载");
                    }
                    break;
            }            
        } 
        #endregion

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    {
                        LoadOrRefreshUC(e.Node.Tag);
                        //else if (e.Node.Tag is 源房)
                        //{
                        //    //源房 yf = e.Node.Tag as 源房;
                        //    //UC源房详细 uc = new UC源房详细();
                        //    //LoadOrRefreshUC(uc, "源房：" + yf.房名);
                        //}
                        //else if (e.Node.Tag is 客房)
                        //{
                        //    //客房 kf = e.Node.Tag as 客房;
                        //    //UC客房详细 uc = new UC客房详细(kf);
                        //    //LoadUC(uc, "客房：" + kf.命名);
                        //}
                    }
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    { }
                    break;
                default:
                    break;
            }
        }

        #region 菜单按钮
        private void yfBtnAdd_Click(object sender, EventArgs e)
        {
            //新增源房
            yfForm yF = new yfForm(null);
            yF.ShowDialog(this);
        } 
        #endregion

    }
}
