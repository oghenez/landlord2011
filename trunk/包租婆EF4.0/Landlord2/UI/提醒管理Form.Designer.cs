namespace Landlord2.UI
{
    partial class 提醒管理Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(提醒管理Form));
            this.提醒BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.客房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.提醒时间DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.源房IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.客房IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.事项DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.已完成DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.创建日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.完成日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.提醒BindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.提醒BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.客房BindingSource)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.提醒BindingNavigator)).BeginInit();
            this.提醒BindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // 提醒BindingSource
            // 
            this.提醒BindingSource.DataSource = typeof(Landlord2.Data.提醒);
            this.提醒BindingSource.DataSourceChanged += new System.EventHandler(this.提醒BindingSource_DataSourceChanged);
            this.提醒BindingSource.CurrentChanged += new System.EventHandler(this.提醒BindingSource_CurrentChanged);
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord2.Data.源房);
            // 
            // 客房BindingSource
            // 
            this.客房BindingSource.DataSource = typeof(Landlord2.Data.客房);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.kryptonDataGridView1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(727, 472);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(727, 497);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.提醒BindingNavigator);
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AllowUserToDeleteRows = false;
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.提醒时间DataGridViewTextBoxColumn,
            this.源房IDDataGridViewTextBoxColumn,
            this.客房IDDataGridViewTextBoxColumn,
            this.事项DataGridViewTextBoxColumn,
            this.已完成DataGridViewCheckBoxColumn,
            this.创建日期DataGridViewTextBoxColumn,
            this.完成日期DataGridViewTextBoxColumn});
            this.kryptonDataGridView1.DataSource = this.提醒BindingSource;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView1.MultiSelect = false;
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonDataGridView1.ReadOnly = true;
            this.kryptonDataGridView1.RowHeadersWidth = 24;
            this.kryptonDataGridView1.RowTemplate.Height = 23;
            this.kryptonDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(727, 472);
            this.kryptonDataGridView1.TabIndex = 1;
            this.kryptonDataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.kryptonDataGridView1_CellMouseDoubleClick);
            // 
            // 提醒时间DataGridViewTextBoxColumn
            // 
            this.提醒时间DataGridViewTextBoxColumn.DataPropertyName = "提醒时间";
            this.提醒时间DataGridViewTextBoxColumn.HeaderText = "提醒时间";
            this.提醒时间DataGridViewTextBoxColumn.Name = "提醒时间DataGridViewTextBoxColumn";
            this.提醒时间DataGridViewTextBoxColumn.ReadOnly = true;
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
            this.客房IDDataGridViewTextBoxColumn.Width = 80;
            // 
            // 事项DataGridViewTextBoxColumn
            // 
            this.事项DataGridViewTextBoxColumn.DataPropertyName = "事项";
            this.事项DataGridViewTextBoxColumn.HeaderText = "事项";
            this.事项DataGridViewTextBoxColumn.Name = "事项DataGridViewTextBoxColumn";
            this.事项DataGridViewTextBoxColumn.ReadOnly = true;
            this.事项DataGridViewTextBoxColumn.Width = 200;
            // 
            // 已完成DataGridViewCheckBoxColumn
            // 
            this.已完成DataGridViewCheckBoxColumn.DataPropertyName = "已完成";
            this.已完成DataGridViewCheckBoxColumn.HeaderText = "已完成";
            this.已完成DataGridViewCheckBoxColumn.Name = "已完成DataGridViewCheckBoxColumn";
            this.已完成DataGridViewCheckBoxColumn.ReadOnly = true;
            this.已完成DataGridViewCheckBoxColumn.Width = 50;
            // 
            // 创建日期DataGridViewTextBoxColumn
            // 
            this.创建日期DataGridViewTextBoxColumn.DataPropertyName = "创建日期";
            this.创建日期DataGridViewTextBoxColumn.HeaderText = "创建日期";
            this.创建日期DataGridViewTextBoxColumn.Name = "创建日期DataGridViewTextBoxColumn";
            this.创建日期DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 完成日期DataGridViewTextBoxColumn
            // 
            this.完成日期DataGridViewTextBoxColumn.DataPropertyName = "完成日期";
            this.完成日期DataGridViewTextBoxColumn.HeaderText = "完成日期";
            this.完成日期DataGridViewTextBoxColumn.Name = "完成日期DataGridViewTextBoxColumn";
            this.完成日期DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 提醒BindingNavigator
            // 
            this.提醒BindingNavigator.AddNewItem = null;
            this.提醒BindingNavigator.AutoSize = false;
            this.提醒BindingNavigator.BindingSource = this.提醒BindingSource;
            this.提醒BindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.提醒BindingNavigator.DeleteItem = null;
            this.提醒BindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.提醒BindingNavigator.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.提醒BindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.提醒BindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.提醒BindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.提醒BindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.提醒BindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.提醒BindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.提醒BindingNavigator.Name = "提醒BindingNavigator";
            this.提醒BindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.提醒BindingNavigator.Size = new System.Drawing.Size(727, 25);
            this.提醒BindingNavigator.Stretch = true;
            this.提醒BindingNavigator.TabIndex = 0;
            this.提醒BindingNavigator.Text = "bindingNavigator1";
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
            // 提醒管理Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 497);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "提醒管理Form";
            this.Text = "自定义提醒管理";
            this.Load += new System.EventHandler(this.提醒管理Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.提醒BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.客房BindingSource)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.提醒BindingNavigator)).EndInit();
            this.提醒BindingNavigator.ResumeLayout(false);
            this.提醒BindingNavigator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource 提醒BindingSource;
        private System.Windows.Forms.BindingNavigator 提醒BindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorEditItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn 提醒时间DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn 源房IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn 客房IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource 客房BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn 事项DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 已完成DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 创建日期DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 完成日期DataGridViewTextBoxColumn;


    }
}