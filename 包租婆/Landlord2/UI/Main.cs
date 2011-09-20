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
using System.Threading;
using System.Data.Objects;
using System.Data.Entity;
using System.Data.EntityClient;

namespace Landlord2
{
    public partial class Main : KryptonForm
    {
        private int _widthLeftRight, _heightUpDown;
        public Entities context ;

        private UC源房详细 yfUC ;//= new UC源房详细(true) { Dock = DockStyle.Fill };
        private UC客房详细 kfUC ;//= new UC客房详细(true) { Dock = DockStyle.Fill };

        public Main()
        {
            InitializeComponent();

//            #region 调试代码
//#if DEBUG
//            context.ObjectStateManager.ObjectStateManagerChanged += (sender, e) =>
//            {
//                Console.WriteLine(string.Format(
//                "ObjectStateManager.ObjectStateManagerChanged | Action:{0} Object:{1}"
//                , e.Action
//                , e.Element));
//            };
//#endif
//            #endregion

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

        private void Main_Load(object sender, EventArgs e)
        {
            context = new Entities();
            EntityConnection conn = context.Database.Connection as EntityConnection;
            if(conn.State != ConnectionState.Open)
                context.Database.Connection.Open();

            ThreadPool.QueueUserWorkItem(delegate
            {
                LoadTreeView(null);
                DoThreadSafe(delegate { yfUC = new UC源房详细(true) { Dock = DockStyle.Fill }; });
                DoThreadSafe(delegate { kfUC = new UC客房详细(true) { Dock = DockStyle.Fill }; });
            });
            AlarmTimer1.Enabled = true; //-- 测试闪动提醒图标
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            context.Database.Connection.Dispose();
            context.Dispose();
        }
        #region 闪动提醒图标
        private bool flag = false;
        private void AlarmTimer1_Tick(object sender, EventArgs e)
        {
            kryptonHeaderGroup3.ValuesPrimary.Image = (flag) ? Resources.idea_16_dis : Resources.idea_16_hot;
            flag = !flag;
        } 
        #endregion

        //根据数据源，刷新TreeView，并定位到指定对象所对应的节点。（新增、修改、删除等操作后）
        //如果obj传入null，那么如果原来选择的是源房或客房节点，继续选择它。
        public void RefreshAndLocateTree(EntityObject obj)
        {
            if (obj == null && treeView1.SelectedNode != null && treeView1.SelectedNode.Tag != null)
            {
                obj = treeView1.SelectedNode.Tag as EntityObject;//tag只可能是源房或客房实体
            }
            LoadTreeView(obj);
        }
        /// <summary>
        /// 加载源房、客房信息到TreeView控件。
        /// 同时如果传入了EntityObject[例如：某个源房、客房对象]，加载后则选中之。
        /// </summary>
        private void LoadTreeView(EntityObject obj)
        {
            if (context.源房.Count() > 0)
            {
                DoThreadSafe(delegate {
                    treeView1.BeginUpdate();
                    treeView1.Nodes.Clear(); 
                });
                

                TreeNode root1 = new TreeNode("当前源房信息");
                root1.ToolTipText = "当前源房按照签约时间自动排序";
                root1.NodeFont = new System.Drawing.Font("宋体", 10, FontStyle.Bold);
                root1.ImageIndex = 0;
                DoThreadSafe(delegate { treeView1.Nodes.Add(root1); });                
                foreach (var yf in 源房.GetYF_NoHistory())
                    AddYuanFangToTree(root1, yf, false, obj);

                TreeNode root2 = new TreeNode("历史源房信息");
                root2.ToolTipText = "历史源房按照签约时间自动排序";
                root2.NodeFont = new System.Drawing.Font("宋体", 10, FontStyle.Bold);
                root2.ForeColor = Color.DimGray;
                root2.ImageIndex = 1;
                DoThreadSafe(delegate { treeView1.Nodes.Add(root2); });                  
                foreach (var yf in 源房.GetYF_History())
                    AddYuanFangToTree(root2, yf, true, obj);

                DoThreadSafe(delegate {
                    treeView1.ExpandAll();
                    treeView1.EndUpdate();
                });           
            }
            else
            {
                DoThreadSafe(delegate { treeView1.Nodes.Add("当前没有源房、客房信息"); }); 
            }
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
            DoThreadSafe(delegate {
                parent.Nodes.Add(yfNode);
                if (yf == obj)
                    yfNode.TreeView.SelectedNode = yfNode;
            });             

            var kfs = yf.客房;
            foreach (var kf in kfs)
            {
                TreeNode kfNode = new TreeNode();
                kfNode.Text = kf.命名;
                kfNode.Tag = kf;
                if (isHistory)
                    kfNode.ImageIndex = 6;//历史客房
                else
                {
                    if (string.IsNullOrEmpty(kf.租户))
                        kfNode.ImageIndex = 4;//未租4
                    else
                    {
                        kfNode.ImageIndex = 3;//已租3

                        if (kf.期止 < DateTime.Now)//已租，协议到期，请续租或退租
                        {
                            kfNode.Text += "[协议到期]";
                            kfNode.ToolTipText = "协议到期，请[续租]或[退租]。";
                            kfNode.ForeColor = Color.Red;
                        }
                        else if (kf.客房租金明细.Count == 0 || kf.客房租金明细.Max(m => m.止付日期) < DateTime.Now)//已租，协议未到期，逾期交租
                        {
                            kfNode.Text += "[逾期交租]";
                            kfNode.ToolTipText = "逾期交租，请[收租]或[退租]。";
                            kfNode.ForeColor = Color.Magenta;
                        }       
                    }                    
                }
                DoThreadSafe(delegate {
                    yfNode.Nodes.Add(kfNode);
                    if (kf == obj)
                        kfNode.TreeView.SelectedNode = kfNode;
                });   
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
            kryptonHeaderGroup2.SuspendLayout();
            if (entity == null)
            {
                kryptonHeaderGroup2.Panel.Controls.Clear();
                kryptonHeaderGroup2.ValuesPrimary.Heading = " ";//加个空格，避免控件高度自动减少
            }
            
            if (entity is 源房)
            {
                yfUC.源房BindingSource.DataSource = entity;
                yfUC.源房涨租协定BindingSource.DataSource = 源房涨租协定.GetByYFid(((源房)entity).ID).Execute(MergeOption.NoTracking);                    

                if (kryptonHeaderGroup2.Panel.Controls.Count == 0) //初次加载
                {
                    kryptonHeaderGroup2.Panel.Controls.Add(yfUC);
                }
                else if(kryptonHeaderGroup2.Panel.Controls[0] is UC源房详细)//原来加载的是‘源房详细’控件
                {
                    //仅仅更改绑定实体
                }
                else if (kryptonHeaderGroup2.Panel.Controls[0] is UC客房详细)
                {
                    //删除控件
                    kryptonHeaderGroup2.Panel.Controls.RemoveAt(0);
                    //加载
                    kryptonHeaderGroup2.Panel.Controls.Add(yfUC);
                }
                kryptonHeaderGroup2.ValuesPrimary.Heading = string.Format("源房：{0}", (entity as 源房).房名);
            }
            else if (entity is 客房)
            {
                kfUC.客房BindingSource.DataSource = entity;
                kfUC.客房租金明细BindingSource.DataSource = 客房租金明细.GetRentDetails((entity as 客房).ID).Execute(MergeOption.NoTracking);

                if (kryptonHeaderGroup2.Panel.Controls.Count == 0) //初次加载
                {
                    kryptonHeaderGroup2.Panel.Controls.Add(kfUC);
                }
                else if (kryptonHeaderGroup2.Panel.Controls[0] is UC客房详细)
                {
                    //仅仅更改绑定实体
                }
                else if (kryptonHeaderGroup2.Panel.Controls[0] is UC源房详细)
                {
                    //删除控件
                    kryptonHeaderGroup2.Panel.Controls.RemoveAt(0);
                    //加载
                    kryptonHeaderGroup2.Panel.Controls.Add(kfUC);
                }
                kryptonHeaderGroup2.ValuesPrimary.Heading = string.Format("客房：{0} <隶属于：{1}>", (entity as 客房).命名,(entity as 客房).源房.房名) ;
            }
            kryptonHeaderGroup2.ResumeLayout(false);
        }
        #endregion

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.SelectedImageIndex = e.Node.ImageIndex;//不变更选定的树节点图标
            LoadOrRefreshUC(e.Node.Tag);
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //弹出右键菜单

            }
        }

