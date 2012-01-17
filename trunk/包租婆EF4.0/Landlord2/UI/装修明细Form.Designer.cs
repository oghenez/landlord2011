namespace Landlord2.UI
{
    partial class 装修明细Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(装修明细Form));
            this.装修明细BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.装修明细BindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.源房IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.装修分类DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.项目名称DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.规格DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数量DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单位DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单价DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.购买地点DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.buttonSpecHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.nudFilterBegin = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.cmbFilter装修分类 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnClearFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tbFilter地点 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbFilter规格 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFilterBegin = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFilter源房 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFilterEnd = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudFilterEnd = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.装修明细BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.装修明细BindingNavigator)).BeginInit();
            this.装修明细BindingNavigator.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilter装修分类)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilter源房)).BeginInit();
            this.SuspendLayout();
            // 
            // 装修明细BindingSource
            // 
            this.装修明细BindingSource.DataSource = typeof(Landlord2.Data.装修明细);
            this.装修明细BindingSource.DataSourceChanged += new System.EventHandler(this.装修明细BindingSource_DataSourceChanged);
            this.装修明细BindingSource.CurrentChanged += new System.EventHandler(this.装修明细BindingSource_CurrentChanged);
            // 
            // 装修明细BindingNavigator
            // 
            this.装修明细BindingNavigator.AddNewItem = null;
            this.装修明细BindingNavigator.AutoSize = false;
            this.装修明细BindingNavigator.BindingSource = this.装修明细BindingSource;
            this.装修明细BindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.装修明细BindingNavigator.DeleteItem = null;
            this.装修明细BindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.装修明细BindingNavigator.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.装修明细BindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.装修明细BindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.装修明细BindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.装修明细BindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.装修明细BindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.装修明细BindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.装修明细BindingNavigator.Name = "装修明细BindingNavigator";
            this.装修明细BindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.装修明细BindingNavigator.Size = new System.Drawing.Size(783, 25);
            this.装修明细BindingNavigator.Stretch = true;
            this.装修明细BindingNavigator.TabIndex = 2;
            this.装修明细BindingNavigator.Text = "bindingNavigator1";
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
            this.toolStripContainer1.TabIndex = 11;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.装修明细BindingNavigator);
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AllowUserToDeleteRows = false;
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.日期DataGridViewTextBoxColumn,
            this.源房IDDataGridViewTextBoxColumn,
            this.装修分类DataGridViewTextBoxColumn,
            this.项目名称DataGridViewTextBoxColumn,
            this.规格DataGridViewTextBoxColumn,
            this.数量DataGridViewTextBoxColumn,
            this.单位DataGridViewTextBoxColumn,
            this.单价DataGridViewTextBoxColumn,
            this.购买地点DataGridViewTextBoxColumn,
            this.备注DataGridViewTextBoxColumn});
            this.kryptonDataGridView1.DataSource = this.装修明细BindingSource;
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
            // 日期DataGridViewTextBoxColumn
            // 
            this.日期DataGridViewTextBoxColumn.DataPropertyName = "日期";
            this.日期DataGridViewTextBoxColumn.HeaderText = "日期";
            this.日期DataGridViewTextBoxColumn.Name = "日期DataGridViewTextBoxColumn";
            this.日期DataGridViewTextBoxColumn.ReadOnly = true;
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
            this.源房IDDataGridViewTextBoxColumn.Width = 200;
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord2.Data.源房);
            // 
            // 装修分类DataGridViewTextBoxColumn
            // 
            this.装修分类DataGridViewTextBoxColumn.DataPropertyName = "装修分类";
            this.装修分类DataGridViewTextBoxColumn.HeaderText = "装修分类";
            this.装修分类DataGridViewTextBoxColumn.Name = "装修分类DataGridViewTextBoxColumn";
            this.装修分类DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 项目名称DataGridViewTextBoxColumn
            // 
            this.项目名称DataGridViewTextBoxColumn.DataPropertyName = "项目名称";
            this.项目名称DataGridViewTextBoxColumn.HeaderText = "款项";
            this.项目名称DataGridViewTextBoxColumn.Name = "项目名称DataGridViewTextBoxColumn";
            this.项目名称DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 规格DataGridViewTextBoxColumn
            // 
            this.规格DataGridViewTextBoxColumn.DataPropertyName = "规格";
            this.规格DataGridViewTextBoxColumn.HeaderText = "规格";
            this.规格DataGridViewTextBoxColumn.Name = "规格DataGridViewTextBoxColumn";
            this.规格DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 数量DataGridViewTextBoxColumn
            // 
            this.数量DataGridViewTextBoxColumn.DataPropertyName = "数量";
            this.数量DataGridViewTextBoxColumn.HeaderText = "数量";
            this.数量DataGridViewTextBoxColumn.Name = "数量DataGridViewTextBoxColumn";
            this.数量DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 单位DataGridViewTextBoxColumn
            // 
            this.单位DataGridViewTextBoxColumn.DataPropertyName = "单位";
            this.单位DataGridViewTextBoxColumn.HeaderText = "单位";
            this.单位DataGridViewTextBoxColumn.Name = "单位DataGridViewTextBoxColumn";
            this.单位DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 单价DataGridViewTextBoxColumn
            // 
            this.单价DataGridViewTextBoxColumn.DataPropertyName = "单价";
            this.单价DataGridViewTextBoxColumn.HeaderText = "单价";
            this.单价DataGridViewTextBoxColumn.Name = "单价DataGridViewTextBoxColumn";
            this.单价DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 购买地点DataGridViewTextBoxColumn
            // 
            this.购买地点DataGridViewTextBoxColumn.DataPropertyName = "购买地点";
            this.购买地点DataGridViewTextBoxColumn.HeaderText = "购买地点";
            this.购买地点DataGridViewTextBoxColumn.Name = "购买地点DataGridViewTextBoxColumn";
            this.购买地点DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 备注DataGridViewTextBoxColumn
            // 
            this.备注DataGridViewTextBoxColumn.DataPropertyName = "备注";
            this.备注DataGridViewTextBoxColumn.HeaderText = "备注";
            this.备注DataGridViewTextBoxColumn.Name = "备注DataGridViewTextBoxColumn";
            this.备注DataGridViewTextBoxColumn.ReadOnly = true;
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
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.cmbFilter装修分类);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnClearFilter);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnFilter);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.tbFilter地点);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.tbFilter规格);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label2);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dtpFilterBegin);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label8);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label6);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.cmbFilter源房);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label4);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label7);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dtpFilterEnd);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label1);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label5);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.nudFilterEnd);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label3);
            this.kryptonHeaderGroup1.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(783, 99);
            this.kryptonHeaderGroup1.StateCommon.HeaderPrimary.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonHeaderGroup1.StateCommon.HeaderSecondary.Content.LongText.Color1 = System.Drawing.Color.Yellow;
            this.kryptonHeaderGroup1.StateCommon.HeaderSecondary.Content.LongText.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.kryptonHeaderGroup1.StateCommon.HeaderSecondary.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Description = "无过滤条件";
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "所有源房";
            this.kryptonHeaderGroup1.ValuesSecondary.Description = "0.00";
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "当前装修合计支出：";
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
            this.nudFilterBegin.Location = new System.Drawing.Point(526, 39);
            this.nudFilterBegin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudFilterBegin.Name = "nudFilterBegin";
            this.nudFilterBegin.Size = new System.Drawing.Size(65, 22);
            this.nudFilterBegin.TabIndex = 3;
            // 
            // cmbFilter装修分类
            // 
            this.cmbFilter装修分类.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter装修分类.DropDownWidth = 121;
            this.cmbFilter装修分类.Location = new System.Drawing.Point(72, 40);
            this.cmbFilter装修分类.Name = "cmbFilter装修分类";
            this.cmbFilter装修分类.Size = new System.Drawing.Size(136, 21);
            this.cmbFilter装修分类.TabIndex = 0;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.AutoSize = true;
            this.btnClearFilter.Location = new System.Drawing.Point(704, 38);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(62, 25);
            this.btnClearFilter.TabIndex = 5;
            this.btnClearFilter.Values.Text = "清空筛选";
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.AutoSize = true;
            this.btnFilter.Location = new System.Drawing.Point(704, 4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(62, 30);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Values.Image = global::Landlord2.Properties.Resources.Filter;
            this.btnFilter.Values.Text = "筛选";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // tbFilter地点
            // 
            this.tbFilter地点.Location = new System.Drawing.Point(278, 40);
            this.tbFilter地点.Name = "tbFilter地点";
            this.tbFilter地点.Size = new System.Drawing.Size(100, 20);
            this.tbFilter地点.TabIndex = 4;
            // 
            // tbFilter规格
            // 
            this.tbFilter规格.Location = new System.Drawing.Point(278, 9);
            this.tbFilter规格.Name = "tbFilter规格";
            this.tbFilter规格.Size = new System.Drawing.Size(100, 20);
            this.tbFilter规格.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(11, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "装修分类：";
            // 
            // dtpFilterBegin
            // 
            this.dtpFilterBegin.Checked = false;
            this.dtpFilterBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterBegin.Location = new System.Drawing.Point(431, 9);
            this.dtpFilterBegin.Name = "dtpFilterBegin";
            this.dtpFilterBegin.ShowCheckBox = true;
            this.dtpFilterBegin.Size = new System.Drawing.Size(115, 21);
            this.dtpFilterBegin.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(218, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "购买地点：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(594, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "～";
            // 
            // cmbFilter源房
            // 
            this.cmbFilter源房.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter源房.DropDownWidth = 121;
            this.cmbFilter源房.Location = new System.Drawing.Point(72, 9);
            this.cmbFilter源房.Name = "cmbFilter源房";
            this.cmbFilter源房.Size = new System.Drawing.Size(136, 21);
            this.cmbFilter源房.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(547, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "～";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(242, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "规格：";
            // 
            // dtpFilterEnd
            // 
            this.dtpFilterEnd.Checked = false;
            this.dtpFilterEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterEnd.Location = new System.Drawing.Point(565, 9);
            this.dtpFilterEnd.Name = "dtpFilterEnd";
            this.dtpFilterEnd.ShowCheckBox = true;
            this.dtpFilterEnd.Size = new System.Drawing.Size(115, 21);
            this.dtpFilterEnd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(35, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "源房：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(393, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "款项金额(单价×数量)：";
            // 
            // nudFilterEnd
            // 
            this.nudFilterEnd.Location = new System.Drawing.Point(615, 39);
            this.nudFilterEnd.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudFilterEnd.Name = "nudFilterEnd";
            this.nudFilterEnd.Size = new System.Drawing.Size(65, 22);
            this.nudFilterEnd.TabIndex = 3;
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
            this.label3.Location = new System.Drawing.Point(393, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "日期：";
            // 
            // 装修明细Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(783, 510);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "装修明细Form";
            this.Text = "装修明细";
            this.Load += new System.EventHandler(this.装修明细Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.装修明细BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.装修明细BindingNavigator)).EndInit();
            this.装修明细BindingNavigator.ResumeLayout(false);
            this.装修明细BindingNavigator.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilter装修分类)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilter源房)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource 装修明细BindingSource;
        private System.Windows.Forms.BindingNavigator 装修明细BindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorEditItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbFilter源房;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpFilterEnd;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpFilterBegin;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbFilter装修分类;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbFilter地点;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbFilter规格;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nudFilterEnd;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nudFilterBegin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn 日期DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn 源房IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn 装修分类DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 项目名称DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 规格DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数量DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单位DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单价DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 购买地点DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClearFilter;
    }
}