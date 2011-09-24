using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Landlord2.Data;
using System.Threading;

namespace Landlord2.UI
{
    /// <summary>
    /// 根据不同调用情况智能筛选
    /// </summary>
    public enum 客房筛选
    {
        客房出租,
        客房收租,
        客房退租,
    }
    public partial class 客房选择Form : Form
    {
        public 客房 selectedKF;//最后选定的客房
        private 客房筛选 kfFilter;
        public 客房选择Form(客房筛选 kfFilter)
        {
            InitializeComponent();
            this.kfFilter = kfFilter;
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

        private void 可出租客房Form_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate { LoadTreeView(); });
        }

        private void LoadTreeView()
        {
            DoThreadSafe(delegate
            {
                treeView1.BeginUpdate();
                treeView1.Nodes.Clear();
            });

            switch (kfFilter)
            {
                case 客房筛选.客房出租:
                    LoadTreeView客房出租();
                    break;
                case 客房筛选.客房收租:
                    LoadTreeView客房收租();
                    break;
                case 客房筛选.客房退租:
                    LoadTreeView客房退租();
                    break;
                default:
                    break;
            }

            DoThreadSafe(delegate
            {
                treeView1.ExpandAll();
                treeView1.EndUpdate();
            }); 
        }
        private void LoadTreeView客房退租()
        { }
        private void LoadTreeView客房收租()
        {
            TreeNode root1 = new TreeNode("所有已租客房");
            root1.NodeFont = new System.Drawing.Font("宋体", 10, FontStyle.Bold);
            root1.ImageIndex = 0;
            DoThreadSafe(delegate { treeView1.Nodes.Add(root1); });
            foreach (var yf in 源房.GetYF_NoHistory())
            {
                if (yf.客房.Count(m => !string.IsNullOrEmpty(m.租户)) == 0)//无客房或全未租
                    continue;

                TreeNode yfNode = new TreeNode();
                yfNode.NodeFont = new System.Drawing.Font("宋体", 10);
                yfNode.ImageIndex = 2;//当前有效源房2
                yfNode.Text = yf.房名;
                yfNode.Tag = yf;
                DoThreadSafe(delegate { root1.Nodes.Add(yfNode); });

                var kfs = yf.客房;
                foreach (var kf in kfs)
                {
                    if (string.IsNullOrEmpty(kf.租户))
                        continue;

                    TreeNode kfNode = new TreeNode();
                    kfNode.NodeFont = new System.Drawing.Font("宋体", 9);
                    kfNode.ImageIndex = 3;//已租3
                    kfNode.Text = kf.命名;
                    kfNode.Tag = kf;

                    if (kf.期止 < DateTime.Now)//已租，协议到期，请续租或退租
                    {
                        kfNode.Text += "[协议到期]";
                        kfNode.ToolTipText = "协议到期，请[续租]或[退租]。";
                        kfNode.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (kf.客房租金明细.Count == 0 || kf.客房租金明细.Max(m => m.止付日期) < DateTime.Now)//已租，协议未到期，逾期交租
                        {
                            kfNode.Text += "[逾期交租]";
                            kfNode.ToolTipText = "逾期交租，请[收租]或[退租]。";
                            kfNode.ForeColor = Color.Magenta;
                        }
                    }

                    DoThreadSafe(delegate { yfNode.Nodes.Add(kfNode); });
                }
            }
        }
        private void LoadTreeView客房出租()
        {
            TreeNode root1 = new TreeNode("所有未租客房");
            root1.NodeFont = new System.Drawing.Font("宋体", 10, FontStyle.Bold);
            root1.ImageIndex = 0;
            DoThreadSafe(delegate { treeView1.Nodes.Add(root1); });
            foreach (var yf in 源房.GetYF_NoHistory())
            {
                if (yf.客房.Count(m => string.IsNullOrEmpty(m.租户)) == 0)//无客房或全租完
                    continue;

                TreeNode yfNode = new TreeNode();
                yfNode.NodeFont = new System.Drawing.Font("宋体", 10);
                yfNode.ImageIndex = 2;//当前有效源房2
                yfNode.Text = yf.房名;
                yfNode.Tag = yf;
                DoThreadSafe(delegate { root1.Nodes.Add(yfNode); });

                var kfs = yf.客房;
                foreach (var kf in kfs)
                {
                    if (!string.IsNullOrEmpty(kf.租户))
                        continue;

                    TreeNode kfNode = new TreeNode();
                    kfNode.NodeFont = new System.Drawing.Font("宋体", 9);
                    kfNode.ImageIndex = 4;//未租
                    kfNode.Text = kf.命名;
                    kfNode.Tag = kf;
                    DoThreadSafe(delegate { yfNode.Nodes.Add(kfNode); });  
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.SelectedImageIndex = e.Node.ImageIndex;//不变更选定的树节点图标

            object entity = e.Node.Tag;
            if (entity is 客房)
            {
                BtnOK.Enabled = true;
                selectedKF = entity as 客房;
                kryptonHeaderGroup1.ValuesSecondary.Heading = string.Format("当前选择：{0} - {1}",
                    selectedKF.源房.房名,selectedKF.命名);
            }
            else
            {
                BtnOK.Enabled = false;
                selectedKF = null;
                kryptonHeaderGroup1.ValuesSecondary.Heading = "当前选择：<无>";
            }
        }

        private void buttonSpecHeaderGroup1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
