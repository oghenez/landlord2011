namespace Landlord.GUI
{
    partial class test
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
            this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
            this.radTreeView2 = new Telerik.WinControls.UI.RadTreeView();
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // radTreeView1
            // 
            this.radTreeView1.Location = new System.Drawing.Point(66, 12);
            this.radTreeView1.Name = "radTreeView1";
            this.radTreeView1.Size = new System.Drawing.Size(323, 102);
            this.radTreeView1.TabIndex = 0;
            this.radTreeView1.Text = "radTreeView1";
            this.radTreeView1.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.radTreeView1_SelectedNodeChanged);
            this.radTreeView1.DoubleClick += new System.EventHandler(this.radTreeView1_DoubleClick);
            // 
            // radTreeView2
            // 
            this.radTreeView2.DataSource = this.源房BindingSource;
            this.radTreeView2.DisplayMember = "房名";
            this.radTreeView2.Location = new System.Drawing.Point(66, 161);
            this.radTreeView2.Name = "radTreeView2";
            this.radTreeView2.RootRelationDisplayName = "kkkkkkkkkkkkk";
            this.radTreeView2.Size = new System.Drawing.Size(323, 186);
            this.radTreeView2.TabIndex = 0;
            this.radTreeView2.Text = "radTreeView1";
            this.radTreeView2.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.radTreeView1_SelectedNodeChanged);
            this.radTreeView2.DoubleClick += new System.EventHandler(this.radTreeView1_DoubleClick);
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord.源房);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(400, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 406);
            this.Controls.Add(this.radTreeView2);
            this.Controls.Add(this.radTreeView1);
            this.Controls.Add(this.button1);
            this.Name = "test";
            this.Text = "test";
            this.Load += new System.EventHandler(this.test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView radTreeView1;
        private Telerik.WinControls.UI.RadTreeView radTreeView2;
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private System.Windows.Forms.Button button1;
    }
}