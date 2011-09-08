namespace Landlord2.UI
{
    partial class 客房选择Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("正在查询可出租客房，请稍候．．．");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(客房选择Form));
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.buttonSpecHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.BtnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.buttonSpecHeaderGroup1});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.BtnCancel);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.BtnOK);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.treeView1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(319, 444);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "可出租客房";
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "当前选择：<无>";
            // 
            // buttonSpecHeaderGroup1
            // 
            this.buttonSpecHeaderGroup1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close;
            this.buttonSpecHeaderGroup1.UniqueName = "3EB1E3CAD3F04B95D1B768F5BFCE734E";
            this.buttonSpecHeaderGroup1.Click += new System.EventHandler(this.buttonSpecHeaderGroup1_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(246, 355);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(60, 24);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Values.Text = "取消";
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Enabled = false;
            this.BtnOK.Location = new System.Drawing.Point(163, 355);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(60, 24);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Values.Text = "确定";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(11, 13);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点0";
            treeNode1.Text = "正在查询可出租客房，请稍候．．．";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(295, 336);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "源房24.png");
            this.imageList1.Images.SetKeyName(1, "客房-未租24.png");
            // 
            // 可出租客房Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(319, 444);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "可出租客房Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "可出租客房";
            this.Load += new System.EventHandler(this.可出租客房Form_Load);
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnOK;
        private System.Windows.Forms.TreeView treeView1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnCancel;
        private System.Windows.Forms.ImageList imageList1;
    }
}