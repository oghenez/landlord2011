namespace Landlord2.UI
{
    partial class 缴费明细Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(缴费明细Form));
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.源房缴费明细BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnFilter = new System.Windows.Forms.ToolStripDropDownButton();
            this.所有缴费项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.房租ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.物业费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.水ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.电ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.气ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.宽带费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中介费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.押金ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.其他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.kryptonComboBox1 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.raBtnOne = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.raBtnAll = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.源房 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.缴费时间DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn();
            this.缴费项DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.缴费金额DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn();
            this.期始DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewMaskedTextBoxColumn();
            this.期止DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewMaskedTextBoxColumn();
            this.付款人DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.收款人DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.备注DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房缴费明细BindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.kryptonSplitContainer1.IsSplitterFixed = true;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            this.kryptonSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonDataGridView1);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.statusStrip1);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonComboBox1);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.raBtnOne);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.raBtnAll);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.btnOK);
            this.kryptonSplitContainer1.Panel2.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(844, 426);
            this.kryptonSplitContainer1.SplitterDistance = 380;
            this.kryptonSplitContainer1.SplitterWidth = 1;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.源房,
            this.缴费时间DataGridViewTextBoxColumn,
            this.缴费项DataGridViewTextBoxColumn,
            this.缴费金额DataGridViewTextBoxColumn,
            this.期始DataGridViewTextBoxColumn,
            this.期止DataGridViewTextBoxColumn,
            this.付款人DataGridViewTextBoxColumn,
            this.收款人DataGridViewTextBoxColumn,
            this.备注DataGridViewTextBoxColumn,
            this.ID});
            this.kryptonDataGridView1.DataSource = this.源房缴费明细BindingSource;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonDataGridView1.RowTemplate.Height = 23;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(844, 348);
            this.kryptonDataGridView1.TabIndex = 0;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Landlord2.Data.源房);
            // 
            // 源房缴费明细BindingSource
            // 
            this.源房缴费明细BindingSource.DataSource = typeof(Landlord2.Data.源房缴费明细);
            this.源房缴费明细BindingSource.Sort = "缴费时间";
            this.源房缴费明细BindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.源房缴费明细BindingSource_AddingNew);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFilter,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 348);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(844, 32);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnFilter
            // 
            this.btnFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.所有缴费项ToolStripMenuItem,
            this.toolStripSeparator1,
            this.房租ToolStripMenuItem,
            this.物业费ToolStripMenuItem,
            this.水ToolStripMenuItem,
            this.电ToolStripMenuItem,
            this.气ToolStripMenuItem,
            this.宽带费ToolStripMenuItem,
            this.中介费ToolStripMenuItem,
            this.押金ToolStripMenuItem,
            this.其他ToolStripMenuItem});
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(165, 30);
            this.btnFilter.Text = "按 [缴费项] 筛选 - 所有";
            this.btnFilter.ToolTipText = "按 [缴费项] 筛选";
            // 
            // 所有缴费项ToolStripMenuItem
            // 
            this.所有缴费项ToolStripMenuItem.Name = "所有缴费项ToolStripMenuItem";
            this.所有缴费项ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.所有缴费项ToolStripMenuItem.Text = "所有缴费项";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // 房租ToolStripMenuItem
            // 
            this.房租ToolStripMenuItem.Name = "房租ToolStripMenuItem";
            this.房租ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.房租ToolStripMenuItem.Text = "房租";
            // 
            // 物业费ToolStripMenuItem
            // 
            this.物业费ToolStripMenuItem.Name = "物业费ToolStripMenuItem";
            this.物业费ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.物业费ToolStripMenuItem.Text = "物业费";
            // 
            // 水ToolStripMenuItem
            // 
            this.水ToolStripMenuItem.Name = "水ToolStripMenuItem";
            this.水ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.水ToolStripMenuItem.Text = "水";
            // 
            // 电ToolStripMenuItem
            // 
            this.电ToolStripMenuItem.Name = "电ToolStripMenuItem";
            this.电ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.电ToolStripMenuItem.Text = "电";
            // 
            // 气ToolStripMenuItem
            // 
            this.气ToolStripMenuItem.Name = "气ToolStripMenuItem";
            this.气ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.气ToolStripMenuItem.Text = "气";
            // 
            // 宽带费ToolStripMenuItem
            // 
            this.宽带费ToolStripMenuItem.Name = "宽带费ToolStripMenuItem";
            this.宽带费ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.宽带费ToolStripMenuItem.Text = "宽带费";
            // 
            // 中介费ToolStripMenuItem
            // 
            this.中介费ToolStripMenuItem.Name = "中介费ToolStripMenuItem";
            this.中介费ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.中介费ToolStripMenuItem.Text = "中介费";
            // 
            // 押金ToolStripMenuItem
            // 
            this.押金ToolStripMenuItem.Name = "押金ToolStripMenuItem";
            this.押金ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.押金ToolStripMenuItem.Text = "押金";
            // 
            // 其他ToolStripMenuItem
            // 
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.其他ToolStripMenuItem.Text = "其他";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoToolTip = true;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(664, 27);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "当前合计金额：";
            this.toolStripStatusLabel1.ToolTipText = "合计当前列表显示的项目金额";
            // 
            // kryptonComboBox1
            // 
            this.kryptonComboBox1.DataSource = this.bindingSource1;
            this.kryptonComboBox1.DisplayMember = "房名";
            this.kryptonComboBox1.DropDownWidth = 215;
            this.kryptonComboBox1.Enabled = false;
            this.kryptonComboBox1.Location = new System.Drawing.Point(180, 12);
            this.kryptonComboBox1.Name = "kryptonComboBox1";
            this.kryptonComboBox1.Size = new System.Drawing.Size(215, 21);
            this.kryptonComboBox1.TabIndex = 9;
            this.toolTip1.SetToolTip(this.kryptonComboBox1, "指定单套源房后，可直接进行‘添加’操作。");
            this.kryptonComboBox1.ValueMember = "ID";
            this.kryptonComboBox1.SelectedIndexChanged += new System.EventHandler(this.kryptonComboBox1_SelectedIndexChanged);
            // 
            // raBtnOne
            // 
            this.raBtnOne.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.raBtnOne.Location = new System.Drawing.Point(102, 12);
            this.raBtnOne.Name = "raBtnOne";
            this.raBtnOne.Size = new System.Drawing.Size(85, 20);
            this.raBtnOne.TabIndex = 10;
            this.toolTip1.SetToolTip(this.raBtnOne, "指定单套源房后，可直接进行‘添加’操作。");
            this.raBtnOne.Values.Text = "单套源房：";
            this.raBtnOne.CheckedChanged += new System.EventHandler(this.raBtn_CheckedChanged);
            // 
            // raBtnAll
            // 
            this.raBtnAll.Checked = true;
            this.raBtnAll.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.raBtnAll.Location = new System.Drawing.Point(12, 12);
            this.raBtnAll.Name = "raBtnAll";
            this.raBtnAll.Size = new System.Drawing.Size(72, 20);
            this.raBtnAll.TabIndex = 10;
            this.raBtnAll.Values.Text = "全部源房";
            this.raBtnAll.CheckedChanged += new System.EventHandler(this.raBtn_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(721, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(591, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 6;
            this.btnOK.Values.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 10;
            // 
            // 源房
            // 
            this.源房.DataPropertyName = "源房ID";
            this.源房.DataSource = this.bindingSource1;
            this.源房.DisplayMember = "房名";
            this.源房.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.源房.HeaderText = "源房";
            this.源房.Name = "源房";
            this.源房.ReadOnly = true;
            this.源房.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.源房.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.源房.ValueMember = "ID";
            // 
            // 缴费时间DataGridViewTextBoxColumn
            // 
            this.缴费时间DataGridViewTextBoxColumn.CalendarTodayDate = new System.DateTime(2011, 8, 25, 0, 0, 0, 0);
            this.缴费时间DataGridViewTextBoxColumn.Checked = false;
            this.缴费时间DataGridViewTextBoxColumn.DataPropertyName = "缴费时间";
            this.缴费时间DataGridViewTextBoxColumn.HeaderText = "缴费时间";
            this.缴费时间DataGridViewTextBoxColumn.Name = "缴费时间DataGridViewTextBoxColumn";
            this.缴费时间DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.缴费时间DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.缴费时间DataGridViewTextBoxColumn.Width = 100;
            // 
            // 缴费项DataGridViewTextBoxColumn
            // 
            this.缴费项DataGridViewTextBoxColumn.DataPropertyName = "缴费项";
            this.缴费项DataGridViewTextBoxColumn.DropDownWidth = 121;
            this.缴费项DataGridViewTextBoxColumn.HeaderText = "缴费项";
            this.缴费项DataGridViewTextBoxColumn.Items.AddRange(new string[] {
            "房租",
            "物业费",
            "水",
            "电",
            "气",
            "宽带费",
            "中介费",
            "押金"});
            this.缴费项DataGridViewTextBoxColumn.Name = "缴费项DataGridViewTextBoxColumn";
            this.缴费项DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.缴费项DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.缴费项DataGridViewTextBoxColumn.Width = 80;
            // 
            // 缴费金额DataGridViewTextBoxColumn
            // 
            this.缴费金额DataGridViewTextBoxColumn.DataPropertyName = "缴费金额";
            this.缴费金额DataGridViewTextBoxColumn.DecimalPlaces = 2;
            this.缴费金额DataGridViewTextBoxColumn.HeaderText = "缴费金额";
            this.缴费金额DataGridViewTextBoxColumn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.缴费金额DataGridViewTextBoxColumn.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.缴费金额DataGridViewTextBoxColumn.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.缴费金额DataGridViewTextBoxColumn.Name = "缴费金额DataGridViewTextBoxColumn";
            this.缴费金额DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.缴费金额DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.缴费金额DataGridViewTextBoxColumn.ThousandsSeparator = true;
            this.缴费金额DataGridViewTextBoxColumn.Width = 80;
            // 
            // 期始DataGridViewTextBoxColumn
            // 
            this.期始DataGridViewTextBoxColumn.DataPropertyName = "期始";
            this.期始DataGridViewTextBoxColumn.HeaderText = "期始";
            this.期始DataGridViewTextBoxColumn.Mask = " 0000 / 00 / 00";
            this.期始DataGridViewTextBoxColumn.Name = "期始DataGridViewTextBoxColumn";
            this.期始DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.期始DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.期始DataGridViewTextBoxColumn.Width = 100;
            // 
            // 期止DataGridViewTextBoxColumn
            // 
            this.期止DataGridViewTextBoxColumn.DataPropertyName = "期止";
            this.期止DataGridViewTextBoxColumn.HeaderText = "期止";
            this.期止DataGridViewTextBoxColumn.Mask = " 0000 / 00 / 00";
            this.期止DataGridViewTextBoxColumn.Name = "期止DataGridViewTextBoxColumn";
            this.期止DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.期止DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.期止DataGridViewTextBoxColumn.Width = 100;
            // 
            // 付款人DataGridViewTextBoxColumn
            // 
            this.付款人DataGridViewTextBoxColumn.DataPropertyName = "付款人";
            this.付款人DataGridViewTextBoxColumn.HeaderText = "付款人";
            this.付款人DataGridViewTextBoxColumn.Name = "付款人DataGridViewTextBoxColumn";
            this.付款人DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.付款人DataGridViewTextBoxColumn.Width = 100;
            // 
            // 收款人DataGridViewTextBoxColumn
            // 
            this.收款人DataGridViewTextBoxColumn.DataPropertyName = "收款人";
            this.收款人DataGridViewTextBoxColumn.HeaderText = "收款人";
            this.收款人DataGridViewTextBoxColumn.Name = "收款人DataGridViewTextBoxColumn";
            this.收款人DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.收款人DataGridViewTextBoxColumn.Width = 100;
            // 
            // 备注DataGridViewTextBoxColumn
            // 
            this.备注DataGridViewTextBoxColumn.DataPropertyName = "备注";
            this.备注DataGridViewTextBoxColumn.HeaderText = "备注";
            this.备注DataGridViewTextBoxColumn.Name = "备注DataGridViewTextBoxColumn";
            this.备注DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.备注DataGridViewTextBoxColumn.Width = 100;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // 缴费明细Form
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(844, 426);
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Name = "缴费明细Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "源房缴费明细";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.缴费明细Form_FormClosed);
            this.Load += new System.EventHandler(this.缴费Form_Load);
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房缴费明细BindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.BindingSource 源房缴费明细BindingSource;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kryptonComboBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private System.Windows.Forms.ToolStripDropDownButton btnFilter;
        private System.Windows.Forms.ToolStripMenuItem 房租ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 物业费ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 水ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 电ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 气ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 宽带费ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中介费ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 押金ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 其他ToolStripMenuItem;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton raBtnOne;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton raBtnAll;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem 所有缴费项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewComboBoxColumn 源房;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn 缴费时间DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn 缴费项DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn 缴费金额DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewMaskedTextBoxColumn 期始DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewMaskedTextBoxColumn 期止DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn 付款人DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn 收款人DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn 备注DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}