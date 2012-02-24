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
using System.IO;

namespace Landlord2
{
    public partial class Main : KryptonForm
    {
        private int _widthLeftRight, _heightUpDown;
        private MyContext context;
        private UC源房详细 yfUC ;//= new UC源房详细(true) { Dock = DockStyle.Fill };
        private UC客房详细 kfUC ;//= new UC客房详细(true) { Dock = DockStyle.Fill };
        
        public Main()
        {
            InitializeComponent();
            context = new MyContext(AppRoot.connection);
            #region 加密狗读取
            string s = Helper.ReadOffsetDataAndDecrypt(352, 24);
            Text += s;
            if (s == "【测试版】")//【测试版】到期提示
            {
                DateTime begin = DateTime.ParseExact(Helper.ReadOffsetDataAndDecrypt(424, 24), "yyyyMMddHHmmss", null);
                DateTime end = DateTime.ParseExact(Helper.ReadOffsetDataAndDecrypt(448, 24), "yyyyMMddHHmmss", null);
                toolStripStatusLabel1.Text = string.Format("距测试到期还有{0}天", (end - begin).Days);
            }
            bool v = bool.Parse(Helper.ReadOffsetDataAndDecrypt(472, 12));
            数据报表ToolStripMenuItem.Visible = v;
            kcheckBtn数据报表.Visible = v;
            #endregion
            #region 调试代码
#if DEBUG
            context.ObjectStateManager.ObjectStateManagerChanged += (sender, e) =>
            {
                Console.WriteLine(string.Format(
                "ObjectStateManager.ObjectStateManagerChanged | Action:{0} Object:{1} -- {2}"
                , e.Action
                , e.Element
                ,DateTime.Now.ToShortTimeString()));
                //MessageBox.Show(string.Format(
                //    "MainContext刚刚检测到缓存改动--Action:{0} Object:{1}\r\n目前本地缓存实体数量：\r\n\tAdded-{2}\r\n\tDeleted-{3}\r\n\tModified-{4}\r\n\tUnchanged-{5}"
                //    , e.Action
                //    , e.Element
                //    , context.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Count()
                //    , context.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted).Count()
                //    , context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified).Count()
                //    , context.ObjectStateManager.GetObjectStateEntries(EntityState.Unchanged).Count()
                //    ));
            };
#endif
            #endregion

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
            //解决kryptonListBox的双击Bug
            kryptonListBox1.ListBox.MouseDoubleClick += new MouseEventHandler(kryptonListBox1_MouseDoubleClick);

            ThreadPool.QueueUserWorkItem(delegate
            {
                LoadTreeView(null);
                DoThreadSafe(delegate { yfUC = new UC源房详细(true) { Dock = DockStyle.Fill }; });
                DoThreadSafe(delegate { kfUC = new UC客房详细(true) { Dock = DockStyle.Fill }; });
                
                RefreshCustomAlarmData();
                RefreshSystemAlarmData();
                
                string msg;
                if(!AutoBackupData(out msg))
                    KryptonMessageBox.Show(msg, "自动备份错误提示",
                                           System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            });           
        }

        //刷新系统提醒 -- 系统自动检测，这些系统提醒临时生成，不放入数据库。
        private void RefreshSystemAlarmData()
        {
            DoThreadSafe(delegate
            {
                kryptonListBox1.BeginUpdate();
                //删除已有系统提醒
                for (int i = kryptonListBox1.Items.Count - 1; i >= 0; i--)
                {
                    if ((kryptonListBox1.Items[i] as KryptonListItem).Tag == null)
                        kryptonListBox1.Items.RemoveAt(i);
                }
            });

            List<提醒> systemAlarms = new List<提醒>();
            //执行系统检测，搜索得到所有系统提醒
            //!++ 补充完整系统检测，构造相应的提醒对象，加入集合。还有定时检测刷新需要处理。。。
            //提醒 test = new 提醒();
            //test.事项 = "test";
            //test.源房ID = context.源房.First().ID;

            //systemAlarms.Add(test);
            systemAlarms.ForEach(m => { AddOneAlarmMsg(m,true); });

            DoThreadSafe(delegate
            {
                kryptonListBox1.EndUpdate();
                IsEnableAlarm(kryptonListBox1.Items.Count);
            });

        }
        /// <summary>
        /// 刷新自定义‘提醒’数据
        /// </summary>
        public void RefreshCustomAlarmData()
        {
            DoThreadSafe(delegate
            {
                kryptonListBox1.BeginUpdate();
                //删除已有自定义提醒
                for (int i = kryptonListBox1.Items.Count - 1; i >= 0; i--)
                {
                    if ((kryptonListBox1.Items[i] as KryptonListItem).Tag != null)
                        kryptonListBox1.Items.RemoveAt(i);
                }
            });
            var customAlarms = 提醒.GetTX_InSomeDays(context).Execute(MergeOption.NoTracking).ToList();
            customAlarms.ForEach(m => { AddOneAlarmMsg(m,false); });

            DoThreadSafe(delegate
            {
                kryptonListBox1.EndUpdate();
                IsEnableAlarm(kryptonListBox1.Items.Count);
            });
            
        }
        //增加一条提醒。flag=true系统提醒；flag=false自定义提醒
        private void AddOneAlarmMsg(提醒 tx,bool flag)
        { 
            KryptonListItem item = new KryptonListItem();
            if (flag)//系统提醒
            {
                item.Image = Resources.idea_16;
                item.ShortText = tx.事项;
                item.LongText = "【系统提醒】";
            }
            else//自定义提醒
            {
                var yf = context.源房.FirstOrDefault(m => m.ID == tx.源房ID);
                var kf = context.客房.FirstOrDefault(m => m.ID == tx.客房ID);

                item.ShortText = tx.ToString();
                item.Tag = tx;//自定义提醒的tag保留对象引用，双击会发生响应。
                if (kf == null)
                {
                    item.LongText = string.Format("{0}【源房提醒】", yf.房名);
                    item.Image = Resources.源房16;
                }
                else
                {
                    item.LongText = string.Format("{0} - {1}【客房提醒】", yf.房名, kf.命名);
                    item.Image = Resources.客房16;
                }
            }          
            
            DoThreadSafe(delegate
            {
                kryptonListBox1.Items.Add(item);
            });
        }

        #region 闪动提醒图标
        private void IsEnableAlarm(int alarmsCount)
        {
            if(alarmsCount > 0)
                AlarmTimer1.Enabled = true;//闪动提醒图标
            else
            {
                AlarmTimer1.Enabled = false;
                kryptonHeaderGroup3.ValuesPrimary.Image = Resources.idea_16_dis;
            }
        }
        private bool flag = false;
        private void AlarmTimer1_Tick(object sender, EventArgs e)
        {
            kryptonHeaderGroup3.ValuesPrimary.Image = (flag) ? Resources.idea_16_dis : Resources.idea_16_hot;
            flag = !flag;
        } 
        #endregion

        //根据数据源，刷新TreeView，并定位到指定对象所对应的节点。（新增、修改、删除等操作后）
        //如果obj传入null，那么如果原来选择的是源房或客房节点，继续选择它。
        //! 注意：此处的obj，有可能是从属于其他界面context的，所以函数里会根据entitykey判断
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
            DoThreadSafe(delegate
            {
                treeView1.BeginUpdate();
                treeView1.Nodes.Clear();
            });

            if (context.源房.Count() > 0)
            {                
                TreeNode root1 = new TreeNode("当前源房信息");
                root1.ToolTipText = "当前源房按照签约时间自动排序";
                root1.NodeFont = new System.Drawing.Font("宋体", 10, FontStyle.Bold);
                root1.ImageIndex = 0;
                DoThreadSafe(delegate { treeView1.Nodes.Add(root1); });
                foreach (var yf in 源房.GetYF_NoHistory(context).Include("客房").Execute(MergeOption.OverwriteChanges))
                    AddYuanFangToTree(root1, yf, false, obj);

                TreeNode root2 = new TreeNode("历史源房信息");
                root2.ToolTipText = "历史源房按照签约时间自动排序";
                root2.NodeFont = new System.Drawing.Font("宋体", 10, FontStyle.Bold);
                root2.ForeColor = Color.DimGray;
                root2.ImageIndex = 1;
                DoThreadSafe(delegate { treeView1.Nodes.Add(root2); });
                foreach (var yf in 源房.GetYF_History(context).Include("客房").Execute(MergeOption.OverwriteChanges))
                    AddYuanFangToTree(root2, yf, true, obj);
            }
            else
            {
                DoThreadSafe(delegate {
                    treeView1.Nodes.Add("当前没有源房、客房信息"); }); 
            }

            DoThreadSafe(delegate
            {
                if (obj == null)
                    treeView1.SelectedNode = treeView1.Nodes[0];//默认刷新定位到此节点
                treeView1.ExpandAll();
                treeView1.EndUpdate();
            });   
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
                if (obj != null && yf.EntityKey == obj.EntityKey)
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
                    if (obj != null && kf.EntityKey == obj.EntityKey)
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
            DisplayLeftToolBar(kryptonCheckSet1.CheckedIndex);
        }
        //左侧控件的显示隐藏
        private void DisplayLeftToolBar(int checkedIndex)
        {
            switch (checkedIndex)
            {
                case 0://辅助工具
                    {
                        treeView1.Visible = false;
                        treeView1.Dock = DockStyle.None;
                        listViewReports.Visible = false;
                        listViewReports.Dock = DockStyle.None;
                        listViewTools.Visible = true;
                        listViewTools.Dock = DockStyle.Fill;
                    }
                    break;
                case 1://数据报表
                    {
                        treeView1.Visible = false;
                        treeView1.Dock = DockStyle.None;
                        listViewTools.Visible = false;
                        listViewTools.Dock = DockStyle.None;
                        listViewReports.Visible = true;
                        listViewReports.Dock = DockStyle.Fill;
                    }
                    break;
                case 2://房屋租赁
                    {
                        listViewTools.Visible = false;
                        listViewTools.Dock = DockStyle.None;
                        listViewReports.Visible = false;
                        listViewReports.Dock = DockStyle.None;
                        treeView1.Visible = true;
                        treeView1.Dock = DockStyle.Fill;
                    }
                    break;
                default:
                    break;
            }
        }
        #region 加载或刷新用户控件（例如：上次和当前都是点击的‘源房’，那么仅仅刷新而不重复加载）
        private void LoadOrRefreshUC(object entity)
        {
            kryptonHeaderGroup2.SuspendLayout();
            if (entity == null)
            {
                kryptonHeaderGroup2.Panel.Controls.Clear();
                kryptonHeaderGroup2.ValuesPrimary.Heading = "源房、客房租期一览";
                UC源房客房到期一览 chartUC = new UC源房客房到期一览() { Dock = DockStyle.Fill };
                kryptonHeaderGroup2.Panel.Controls.Add(chartUC);
            }            
            else if (entity is 源房)
            {
                yfUC.源房BindingSource.DataSource = entity;
                yfUC.源房涨租协定BindingSource.DataSource = 源房涨租协定.GetByYFid(context, ((源房)entity).ID).Execute(MergeOption.NoTracking);                    

                if (kryptonHeaderGroup2.Panel.Controls.Count == 0) //初次加载
                {
                    kryptonHeaderGroup2.Panel.Controls.Add(yfUC);
                }
                else if(kryptonHeaderGroup2.Panel.Controls[0] is UC源房详细)//原来加载的是‘源房详细’控件
                {
                    //仅仅更改绑定实体
                }
                else 
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
                kfUC.客房租金明细BindingSource.DataSource = 客房租金明细.GetRentDetails(context, (entity as 客房).ID).Execute(MergeOption.NoTracking);

                if (kryptonHeaderGroup2.Panel.Controls.Count == 0) //初次加载
                {
                    kryptonHeaderGroup2.Panel.Controls.Add(kfUC);
                }
                else if (kryptonHeaderGroup2.Panel.Controls[0] is UC客房详细)
                {
                    //仅仅更改绑定实体
                }
                else 
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
        //系统自动备份检测，失败则回传错误信息
        private bool AutoBackupData(out string msg)
        {
            msg = string.Empty;
            //检测上次备份时间
            DateTime lastBackupDateTime = DateTime.MinValue;
            string path =Path.Combine( Directory.GetCurrentDirectory(),"Data");            
            List<string> files = Directory.GetFiles(path, "自动备份??????????????.bak", SearchOption.TopDirectoryOnly).ToList();
            if (files.Count > 0)//存在备份
            {
                string max = files.Max();
                max = Path.GetFileNameWithoutExtension(max);
                if(!DateTime.TryParseExact(max.Substring(4,14),"yyyyMMddHHmmss",null,System.Globalization.DateTimeStyles.None,out lastBackupDateTime))
                {
                    msg = "自动备份出错（请勿随意更改自动备份文件名）！";
                    return false;
                }
                //是否间隔7天，如果7天未自动备份，系统将自动备份
                if((DateTime.Now - lastBackupDateTime).Days >= 7)
                {
                    bool result = BackupData(true,out msg);//开始自动备份
                    if(result)
                    {
                        //备份完毕后，系统保留最近3次自动备份记录，删除更早之前的记录
                        while(files.Count >= 3)
                        {
                            string min = files.Min();
                            File.Delete(min);
                            files.Remove(min);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;//不需要自动备份
                }

            }
            else//不存在备份
            {
                return BackupData(true,out msg);
            }
            
            
        }
        /// <summary>
        /// 数据备份（供手动备份和系统自动备份调用）
        /// 自动备份文件名格式："自动备份20100208115432.bak"--"自动备份"开头 + 年月日时分秒
        /// </summary>
        /// <param name="AutoOrNot">是否系统自动备份（自动备份：true；手动备份：false）</param>
        /// <param name="msg">如果出错，回传出错信息</param>
        private bool BackupData(bool AutoOrNot, out string msg)
        {
            msg = string.Empty;
            string sourceFilename = Path.Combine(Directory.GetCurrentDirectory(),
                                    "Data",
                                    "Landlord2.sdf");
            string destFilename;
            if (AutoOrNot)//自动备份
            {
                destFilename =Path.Combine(Directory.GetCurrentDirectory(),
                    "Data",
                    string.Format("自动备份{0}.bak", DateTime.Now.ToString("yyyyMMddHHmmss"))) ;
            }
            else//手动备份
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "数据备份文件 (*.bak)|*.bak|所有文件 (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.Cancel)
                {
                    msg = "用户取消备份操作";
                    return true;
                }
                destFilename = sfd.FileName;
            }
            try
            {
                File.Copy(sourceFilename, destFilename, true);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
            return true;
        }
        
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KryptonMessageBox.Show("确定退出租赁管理系统？", "退出确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                == System.Windows.Forms.DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        #region 菜单按钮
        public void 新增源房_Click(object sender, EventArgs e)
        {
            #region 加密狗对源房套数的限制
            int num = int.Parse(Helper.ReadOffsetDataAndDecrypt(376, 12));
            if (num != 0)
            {
                int num2 = 源房.GetYF(context).Execute(System.Data.Objects.MergeOption.NoTracking).Count();//系统当前源房数量
                if (num2 >= num)
                {
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format("此版本已达到源房套数上限 - {0}套源房。\r\n如需操作更多源房，请联系软件开发商！",num), "源房上限提示",
                       System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return;
                }
            }
            #endregion
            //新增源房
            using (源房Form yF = new 源房Form())
            {
                yF.ShowDialog(this);
            }
        }
        public void 删除源房_Click(object sender, EventArgs e)
        {
            //删除源房
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is 源房)
            {
                源房 yf = treeView1.SelectedNode.Tag as 源房;
                string txt = string.Format("确定要删除源房 [{0}] 吗？\r\n（将同时删除此源房下面的所有客房及所有关联的信息）", yf.房名);
                var result = KryptonMessageBox.Show(txt, "源房删除确认",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {
                    context.DeleteObject(yf);
                    string msg;
                    if (Helper.saveData(context, yf, out msg))
                    {
                        //删除源房后，删除相关的提醒
                        var tx = context.提醒.Where(m => m.源房ID == yf.ID).ToList();
                        for (int i = tx.Count-1; i >= 0; i--)
                            context.提醒.DeleteObject(tx[i]);
                        //删除源房后，删除相关日常损耗
                        var sh = context.日常损耗.Where(m => m.源房ID == yf.ID).ToList();
                        for (int i = sh.Count - 1; i >= 0; i--)
                            context.日常损耗.DeleteObject(sh[i]);

                        KryptonMessageBox.Show(msg, "成功删除源房");
                        RefreshAndLocateTree(null);
                        LoadOrRefreshUC(null);
                    }
                    else
                    {
                        KryptonMessageBox.Show(msg, "失败");
                        context.Refresh(System.Data.Objects.RefreshMode.StoreWins, yf);
                    }
                    //clearObjectManagement();
                }
            }
        }
        public void 编辑源房_Click(object sender, EventArgs e)
        {
            //编辑源房
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is 源房)
            {
                源房 yf = treeView1.SelectedNode.Tag as 源房;
                using (源房Form yF = new 源房Form(yf.ID))
                {
                    yF.ShowDialog(this);
                }
            }
        }

        public void 新增客房_Click(object sender, EventArgs e)
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
        public void 删除客房_Click(object sender, EventArgs e)
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
                    if (Helper.saveData(context, kf, out msg))
                    {
                        //删除客房后，删除相关的提醒
                        var tx = context.提醒.Where(m => m.客房ID == kf.ID).ToList();
                        for (int i = tx.Count - 1; i >= 0; i--)
                            context.提醒.DeleteObject(tx[i]);
                        //删除源房后，删除相关日常损耗
                        var sh = context.日常损耗.Where(m => m.客房ID == kf.ID).ToList();
                        for (int i = sh.Count - 1; i >= 0; i--)
                            context.日常损耗.DeleteObject(sh[i]);

                        KryptonMessageBox.Show(msg, "成功删除客房");
                        RefreshAndLocateTree(null);
                        LoadOrRefreshUC(null);
                    }
                    else
                    {
                        KryptonMessageBox.Show(msg, "失败");
                        context.Refresh(System.Data.Objects.RefreshMode.StoreWins, kf);
                    }
                    //clearObjectManagement();
                }
            }
        }
        public void 编辑客房_Click(object sender, EventArgs e)
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

        public void 源房缴费_Click(object sender, EventArgs e)
        {
            //源房缴费
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag != null)
            {
                object entity = treeView1.SelectedNode.Tag;
                Guid yfID = Guid.Empty;
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
        public void 源房缴费明细_Click(object sender, EventArgs e)
        {
            //源房缴费明细
            using (源房缴费明细Form jF = new 源房缴费明细Form())
            {
                jF.ShowDialog(this);
            }
        }
        public void 客房出租_Click(object sender, EventArgs e)
        {
            //出租
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is 客房)
            {
                客房 kf = treeView1.SelectedNode.Tag as 客房;
                if (!string.IsNullOrEmpty(kf.租户))
                    return;

                using (客房出租Form rent = new 客房出租Form(kf.ID))
                {
                    DialogResult result = rent.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        if (KryptonMessageBox.Show("客房已成功出租，是否立即进行首期收租？", "首期收租询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            using (客房收租Form collectRent = new 客房收租Form(kf.ID))
                            {
                                collectRent.ShowDialog(this);
                            }
                        }
                    }
                }
            }
        }
        public void 客房续租_Click(object sender, EventArgs e)
        {
            //客房续租
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is 客房)
            {
                客房 kf = treeView1.SelectedNode.Tag as 客房;
                if (string.IsNullOrEmpty(kf.租户))//未租
                    return;

                using (客房续租Form xz = new 客房续租Form(kf.ID))
                {
                    xz.ShowDialog(this);
                }
            }
        }
        public void 客房退租_Click(object sender, EventArgs e)
        {
            //客房退租
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is 客房)
            {
                客房 kf = treeView1.SelectedNode.Tag as 客房;
                if (string.IsNullOrEmpty(kf.租户))//未租
                    return;
                
                using (客房退租Form tz = new 客房退租Form(kf.ID))
                {
                    tz.ShowDialog(this);
                }
            }
        }
        public void 客房收租_Click(object sender, EventArgs e)
        {
            //客房收租
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is 客房)
            {
                客房 kf = treeView1.SelectedNode.Tag as 客房;
                if (string.IsNullOrEmpty(kf.租户))//未租
                    return;
                if (kf.期止 < DateTime.Now)//已租，协议到期，请续租或退租
                {
                    KryptonMessageBox.Show("协议到期，请续租或退租。");
                    return;
                }

                using (客房收租Form collectRent = new 客房收租Form(kf.ID))
                {
                    collectRent.ShowDialog(this);
                }
            }
        }
        public void 客房收租明细_Click(object sender, EventArgs e)
        {
            //客房收租明细
            using (客房收租明细Form sz = new 客房收租明细Form())
            {
                sz.ShowDialog(this);
            }
        }

        public void 客房出租历史记录_Click(object sender, EventArgs e)
        {
            //客房出租历史记录
            using (客房出租历史记录Form collectRent = new 客房出租历史记录Form())
            {
                collectRent.ShowDialog(this);
            }
        }


        public void 源房装修_Click(object sender, EventArgs e)
        {
            //源房装修
            using (装修Form cb = new 装修Form())
            {
                cb.ShowDialog(this);
            }
        }
        public void 源房装修明细_Click(object sender, EventArgs e)
        {
            //装修明细
            using (装修明细Form deForm = new 装修明细Form())
            {
                deForm.ShowDialog(this);
            }
        }


        public void 新增提醒_Click(object sender, EventArgs e)
        {
            //新增提醒
            using (提醒Form tx = new 提醒Form())
            {
                tx.ShowDialog(this);
            }
        }

        public void 提醒管理_Click(object sender, EventArgs e)
        {
            //提醒管理
            using (提醒管理Form tiForm = new 提醒管理Form())
            {
                tiForm.ShowDialog(this);
            }
        }

        public void kryptonListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //编辑提醒
            if (e.Button == System.Windows.Forms.MouseButtons.Left && kryptonListBox1.SelectedItem != null)
            {
                KryptonListItem item = kryptonListBox1.SelectedItem as KryptonListItem;
                if (item.Tag != null)
                {
                    提醒 obj = item.Tag as 提醒;
                    using (提醒Form form = new 提醒Form(obj))
                    {
                        form.ShowDialog(this);
                    }
                }
            }
        }
        public void 提醒设置_Click(object sender, EventArgs e)
        {
            //!++ 提醒设置
        }
        public void 源房抄表_Click(object sender, EventArgs e)
        {
            //源房抄表
            using (源房抄表Form cb = new 源房抄表Form())
            {
                cb.ShowDialog(this);
            }  
        }
        public void 源房抄表明细_Click(object sender, EventArgs e)
        {
            //源房抄表明细
            using (源房抄表明细Form form = new 源房抄表明细Form())
            {
                form.ShowDialog(this);
            }
        }
        public void 日常损耗_Click(object sender, EventArgs e)
        {
            //日常损耗
            using (日常损耗管理Form form = new 日常损耗管理Form())
            {
                form.ShowDialog(this);
            }
        }
        private void 数据备份_Click(object sender, EventArgs e)
        {
            string msg;
            if (!BackupData(false, out msg))
            {
                KryptonMessageBox.Show(msg, "手动备份错误提示",
                                           System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            else if(msg != "用户取消备份操作")
            {
                KryptonMessageBox.Show("手动备份数据成功！", "成功备份数据");
            }
        }

        private void 数据还原_Click(object sender, EventArgs e)
        {
            var result = KryptonMessageBox.Show("当前所有数据将丢失，还原至选定备份！请再次确认！", "数据还原确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == System.Windows.Forms.DialogResult.Cancel)
                return;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "数据备份文件 (*.bak)|*.bak|所有文件 (*.*)|*.*";
            ofd.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;

            string filename = ofd.FileName;
            ChangeDataBase(filename,true);

        }

        /// <summary>
        /// 更换数据库
        /// </summary>
        /// <param name="filename">新数据库文件名</param>
        /// <param name="flag">true-数据还原操作；false-数据初始化操作。</param>
        private void ChangeDataBase(string filename,bool flag)
        {
            string s = flag ? "数据还原" : "数据初始化";
            try
            {
                string oldfile = Path.Combine(Directory.GetCurrentDirectory(),
                                    "Data",
                                    "Landlord2.sdf");
                //先备份
                string temp = Path.Combine(Directory.GetCurrentDirectory(), "Data", "temp.bak");
                File.Copy(oldfile, temp, true);
                //销毁context
                AppRoot.connection.Close();
                context.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //再覆盖
                File.Delete(oldfile);
                File.Copy(filename, oldfile, true);
                //删除临时
                File.Delete(temp);
                //删除初始化临时数据库
                if (flag == false)
                    File.Delete(filename);
                //重开连接
                AppRoot.connection.Open();
                context = new MyContext(AppRoot.connection);
                //成功提示
                KryptonMessageBox.Show(s+"成功", s+"成功提示",
                          System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

                //刷新界面
                ThreadPool.QueueUserWorkItem(delegate
                {
                    LoadTreeView(null);
                    RefreshCustomAlarmData();
                    RefreshSystemAlarmData();
                });
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, s+"错误提示",
                          System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void 数据初始化_Click(object sender, EventArgs e)
        {
            var result = KryptonMessageBox.Show("此操作将清空当前所有数据！请再次确认！", "数据初始化确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == System.Windows.Forms.DialogResult.Cancel)
                return;

            string tempfile = Path.Combine(Directory.GetCurrentDirectory(),
                                    "Data",
                                    Guid.NewGuid().ToString());
            File.WriteAllBytes(tempfile, Properties.Resources.Empty);//将空数据库文件写入临时文件
            ChangeDataBase(tempfile,false);
        }

        private void 退出_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 计算器_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"calc.exe");
        }
        
        private void 电子地图_Click(object sender, EventArgs e)
        {
            //电子地图
            Map form = new Map();
            form.Show(this);//这里加上this,可以使子窗口永远位于父窗口的前端！
        }

        private void 网上银行_Click(object sender, EventArgs e)
        {
            //网上银行
            WebForm form = new WebForm(WebFormCategory.网上银行);
            form.Show(this);
        }

        private void 生活助手_Click(object sender, EventArgs e)
        {
            //生活助手
            WebForm form = new WebForm(WebFormCategory.生活助手);
            form.Show(this);
        }

        private void 租赁网站_Click(object sender, EventArgs e)
        {
            //租赁网站
            WebForm form = new WebForm(WebFormCategory.租赁网站);
            form.Show(this);
        }


        private void listViewTools_ItemActivate(object sender, EventArgs e)
        {
            int index = 0;
            if(listViewTools.SelectedIndices == null || listViewTools.SelectedIndices.Count == 0)
                return ;
            else
            {
                foreach(int i in listViewTools.SelectedIndices)
                {
                    index = i;//这里因为已经设置Listview为单选，所以只能循环一次
                }
            }
            switch (index)
            {
                case 0:
                    计算器_Click(null, null);
                    break;
                case 1:
                    电子地图_Click(null, null);
                    break;
                case 2:
                    网上银行_Click(null, null);
                    break;
                case 3:
                    生活助手_Click(null, null);
                    break;
                case 4:
                    租赁网站_Click(null, null);
                    break;
                default:
                    break;

            }
        }

        #endregion

























    }
}
