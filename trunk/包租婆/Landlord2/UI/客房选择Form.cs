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
    public partial class 客房选择Form : Form
    {
        public 客房 selectedKF;//最后选定的客房
        public 客房选择Form()
        {
            InitializeComponent();
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
            ThreadPool.QueueUserWorkItem(delegate{ LoadTreeView(); });
        }

        private void LoadTreeView()
        {
            DoThreadSafe(delegate
            {
                treeView1.BeginUpdate();
                treeView1.Nodes.Clear();
            });

            foreach (var yf in 源房.GetYF_NoHistory())
            {
                if (yf.客房.Count(m => string.IsNullOrEmpty(m.租户)) == 0)//无客房或全租完
                    continue;

                TreeNode yfNode = new TreeNode();
                yfNode.NodeFont = new System.Drawing.Font("宋体", 10, FontStyle.Bold);
                yfNode.ImageIndex = 0;
                yfNode.Text = yf.房名;
                yfNode.Tag = yf;
                DoThreadSafe(delegate { treeView1.Nodes.Add(yfNode); });

                var kfs = yf.客房;
                foreach (var kf in kfs)
                {
                    if (!string.IsNullOrEmpty(kf.租户))
                        continue;

                    TreeNode kfNode = new TreeNode();
                    kfNode.NodeFont = new System.Drawing.Font("宋体", 10);
                    kfNode.ImageIndex = 1;
                    kfNode.Text = kf.命名;
                    kfNode.Tag = kf;
                    DoThreadSafe(delegate { yfNode.Nodes.Add(kfNode); });  
                }
            }

            DoThreadSafe(delegate
            {
                treeView1.ExpandAll();
                treeView1.EndUpdate();
            }); 
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
