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
using System.Data.EntityClient;
using Landlord.Properties;

namespace Landlord.GUI
{
    public partial class Main : RadForm
    {
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

        public static LandlordEntities context;
        public Main()
        {
            InitializeComponent();
            ThemeResolutionService.ApplicationThemeName = "Windows7";

            context = new LandlordEntities(Helper.CreateConnectString());
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            //radTreeView1.ExpandAll();
        }

        #region 状态栏更新最近操作状态
        public void UpdateStatusStrip(string msg)
        {
            DoThreadSafe(() =>
            {
                radLabelMsg.Text = string.Format("{0}:{1}", DateTime.Now.ToShortTimeString(), msg);
                radLabelMsg.ForeColor = Color.Black;
            });
        }
        public void UpdateStatusStrip(string msg, Color color)
        {
            DoThreadSafe(() =>
            {
                radLabelMsg.Text = string.Format("{0}:{1}", DateTime.Now.ToShortTimeString(), msg);
                radLabelMsg.ForeColor = color;
            });
        }
        #endregion
        #region 载入用户控件
        private void LoadUC(UCBase uc, string text)
        {
            //载入控件时，测试检测是否有未保存数据
            var changes = context.ObjectStateManager.GetObjectStateEntries(
                EntityState.Added |
                EntityState.Deleted |
                EntityState.Detached |
                EntityState.Modified);
            if (changes != null)
                MessageBox.Show("[测试] 当前存在数据修改。");

            splitPanel2.Controls.Clear();
            uc.radGroupBoxInfo.Text = text;
            splitPanel2.Controls.Add(uc);           
        } 
        #endregion

        /// <summary>
        /// 载入房源、客源信息到TreeView控件
        /// </summary>
        private void LoadTreeView()
        {
            var yfGroups = from o in context.源房
                      orderby o.期止
                      group o by o.期止 > DateTime.Now into temp
                      orderby temp.Key descending
                      select temp;
            foreach (var yfGroup in yfGroups)
            {
                if (yfGroup.Key == true) // 满足 '期止 > DateTime.Now'
                {
                    RadTreeNode root1 = new RadTreeNode("当前源房信息");
                    radTreeView1.Nodes.Add(root1);
                    foreach (var yf in yfGroup)
                        AddYuanFangToTree(root1, yf);

                    root1.ExpandAll();
                }
                else
                {
                    RadTreeNode root2 = new RadTreeNode("历史源房信息");
                    radTreeView1.Nodes.Add(root2);
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
        private void AddYuanFangToTree(RadTreeNode parent, 源房 yf)
        {
            RadTreeNode yfNode = new RadTreeNode();
            yfNode.Text = yf.房名;
            yfNode.Tag = yf;
            yfNode.Image = Resources.house_24;
            parent.Nodes.Add(yfNode);

            var kfs = yf.客房;
            foreach (var kf in kfs)
            {
                RadTreeNode kfNode = new RadTreeNode();
                kfNode.Text = kf.命名;
                kfNode.Tag = kf;
                kfNode.Image = (kf.期止 < DateTime.Now) ? Resources.house_2__2_ : Resources.House__6_;/*是否到期*/                
                yfNode.Nodes.Add(kfNode);
            }     
        }

        //新增源房
        private void radBtnAddNewYuanFang_Click(object sender, EventArgs e)
        {
            UC源房详细 uc = new UC源房详细();
            LoadUC(uc, "新增源房");
        }

        //源房管理
        private void radBtnManageYuanFang_Click(object sender, EventArgs e)
        {
            UC源房管理 uc = new UC源房管理();
            LoadUC(uc, "源房管理");
        }

        private void radTreeView1_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            if(e.Node.Tag == null)
                return;
            else if (e.Node.Tag is 源房)
            {
                源房 yf = e.Node.Tag as 源房;
                UC源房详细 uc = new UC源房详细(yf);
                LoadUC(uc, "源房："+yf.房名);
            }
            else if (e.Node.Tag is 客房)
            {
                客房 kf = e.Node.Tag as 客房;
                UC客房详细 uc = new UC客房详细(kf);
                LoadUC(uc, "客房：" + kf.命名);
            }

            

        }
        //装修明细
        private void radButtonElement5_Click(object sender, EventArgs e)
        {
            UC装修明细 uc = new UC装修明细();
            LoadUC(uc, "装修明细");
        }

        private void splitPanel2_Layout(object sender, LayoutEventArgs e)
        {
            if (splitPanel2.Controls.Count == 0)
                return;
            var control = splitPanel2.Controls[0];
            if (control.Dock != DockStyle.Fill)
            {
                int x = (splitPanel2.Width - control.Width) / 2;
                int y = (splitPanel2.Height - control.Height) / 2;
                x = (x > 0) ? x : 0;
                y = (y > 0) ? y : 0;
                control.SetBounds(x, y, control.Width, control.Height); 
            }
            
        }
    }
}
