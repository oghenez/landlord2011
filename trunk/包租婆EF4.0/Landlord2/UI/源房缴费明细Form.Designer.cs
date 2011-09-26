namespace Landlord2.UI
{
    partial class 源房缴费明细Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(源房缴费明细Form));
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.labCountMoney = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmbYF = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.raBtnOne = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.raBtnAll = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.源房Column = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.缴费时间DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn();
            this.缴费项DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.缴费金额DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn();
            this.期始DataGridViewTextBoxColumn = new Landlord2.MyDataGridViewDateTimePickerColumn();
            this.期止DataGridViewTextBoxColumn = new Landlord2.MyDataGridViewDateTimePickerColumn();
            this.付款人DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.收款人DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.备注DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myDataGridViewDateTimePickerColumn1 = new Landlord2.MyDataGridViewDateTimePickerColumn();
            this.myDataGridViewDateTimePickerColumn2 = new Landlord2.MyDataGridViewDateTimePickerColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房缴费明细BindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYF)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord2.Data.源房);
            // 
            // 源房缴费明细BindingSource
            // 
            this.源房缴费明细BindingSource.DataSource = typeof(Landlord2.Data.源房缴费明细);
            this.源房缴费明细BindingSource.Sort = "";
            this.源房缴费明细BindingSource.DataSourceChanged += new System.EventHandler(this.源房缴费明细BindingSource_DataSourceChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFilter,
            this.labCountMoney});
            this.statusStrip1.Location = new System.Drawing.Point(0, 352);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.ShowItemToolTips = true;
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
            this.所有缴费项ToolStripMenuItem.Click += new System.EventHandler(this.btnFilter_Click);
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
            this.房租ToolStripMenuItem.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // 物业费ToolStripMenuItem
            // 
            this.物业费ToolStripMenuItem.Name = "物业费ToolStripMenuItem";
            this.物业费ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.物业费ToolStripMenuItem.Text = "物业费";
            this.物业费ToolStripMenuItem.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // 水ToolStripMenuItem
            // 
            this.水ToolStripMenuItem.Name = "水ToolStripMenuItem";
            this.水ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.水ToolStripMenuItem.Text = "水";
            this.水ToolStripMenuItem.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // 电ToolStripMenuItem
            // 
            this.电ToolStripMenuItem.Name = "电ToolStripMenuItem";
            this.电ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.电ToolStripMenuItem.Text = "电";
            this.电ToolStripMenuItem.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // 气ToolStripMenuItem
            // 
            this.气ToolStripMenuItem.Name = "气ToolStripMenuItem";
            this.气ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.气ToolStripMenuItem.Text = "气";
            this.气ToolStripMenuItem.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // 宽带费ToolStripMenuItem
            // 
            this.宽带费ToolStripMenuItem.Name = "宽带费ToolStripMenuItem";
            this.宽带费ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.宽带费ToolStripMenuItem.Text = "宽带费";
            this.宽带费ToolStripMenuItem.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // 中介费ToolStripMenuItem
            // 
            this.中介费ToolStripMenuItem.Name = "中介费ToolStripMenuItem";
            this.中介费ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.中介费ToolStripMenuItem.Text = "中介费";
            this.中介费ToolStripMenuItem.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // 押金ToolStripMenuItem
            // 
            this.押金ToolStripMenuItem.Name = "押金ToolStripMenuItem";
            this.押金ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.押金ToolStripMenuItem.Text = "押金";
            this.押金ToolStripMenuItem.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // 其他ToolStripMenuItem
            // 
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.其他ToolStripMenuItem.Text = "其他";
            this.其他ToolStripMenuItem.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // labCountMoney
            // 
            this.labCountMoney.AutoToolTip = true;
            this.labCountMoney.Name = "labCountMoney";
            this.labCountMoney.Size = new System.Drawing.Size(664, 27);
            this.labCountMoney.Spring = true;
            this.labCountMoney.ToolTipText = "合计当前列表显示的项目金额";
            // 
            // cmbYF
            // 
            this.cmbYF.DataSource = this.源房BindingSource;
            this.cmbYF.DisplayMember = "房名";
            this.cmbYF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYF.DropDownWidth = 215;
            this.cmbYF.Enabled = false;
            this.cmbYF.Location = new System.Drawing.Point(180, 20);
            this.cmbYF.Name = "cmbYF";
            this.cmbYF.Size = new System.Drawing.Size(215, 21);
            this.cmbYF.TabIndex = 9;
            this.toolTip1.SetToolTip(this.cmbYF, "指定单套源房后，可直接进行‘添加’操作。");
            this.cmbYF.ValueMember = "ID";
            this.cmbYF.SelectedIndexChanged += new System.EventHandler(this.cmbYF_SelectedIndexChanged);
            // 
            // raBtnOne
            // 
            this.raBtnOne.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.raBtnOne.Location = new System.Drawing.Point(102, 20);
            this.raBtnOne.Name = "raBtnOne";
            this.raBtnOne.Size = new System.Drawing.Size(85, 20);
            this.raBtnOne.TabIndex = 1;
            this.toolTip1.SetToolTip(this.raBtnOne, "指定单套源房后，可直接进行‘添加’操作。");
            this.raBtnOne.Values.Text = "单套源房：";
            // 
            // raBtnAll
            // 
            this.raBtnAll.Checked = true;
            this.raBtnAll.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.raBtnAll.Location = new System.Drawing.Point(12, 20);
            this.raBtnAll.Name = "raBtnAll";
            this.raBtnAll.Size = new System.Drawing.Size(72, 20);
            this.raBtnAll.TabIndex = 0;
            this.raBtnAll.Values.Text = "全部源房";
            this.raBtnAll.CheckedChanged += new System.EventHandler(this.raBtn_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(717, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(582, 18);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Values.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbYF);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.raBtnOne);
            this.panel1.Controls.Add(this.BtnAdd);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.raBtnAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 60);
            this.panel1.TabIndex = 1;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.Location = new System.Drawing.Point(447, 18);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(90, 25);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Values.Text = "新增";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.源房Column,
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
            this.kryptonDataGridView1.MultiSelect = false;
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonDataGridView1.RowHeadersWidth = 24;
            this.kryptonDataGridView1.RowTemplate.Height = 23;
            this.kryptonDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(844, 352);
            this.kryptonDataGridView1.TabIndex = 0;
            this.kryptonDataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.kryptonDataGridView1_CellEndEdit);
            this.kryptonDataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.kryptonDataGridView1_CellMouseDoubleClick);
            this.kryptonDataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.kryptonDataGridView1_UserDeletedRow);
            // 
            // 源房Column
            // 
            this.源房Column.DataPropertyName = "源房ID";
            this.源房Column.DataSource = this.源房BindingSource;
            this.源房Column.DisplayMember = "房名";
            this.源房Column.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.源房Column.HeaderText = "源房";
            this.源房Column.Name = "源房Column";
            this.源房Column.ReadOnly = true;
            this.源房Column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.源房Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.源房Column.ValueMember = "ID";
            // 
            // 缴费时间DataGridViewTextBoxColumn
            // 
            this.缴费时间DataGridViewTextBoxColumn.CalendarTodayDate = new System.DateTime(2011, 8, 25, 0, 0, 0, 0);
            this.缴费时间DataGridViewTextBoxColumn.Checked = false;
            this.缴费时间DataGridViewTextBoxColumn.DataPropertyName = "缴费时间";
            this.缴费时间DataGridViewTextBoxColumn.HeaderText = "缴费时间";
            this.缴费时间DataGridViewTextBoxColumn.MaxDate = new System.DateTime(2030, 12, 31, 23, 59, 0, 0);
            this.缴费时间DataGridViewTextBoxColumn.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.缴费时间DataGridViewTextBoxColumn.Name = "缴费时间DataGridViewTextBoxColumn";
            this.缴费时间DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.缴费时间DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.缴费时间DataGridViewTextBoxColumn.Width = 100;
            // 
            // 缴费项DataGridViewTextBoxColumn
            // 
            this.缴费项DataGridViewTextBoxColumn.DataPropertyName = "缴费项";
            this.缴费项DataGridViewTextBoxColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.期始DataGridViewTextBoxColumn.Checked = false;
            this.期始DataGridViewTextBoxColumn.DataPropertyName = "期始";
            this.期始DataGridViewTextBoxColumn.HeaderText = "期始";
            this.期始DataGridViewTextBoxColumn.MaxDate = new System.DateTime(2030, 12, 31, 23, 59, 0, 0);
            this.期始DataGridViewTextBoxColumn.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.期始DataGridViewTextBoxColumn.Name = "期始DataGridViewTextBoxColumn";
            this.期始DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.期始DataGridViewTextBoxColumn.ShowCheckBox = true;
            this.期始DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.期始DataGridViewTextBoxColumn.Width = 100;
            // 
            // 期止DataGridViewTextBoxColumn
            // 
            this.期止DataGridViewTextBoxColumn.Checked = false;
            this.期止DataGridViewTextBoxColumn.DataPropertyName = "期止";
            this.期止DataGridViewTextBoxColumn.HeaderText = "期止";
            this.期止DataGridViewTextBoxColumn.MaxDate = new System.DateTime(2030, 12, 31, 23, 59, 0, 0);
            this.期止DataGridViewTextBoxColumn.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.期止DataGridViewTextBoxColumn.Name = "期止DataGridViewTextBoxColumn";
            this.期止DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.期止DataGridViewTextBoxColumn.ShowCheckBox = true;
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
            // myDataGridViewDateTimePickerColumn1
            // 
            this.myDataGridViewDateTimePickerColumn1.Checked = false;
            this.myDataGridViewDateTimePickerColumn1.DataPropertyName = "期始";
            this.myDataGridViewDateTimePickerColumn1.HeaderText = "期始";
            this.myDataGridViewDateTimePickerColumn1.MaxDate = new System.DateTime(2030, 12, 31, 23, 59, 0, 0);
            this.myDataGridViewDateTimePickerColumn1.Name = "myDataGridViewDateTimePickerColumn1";
            this.myDataGridViewDateTimePickerColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.myDataGridViewDateTimePickerColumn1.ShowCheckBox = true;
            this.myDataGridViewDateTimePickerColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.myDataGridViewDateTimePickerColumn1.Width = 100;
            // 
            // myDataGridViewDateTimePickerColumn2
            // 
            this.myDataGridViewDateTimePickerColumn2.Checked = false;
            this.myDataGridViewDateTimePickerColumn2.DataPropertyName = "期止";
            this.myDataGridViewDateTimePickerColumn2.HeaderText = "期止";
            this.myDataGridViewDateTimePickerColumn2.MaxDate = new System.DateTime(2030, 12, 31, 23, 59, 0, 0);
            this.myDataGridViewDateTimePickerColumn2.Name = "myDataGridViewDateTimePickerColumn2";
            this.myDataGridViewDateTimePickerColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.myDataGridViewDateTimePickerColumn2.ShowCheckBox = true;
            this.myDataGridViewDateTimePickerColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.myDataGridViewDateTimePickerColumn2.Width = 100;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // 源房缴费明细Form
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 444);
            this.Controls.Add(this.kryptonDataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "源房缴费明细Form";
            this.Text = "源房缴费明细";
            this.Load += new System.EventHandler(this.缴费Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房缴费明细BindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYF)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource 源房缴费明细BindingSource;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labCountMoney;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbYF;
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
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private MyDataGridViewDateTimePickerColumn myDataGridViewDateTimePickerColumn1;
        private MyDataGridViewDateTimePickerColumn myDataGridViewDateTimePickerColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnAdd;
        private System.Windows.Forms.DataGridViewComboBoxColumn 源房Column;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn 缴费时间DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn 缴费项DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn 缴费金额DataGridViewTextBoxColumn;
        private MyDataGridViewDateTimePickerColumn 期始DataGridViewTextBoxColumn;
        private MyDataGridViewDateTimePickerColumn 期止DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn 付款人DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn 收款人DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn 备注DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}