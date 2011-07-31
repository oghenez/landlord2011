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

        public LandlordEntities context;
        public Main()
        {
            InitializeComponent();
            ThemeResolutionService.ApplicationThemeName = "Windows7";

            context = new LandlordEntities(CreateConnectString());
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadTreeView();
        }
        #region 构造实体连接字符串
        private string CreateConnectString()
        {
            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = "System.Data.SqlServerCe.3.5";

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = @"Data Source=|DataDirectory|\Data\Landlord.sdf;Password ='qwlpy0a'";

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl";


            return entityBuilder.ToString();
        } 
        #endregion
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
            splitPanel2.Controls.Clear();
            uc.radGroupBoxInfo.Text = text;
            splitPanel2.Controls.Add(uc);
            uc.main_Layout(null, null); //手动调用一次，调整初次位置
        } 
        #endregion

        /// <summary>
        /// 载入房源、客源信息到TreeView控件
        /// </summary>
        private void LoadTreeView()
        {
            //radTreeView1.RootRelationDisplayName = "所有源、客房";
            //radTreeView1.RelationBindings.Add(new RelationBinding("源房客房", context.源房));
            radTreeView1.DisplayMember = "房名";
            radTreeView1.ValueMember = "ID";
            radTreeView1.DataSource = context.源房;

            radTreeView1.RelationBindings.Add(new RelationBinding("客房", context.源房.Select(m => m.客房), null, "命名", "ID"));

        }
        public void RefreshTreeView()
        { 
        }
        //新增源房
        private void radBtnAddNewYuanFang_Click(object sender, EventArgs e)
        {
            UC源房详细 uc = new UC源房详细(this);
            LoadUC(uc, "新增源房");
        }

        //源房管理
        private void radBtnManageYuanFang_Click(object sender, EventArgs e)
        {
            UC源房管理 uc = new UC源房管理(this);
            LoadUC(uc, "源房管理");
        }

        private void radTreeView1_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            
        }
    }
}
