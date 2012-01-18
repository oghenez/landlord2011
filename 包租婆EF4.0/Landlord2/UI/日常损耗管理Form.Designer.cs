namespace Landlord2.UI
{
    partial class 日常损耗管理Form
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
            System.Windows.Forms.Label 客房IDLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(日常损耗管理Form));
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.客房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.日常损耗BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.源房IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.客房IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.buttonSpecHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.nudFilterBegin = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.dtpFilterBegin = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFilterEnd = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.nudFilterEnd = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFilter备注 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFilter项目 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFilter客房 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnClearFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cmbFilter源房 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.日常损耗BindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorEditItem = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.支出金额DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.支出日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            客房IDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.客房BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.日常损耗BindingSource)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilter客房)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilter源房)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.日常损耗BindingNavigator)).BeginInit();
            this.日常损耗BindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord2.Data.源房);
            // 
            // 客房BindingSource
            // 
            this.客房BindingSource.DataSource = typeof(Landlord2.Data.客房);
            // 
            // 日常损耗BindingSource
            // 
            this.日常损耗BindingSource.DataSource = typeof(Landlord2.Data.日常损耗);
            this.日常损耗BindingSource.DataSourceChanged += new System.EventHandler(this.日常损耗BindingSource_DataSourceChanged);
            this.日常损耗BindingSource.CurrentChanged += new System.EventHandler(this.日常损耗BindingSource_CurrentChanged);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.kryptonDataGridView1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.kryptonHeaderGroup1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(783, 485);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(783, 510);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.日常损耗BindingNavigator);
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AllowUserToDeleteRows = false;
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.源房IDDataGridViewTextBoxColumn,
            this.客房IDDataGridViewTextBoxColumn,
            this.项目DataGridViewTextBoxColumn,
            this.支出金额DataGridViewTextBoxColumn,
            this.支出日期DataGridViewTextBoxColumn,
            this.备注DataGridViewTextBoxColumn});
            this.kryptonDataGridView1.DataSource = this.日常损耗BindingSource;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView1.MultiSelect = false;
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonDataGridView1.ReadOnly = true;
            this.kryptonDataGridView1.RowHeadersWidth = 24;
            this.kryptonDataGridView1.RowTemplate.Height = 23;
            this.kryptonDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(783, 386);
            this.kryptonDataGridView1.TabIndex = 0;
            this.kryptonDataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.kryptonDataGridView1_CellMouseDoubleClick);
            // 
            // 源房IDDataGridViewTextBoxColumn
            // 
            this.源房IDDataGridViewTextBoxColumn.DataPropertyName = "源房ID";
            this.源房IDDataGridViewTextBoxColumn.DataSource = this.源房BindingSource;
            this.源房IDDataGridViewTextBoxColumn.DisplayMember = "房名";
            this.源房IDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.源房IDDataGridViewTextBoxColumn.HeaderText = "源房";
            this.源房IDDataGridViewTextBoxColumn.Name = "源房IDDataGridViewTextBoxColumn";
            this.源房IDDataGridViewTextBoxColumn.ReadOnly = true;
            this.源房IDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.源房IDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.源房IDDataGridViewTextBoxColumn.ValueMember = "ID";
            this.源房IDDataGridViewTextBoxColumn.Width = 150;
            // 
            // 客房IDDataGridViewTextBoxColumn
            // 
            this.客房IDDataGridViewTextBoxColumn.DataPropertyName = "客房ID";
            this.客房IDDataGridViewTextBoxColumn.DataSource = this.客房BindingSource;
            this.客房IDDataGridViewTextBoxColumn.DisplayMember = "命名";
            this.客房IDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.客房IDDataGridViewTextBoxColumn.HeaderText = "客房";
            this.客房IDDataGridViewTextBoxColumn.Name = "客房IDDataGridViewTextBoxColumn";
            this.客房IDDataGridViewTextBoxColumn.ReadOnly = true;
            this.客房IDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.客房IDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.客房IDDataGridViewTextBoxColumn.ValueMember = "ID";
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.AutoSize = true;
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.buttonSpecHeaderGroup1});
            this.kryptonHeaderGroup1.CollapseTarget = ComponentFactory.Krypton.Toolkit.HeaderGroupCollapsedTarget.CollapsedToSecondary;
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonHeaderGroup1.HeaderVisiblePrimary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 386);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.nudFilterBegin);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dtpFilterBegin);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label6);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label4);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dtpFilterEnd);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label5);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.nudFilterEnd);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label3);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.tbFilter备注);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label2);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.tbFilter项目);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label7);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.cmbFilter客房);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnClearFilter);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnFilter);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.cmbFilter源房);
            this.kryptonHeaderGroup1.Panel.Controls.Add(客房IDLabel);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label1);
            this.kryptonHeaderGroup1.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(783, 99);
            this.kryptonHeaderGroup1.StateCommon.HeaderPrimary.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonHeaderGroup1.StateCommon.HeaderSecondary.Content.LongText.Color1 = System.Drawing.Color.Yellow;
            this.kryptonHeaderGroup1.StateCommon.HeaderSecondary.Content.LongText.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.kryptonHeaderGroup1.StateCommon.HeaderSecondary.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonHeaderGroup1.TabIndex = 1;
            this.kryptonHeaderGroup1.ValuesPrimary.Description = "无过滤条件";
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "所有源房";
            this.kryptonHeaderGroup1.ValuesSecondary.Description = "0.00";
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "当前损耗合计支出：";
            // 
            // buttonSpecHeaderGroup1
            // 
            this.buttonSpecHeaderGroup1.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.buttonSpecHeaderGroup1.Text = "筛选器";
            this.buttonSpecHeaderGroup1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowDown;
            this.buttonSpecHeaderGroup1.UniqueName = "6C057C3535974483B2874F123D341863";
            // 
            // nudFilterBegin
            // 
            this.nudFilterBegin.Location = new System.Drawing.Point(281, 39);
            this.nudFilterBegin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudFilterBegin.Name = "nudFilterBegin";
            this.nudFilterBegin.Size = new System.Drawing.Size(110, 22);
            this.nudFilterBegin.TabIndex = 4;
            // 
            // dtpFilterBegin
            // 
            this.dtpFilterBegin.Checked = false;
            this.dtpFilterBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterBegin.Location = new System.Drawing.Point(281, 9);
            this.dtpFilterBegin.Name = "dtpFilterBegin";
            this.dtpFilterBegin.ShowCheckBox = true;
            this.dtpFilterBegin.Size = new System.Drawing.Size(110, 21);
            this.dtpFilterBegin.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(392, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "～";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(392, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "～";
            // 
            // dtpFilterEnd
            // 
            this.dtpFilterEnd.Checked = false;
            this.dtpFilterEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterEnd.Location = new System.Drawing.Point(410, 9);
            this.dtpFilterEnd.Name = "dtpFilterEnd";
            this.dtpFilterEnd.ShowCheckBox = true;
            this.dtpFilterEnd.Size = new System.Drawing.Size(110, 21);
            this.dtpFilterEnd.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(219, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "支出金额：";
            // 
            // nudFilterEnd
            // 
            this.nudFilterEnd.Location = new System.Drawing.Point(410, 39);
            this.nudFilterEnd.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudFilterEnd.Name = "nudFilterEnd";
            this.nudFilterEnd.Size = new System.Drawing.Size(110, 22);
            this.nudFilterEnd.TabIndex = 5;
            this.nudFilterEnd.Value = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(219, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "支出日期：";
            // 
            // tbFilter备注
            // 
            this.tbFilter备注.Location = new System.Drawing.Point(581, 38);
            this.tbFilter备注.Name = "tbFilter备注";
            this.tbFilter备注.Size = new System.Drawing.Size(100, 20);
            this.tbFilter备注.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(543, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "备注：";
            // 
            // tbFilter项目
            // 
            this.tbFilter项目.Location = new System.Drawing.Point(581, 10);
            this.tbFilter项目.Name = "tbFilter项目";
            this.tbFilter项目.Size = new System.Drawing.Size(100, 20);
            this.tbFilter项目.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(543, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "项目：";
            // 
            // cmbFilter客房
            // 
            this.cmbFilter客房.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter客房.DropDownWidth = 134;
            this.cmbFilter客房.Location = new System.Drawing.Point(57, 40);
            this.cmbFilter客房.Name = "cmbFilter客房";
            this.cmbFilter客房.Size = new System.Drawing.Size(136, 21);
            this.cmbFilter客房.TabIndex = 1;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.AutoSize = true;
            this.btnClearFilter.Location = new System.Drawing.Point(704, 38);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(62, 25);
            this.btnClearFilter.TabIndex = 9;
            this.btnClearFilter.Values.Text = "清空筛选";
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.AutoSize = true;
            this.btnFilter.Location = new System.Drawing.Point(704, 4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(62, 30);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Values.Image = global::Landlord2.Properties.Resources.Filter;
            this.btnFilter.Values.Text = "筛选";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cmbFilter源房
            // 
            this.cmbFilter源房.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter源房.DropDownWidth = 121;
            this.cmbFilter源房.Location = new System.Drawing.Point(57, 9);
            this.cmbFilter源房.Name = "cmbFilter源房";
            this.cmbFilter源房.Size = new System.Drawing.Size(136, 21);
            this.cmbFilter源房.TabIndex = 0;
            this.cmbFilter源房.SelectedIndexChanged += new System.EventHandler(this.cmbFilter源房_SelectedIndexChanged);
            // 
            // 客房IDLabel
            // 
            客房IDLabel.AutoSize = true;
            客房IDLabel.Location = new System.Drawing.Point(20, 44);
            客房IDLabel.Name = "客房IDLabel";
            客房IDLabel.Size = new System.Drawing.Size(41, 12);
            客房IDLabel.TabIndex = 19;
            客房IDLabel.Text = "客房：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(20, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "源房：";
            // 
            // 日常损耗BindingNavigator
            // 
            this.日常损耗BindingNavigator.AddNewItem = null;
            this.日常损耗BindingNavigator.AutoSize = false;
            this.日常损耗BindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.日常损耗BindingNavigator.DeleteItem = null;
            this.日常损耗BindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.日常损耗BindingNavigator.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.日常损耗BindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.bindingNavigatorEditItem});
            this.日常损耗BindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.日常损耗BindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.日常损耗BindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.日常损耗BindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.日常损耗BindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.日常损耗BindingNavigator.Name = "日常损耗BindingNavigator";
            this.日常损耗BindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.日常损耗BindingNavigator.Size = new System.Drawing.Size(783, 25);
            this.日常损耗BindingNavigator.Stretch = true;
            this.日常损耗BindingNavigator.TabIndex = 1;
            this.日常损耗BindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 16);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.Image = global::Landlord2.Properties.Resources.add_16_hot;
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(51, 22);
            this.bindingNavigatorAddNewItem.Text = "新增";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.Image = global::Landlord2.Properties.Resources.delete_16_hot;
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(51, 22);
            this.bindingNavigatorDeleteItem.Text = "删除";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // bindingNavigatorEditItem
            // 
            this.bindingNavigatorEditItem.Image = global::Landlord2.Properties.Resources.edit_16_hot;
            this.bindingNavigatorEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bindingNavigatorEditItem.Name = "bindingNavigatorEditItem";
            this.bindingNavigatorEditItem.Size = new System.Drawing.Size(51, 22);
            this.bindingNavigatorEditItem.Text = "编辑";
            this.bindingNavigatorEditItem.Click += new System.EventHandler(this.bindingNavigatorEditItem_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "项目";
            this.dataGridViewTextBoxColumn1.HeaderText = "项目";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "支出金额";
            this.dataGridViewTextBoxColumn2.HeaderText = "支出金额";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "支出日期";
            this.dataGridViewTextBoxColumn3.HeaderText = "支出日期";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "备注";
            this.dataGridViewTextBoxColumn4.HeaderText = "备注";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // 项目DataGridViewTextBoxColumn
            // 
            this.项目DataGridViewTextBoxColumn.DataPropertyName = "项目";
            this.项目DataGridViewTextBoxColumn.HeaderText = "项目";
            this.项目DataGridViewTextBoxColumn.Name = "项目DataGridViewTextBoxColumn";
            this.项目DataGridViewTextBoxColumn.ReadOnly = true;
            this.项目DataGridViewTextBoxColumn.Width = 150;
            // 
            // 支出金额DataGridViewTextBoxColumn
            // 
            this.支出金额DataGridViewTextBoxColumn.DataPropertyName = "支出金额";
            this.支出金额DataGridViewTextBoxColumn.HeaderText = "支出金额";
            this.支出金额DataGridViewTextBoxColumn.Name = "支出金额DataGridViewTextBoxColumn";
            this.支出金额DataGridViewTextBoxColumn.ReadOnly = true;
            this.支出金额DataGridViewTextBoxColumn.Width = 80;
            // 
            // 支出日期DataGridViewTextBoxColumn
            // 
            this.支出日期DataGridViewTextBoxColumn.DataPropertyName = "支出日期";
            this.支出日期DataGridViewTextBoxColumn.HeaderText = "支出日期";
            this.支出日期DataGridViewTextBoxColumn.Name = "支出日期DataGridViewTextBoxColumn";
            this.支出日期DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 备注DataGridViewTextBoxColumn
            // 
            this.备注DataGridViewTextBoxColumn.DataPropertyName = "备注";
            this.备注DataGridViewTextBoxColumn.HeaderText = "备注";
            this.备注DataGridViewTextBoxColumn.Name = "备注DataGridViewTextBoxColumn";
            this.备注DataGridViewTextBoxColumn.ReadOnly = true;
            this.备注DataGridViewTextBoxColumn.Width = 200;
            // 
            // 日常损耗管理Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 510);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "日常损耗管理Form";
            this.Text = "日常损耗管理";
            this.Load += new System.EventHandler(this.日常损耗管理Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.客房BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.日常损耗BindingSource)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilter客房)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilter源房)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.日常损耗BindingNavigator)).EndInit();
            this.日常损耗BindingNavigator.ResumeLayout(false);
            this.日常损耗BindingNavigator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.BindingSource 日常损耗BindingSource;
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFilter;
        private System.Windows.Forms.BindingNavigator 日常损耗BindingNavigator;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorEditItem;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClearFilter;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbFilter源房;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewComboBoxColumn 源房IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn 客房IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource 客房BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 支出金额DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 支出日期DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbFilter客房;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbFilter项目;
        private System.Windows.Forms.Label label7;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nudFilterBegin;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpFilterBegin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpFilterEnd;
        private System.Windows.Forms.Label label5;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nudFilterEnd;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbFilter备注;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}