namespace Landlord2.UI
{
    partial class 源房抄表明细Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(源房抄表明细Form));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.源房抄表BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.buttonSpecHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnClearFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnFilter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dtpFilterBegin = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.cmbFilter源房 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFilterEnd = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.源房抄表BindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.抄表时间DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.源房DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.水止码DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.水账户余额DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.电止码DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.电账户余额DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.气表剩余字数DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.抄表人DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房抄表BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilter源房)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房抄表BindingNavigator)).BeginInit();
            this.源房抄表BindingNavigator.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.源房抄表BindingNavigator);
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AllowUserToDeleteRows = false;
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.抄表时间DataGridViewTextBoxColumn,
            this.源房DataGridViewTextBoxColumn,
            this.水止码DataGridViewTextBoxColumn,
            this.水账户余额DataGridViewTextBoxColumn,
            this.电止码DataGridViewTextBoxColumn,
            this.电账户余额DataGridViewTextBoxColumn,
            this.气表剩余字数DataGridViewTextBoxColumn,
            this.抄表人DataGridViewTextBoxColumn,
            this.备注DataGridViewTextBoxColumn});
            this.kryptonDataGridView1.DataSource = this.源房抄表BindingSource;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView1.MultiSelect = false;
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonDataGridView1.ReadOnly = true;
            this.kryptonDataGridView1.RowHeadersWidth = 24;
            this.kryptonDataGridView1.RowTemplate.Height = 23;
            this.kryptonDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(783, 412);
            this.kryptonDataGridView1.TabIndex = 2;
            this.kryptonDataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.kryptonDataGridView1_CellMouseDoubleClick);
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord2.Data.源房);
            // 
            // 源房抄表BindingSource
            // 
            this.源房抄表BindingSource.DataSource = typeof(Landlord2.Data.源房抄表);
            this.源房抄表BindingSource.DataSourceChanged += new System.EventHandler(this.源房抄表BindingSource_DataSourceChanged);
            this.源房抄表BindingSource.CurrentChanged += new System.EventHandler(this.源房抄表BindingSource_CurrentChanged);
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.AutoSize = true;
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.buttonSpecHeaderGroup1});
            this.kryptonHeaderGroup1.CollapseTarget = ComponentFactory.Krypton.Toolkit.HeaderGroupCollapsedTarget.CollapsedToSecondary;
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonHeaderGroup1.HeaderVisiblePrimary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 412);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnClearFilter);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.btnFilter);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dtpFilterBegin);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.cmbFilter源房);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label4);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dtpFilterEnd);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label1);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label3);
            this.kryptonHeaderGroup1.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(783, 73);
            this.kryptonHeaderGroup1.StateCommon.HeaderPrimary.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonHeaderGroup1.StateCommon.HeaderSecondary.Content.LongText.Color1 = System.Drawing.Color.Yellow;
            this.kryptonHeaderGroup1.StateCommon.HeaderSecondary.Content.LongText.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F);
            this.kryptonHeaderGroup1.StateCommon.HeaderSecondary.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonHeaderGroup1.TabIndex = 1;
            this.kryptonHeaderGroup1.ValuesPrimary.Description = "无过滤条件";
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "所有源房";
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "";
            // 
            // buttonSpecHeaderGroup1
            // 
            this.buttonSpecHeaderGroup1.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.buttonSpecHeaderGroup1.Text = "筛选器";
            this.buttonSpecHeaderGroup1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.ArrowDown;
            this.buttonSpecHeaderGroup1.UniqueName = "6C057C3535974483B2874F123D341863";
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.AutoSize = true;
            this.btnClearFilter.Location = new System.Drawing.Point(706, 7);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(62, 30);
            this.btnClearFilter.TabIndex = 5;
            this.btnClearFilter.Values.Text = "清空筛选";
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.AutoSize = true;
            this.btnFilter.Location = new System.Drawing.Point(615, 7);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(62, 30);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Values.Image = global::Landlord2.Properties.Resources.Filter;
            this.btnFilter.Values.Text = "筛选";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpFilterBegin
            // 
            this.dtpFilterBegin.Checked = false;
            this.dtpFilterBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterBegin.Location = new System.Drawing.Point(305, 12);
            this.dtpFilterBegin.Name = "dtpFilterBegin";
            this.dtpFilterBegin.ShowCheckBox = true;
            this.dtpFilterBegin.Size = new System.Drawing.Size(115, 21);
            this.dtpFilterBegin.TabIndex = 2;
            // 
            // cmbFilter源房
            // 
            this.cmbFilter源房.DropDownWidth = 121;
            this.cmbFilter源房.Location = new System.Drawing.Point(57, 12);
            this.cmbFilter源房.Name = "cmbFilter源房";
            this.cmbFilter源房.Size = new System.Drawing.Size(136, 21);
            this.cmbFilter源房.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(421, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "～";
            // 
            // dtpFilterEnd
            // 
            this.dtpFilterEnd.Checked = false;
            this.dtpFilterEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterEnd.Location = new System.Drawing.Point(439, 12);
            this.dtpFilterEnd.Name = "dtpFilterEnd";
            this.dtpFilterEnd.ShowCheckBox = true;
            this.dtpFilterEnd.Size = new System.Drawing.Size(115, 21);
            this.dtpFilterEnd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "源房：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(234, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "抄表日期：";
            // 
            // 源房抄表BindingNavigator
            // 
            this.源房抄表BindingNavigator.AddNewItem = null;
            this.源房抄表BindingNavigator.AutoSize = false;
            this.源房抄表BindingNavigator.BindingSource = this.源房抄表BindingSource;
            this.源房抄表BindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.源房抄表BindingNavigator.DeleteItem = null;
            this.源房抄表BindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.源房抄表BindingNavigator.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.源房抄表BindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.源房抄表BindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.源房抄表BindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.源房抄表BindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.源房抄表BindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.源房抄表BindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.源房抄表BindingNavigator.Name = "源房抄表BindingNavigator";
            this.源房抄表BindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.源房抄表BindingNavigator.Size = new System.Drawing.Size(783, 25);
            this.源房抄表BindingNavigator.Stretch = true;
            this.源房抄表BindingNavigator.TabIndex = 1;
            this.源房抄表BindingNavigator.Text = "bindingNavigator1";
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
            // 抄表时间DataGridViewTextBoxColumn
            // 
            this.抄表时间DataGridViewTextBoxColumn.DataPropertyName = "抄表时间";
            this.抄表时间DataGridViewTextBoxColumn.HeaderText = "抄表时间";
            this.抄表时间DataGridViewTextBoxColumn.Name = "抄表时间DataGridViewTextBoxColumn";
            this.抄表时间DataGridViewTextBoxColumn.ReadOnly = true;
            this.抄表时间DataGridViewTextBoxColumn.Width = 80;
            // 
            // 源房DataGridViewTextBoxColumn
            // 
            this.源房DataGridViewTextBoxColumn.DataPropertyName = "源房ID";
            this.源房DataGridViewTextBoxColumn.DataSource = this.源房BindingSource;
            this.源房DataGridViewTextBoxColumn.DisplayMember = "房名";
            this.源房DataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.源房DataGridViewTextBoxColumn.HeaderText = "源房";
            this.源房DataGridViewTextBoxColumn.Name = "源房DataGridViewTextBoxColumn";
            this.源房DataGridViewTextBoxColumn.ReadOnly = true;
            this.源房DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.源房DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.源房DataGridViewTextBoxColumn.ValueMember = "ID";
            this.源房DataGridViewTextBoxColumn.Width = 150;
            // 
            // 水止码DataGridViewTextBoxColumn
            // 
            this.水止码DataGridViewTextBoxColumn.DataPropertyName = "水止码";
            this.水止码DataGridViewTextBoxColumn.HeaderText = "水止码";
            this.水止码DataGridViewTextBoxColumn.Name = "水止码DataGridViewTextBoxColumn";
            this.水止码DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 水账户余额DataGridViewTextBoxColumn
            // 
            this.水账户余额DataGridViewTextBoxColumn.DataPropertyName = "水账户余额";
            this.水账户余额DataGridViewTextBoxColumn.HeaderText = "水账户余额";
            this.水账户余额DataGridViewTextBoxColumn.Name = "水账户余额DataGridViewTextBoxColumn";
            this.水账户余额DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 电止码DataGridViewTextBoxColumn
            // 
            this.电止码DataGridViewTextBoxColumn.DataPropertyName = "电止码";
            this.电止码DataGridViewTextBoxColumn.HeaderText = "电止码";
            this.电止码DataGridViewTextBoxColumn.Name = "电止码DataGridViewTextBoxColumn";
            this.电止码DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 电账户余额DataGridViewTextBoxColumn
            // 
            this.电账户余额DataGridViewTextBoxColumn.DataPropertyName = "电账户余额";
            this.电账户余额DataGridViewTextBoxColumn.HeaderText = "电账户余额";
            this.电账户余额DataGridViewTextBoxColumn.Name = "电账户余额DataGridViewTextBoxColumn";
            this.电账户余额DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 气表剩余字数DataGridViewTextBoxColumn
            // 
            this.气表剩余字数DataGridViewTextBoxColumn.DataPropertyName = "气表剩余字数";
            this.气表剩余字数DataGridViewTextBoxColumn.HeaderText = "气表剩余字数";
            this.气表剩余字数DataGridViewTextBoxColumn.Name = "气表剩余字数DataGridViewTextBoxColumn";
            this.气表剩余字数DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 抄表人DataGridViewTextBoxColumn
            // 
            this.抄表人DataGridViewTextBoxColumn.DataPropertyName = "抄表人";
            this.抄表人DataGridViewTextBoxColumn.HeaderText = "抄表人";
            this.抄表人DataGridViewTextBoxColumn.Name = "抄表人DataGridViewTextBoxColumn";
            this.抄表人DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 备注DataGridViewTextBoxColumn
            // 
            this.备注DataGridViewTextBoxColumn.DataPropertyName = "备注";
            this.备注DataGridViewTextBoxColumn.HeaderText = "备注";
            this.备注DataGridViewTextBoxColumn.Name = "备注DataGridViewTextBoxColumn";
            this.备注DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 源房抄表明细Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 510);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "源房抄表明细Form";
            this.Text = "源房抄表明细";
            this.Load += new System.EventHandler(this.源房抄表明细Form_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房抄表BindingSource)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilter源房)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房抄表BindingNavigator)).EndInit();
            this.源房抄表BindingNavigator.ResumeLayout(false);
            this.源房抄表BindingNavigator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.BindingSource 源房抄表BindingSource;
        private System.Windows.Forms.BindingNavigator 源房抄表BindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorEditItem;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClearFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFilter;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpFilterBegin;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbFilter源房;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtpFilterEnd;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn 抄表时间DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn 源房DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 水止码DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 水账户余额DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 电止码DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 电账户余额DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 气表剩余字数DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 抄表人DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注DataGridViewTextBoxColumn;
    }
}