        #region 菜单按钮
        private void yfBtnAdd_Click(object sender, EventArgs e)
        {
            //新增源房
            using (源房Form yF = new 源房Form())
            {
                yF.ShowDialog(this);
            }
        }
        private void yfBtnDel_Click(object sender, EventArgs e)
        {
            //删除源房
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is 源房)
            {
                源房 yf = treeView1.SelectedNode.Tag as 源房;
                string txt = string.Format("确定要删除源房 [{0}] 吗？\r\n（将同时删除此源房下面的所有客房及所有关联的信息）",yf.房名);
                var result = KryptonMessageBox.Show(txt, "源房删除确认", 
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, 
                    MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {
                    context.DeleteObject(yf);
                    string msg;
                    if (Helper.saveData(yf, out msg))
                    {
                        KryptonMessageBox.Show(msg, "成功删除源房");
                        RefreshAndLocateTree(null);
                        LoadOrRefreshUC(null);
                    }
                    else 
                    {
                        KryptonMessageBox.Show(msg, "失败");
                        context.Refresh(System.Data.Objects.RefreshMode.StoreWins, yf);
                    }
                }
            }
        }
        private void yfBtnEdit_Click(object sender, EventArgs e)
        {
            //编辑源房
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is 源房)
            {
                源房 yf = treeView1.SelectedNode.Tag as 源房;
                using (源房Form yF = new 源房Form(yf))
                {
                    yF.ShowDialog(this);
                }
            }
        }

        private void kfBtnAdd_Click(object sender, EventArgs e)
        {
            //新增客房
            客房Form kF = null;
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag != null)
            {
                object entity = treeView1.SelectedNode.Tag;
                if (entity is 源房)
                    kF = new 客房Form((entity as 源房).ID);
                else if (entity is 客房)
                    kF = new 客房Form((entity as 客房).源房ID);
            }
            else
                kF = new 客房Form();
            kF.ShowDialog(this);
            kF.Dispose();
        }
        private void kfBtnDel_Click(object sender, EventArgs e)
        {
            //删除客房
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is 客房)
            {
                客房 kf = treeView1.SelectedNode.Tag as 客房;
                string txt = string.Format("确定要删除客房 [{0}] 吗？\r\n（将同时删除此客房下所有关联的信息）", kf.命名);
                var result = KryptonMessageBox.Show(txt, "客房删除确认",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {
                    context.DeleteObject(kf);
                    string msg;
                    if (Helper.saveData(kf, out msg))
                    {
                        KryptonMessageBox.Show(msg, "成功删除客房");
                        RefreshAndLocateTree(null);
                        LoadOrRefreshUC(null);
                    }
                    else
                    {
                        KryptonMessageBox.Show(msg, "失败");
                        context.Refresh(System.Data.Objects.RefreshMode.StoreWins, kf);
                    }
                }
            }
        }
        private void kfBtnEdit_Click(object sender, EventArgs e)
        {
            //编辑客房
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is 客房)
            {
                客房 kf = treeView1.SelectedNode.Tag as 客房;
                using (客房Form kF = new 客房Form(kf))
                {
                    kF.ShowDialog(this);
                }
            }
        }

        private void yfBtnPay_Click(object sender, EventArgs e)
        {
            //源房缴费
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag != null)
            {
                object entity = treeView1.SelectedNode.Tag;
                Guid yfID = Guid.Empty ;
                if (entity is 源房)
                    yfID = (entity as 源房).ID;
                else if (entity is 客房)
                    yfID = (entity as 客房).源房ID;

                using (源房缴费Form jf = new 源房缴费Form(yfID))
                {
                    jf.ShowDialog(this);
                }
            }
            else
            {
                using (源房缴费Form jf = new 源房缴费Form())
                {
                    jf.ShowDialog(this);
                }
            }            
        }
        private void yfBtnPayDetail_Click(object sender, EventArgs e)
        {
            //源房缴费明细
            using (源房缴费明细Form jF = new 源房缴费明细Form())
            {
                jF.ShowDialog(this);
            }
        }
        private void kfBtnRent_Click(object sender, EventArgs e)
        {
            //出租
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is 客房)
            {
                客房 kf = treeView1.SelectedNode.Tag as 客房;
                if (!string.IsNullOrEmpty(kf.租户))
                    return;

                using (客房出租Form rent = new 客房出租Form(kf))
                {
                    DialogResult result = rent.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        if (KryptonMessageBox.Show("客房已成功出租，是否立即进行首期收租？", "首期收租询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            using (客房收租Form collectRent = new 客房收租Form(kf))
                            {
                                collectRent.ShowDialog(this);
                            } 
                        }
                    }
                }
            }
        }        

        private void kfBtnCollectRent_Click(object sender, EventArgs e)
        {
            //收租
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is 客房)
            {
                客房 kf = treeView1.SelectedNode.Tag as 客房;
                if (string.IsNullOrEmpty(kf.租户))//未租
                    return;
                if (kf.期止 < DateTime.Now)//已租，协议到期，请续租或退租
                {
                    KryptonMessageBox.Show("协议到期，请续租或退租");
                    return;
                }

                using (客房收租Form collectRent = new 客房收租Form(kf))
                {
                    collectRent.ShowDialog(this);
                }
            }
        }        
        private void kfBtnCollectRentDetail_Click(object sender, EventArgs e)
        {
            //收租明细
            using (客房收租明细Form sz = new 客房收租明细Form())
            {
                sz.ShowDialog(this);
            }
        }

        private void kfBtnRentHistory_Click(object sender, EventArgs e)
        {
            //客房出租历史记录
            using (客房出租历史记录Form collectRent = new 客房出租历史记录Form())
            {
                collectRent.ShowDialog(this);
            }
        }
        #endregion














    }
}
