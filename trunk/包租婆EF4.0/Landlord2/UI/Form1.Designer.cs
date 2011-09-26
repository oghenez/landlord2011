namespace Landlord2.UI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.源房缴费明细BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.源房缴费明细BindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.源房缴费明细BindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.源房IDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.缴费项DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.缴费时间DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.缴费金额DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.期始DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.期止DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.付款人DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.收款人DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.源房缴费明细BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房缴费明细BindingNavigator)).BeginInit();
            this.源房缴费明细BindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // 源房缴费明细BindingSource
            // 
            this.源房缴费明细BindingSource.DataSource = typeof(Landlord2.Data.源房缴费明细);
            // 
            // 源房缴费明细BindingNavigator
            // 
            this.源房缴费明细BindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.源房缴费明细BindingNavigator.AutoSize = false;
            this.源房缴费明细BindingNavigator.BindingSource = this.源房缴费明细BindingSource;
            this.源房缴费明细BindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.源房缴费明细BindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.源房缴费明细BindingNavigator.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.源房缴费明细BindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.源房缴费明细BindingNavigatorSaveItem});
            this.源房缴费明细BindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.源房缴费明细BindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.源房缴费明细BindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.源房缴费明细BindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.源房缴费明细BindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.源房缴费明细BindingNavigator.Name = "源房缴费明细BindingNavigator";
            this.源房缴费明细BindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.源房缴费明细BindingNavigator.Size = new System.Drawing.Size(758, 32);
            this.源房缴费明细BindingNavigator.TabIndex = 0;
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
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
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
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 29);
            this.bindingNavigatorAddNewItem.Text = "新添";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "删除";
            // 
            // 源房缴费明细BindingNavigatorSaveItem
            // 
            this.源房缴费明细BindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.源房缴费明细BindingNavigatorSaveItem.Enabled = false;
            this.源房缴费明细BindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("源房缴费明细BindingNavigatorSaveItem.Image")));
            this.源房缴费明细BindingNavigatorSaveItem.Name = "源房缴费明细BindingNavigatorSaveItem";
            this.源房缴费明细BindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.源房缴费明细BindingNavigatorSaveItem.Text = "保存数据";
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.源房IDDataGridViewTextBoxColumn,
            this.缴费项DataGridViewTextBoxColumn,
            this.缴费时间DataGridViewTextBoxColumn,
            this.缴费金额DataGridViewTextBoxColumn,
            this.期始DataGridViewTextBoxColumn,
            this.期止DataGridViewTextBoxColumn,
            this.付款人DataGridViewTextBoxColumn,
            this.收款人DataGridViewTextBoxColumn,
            this.备注DataGridViewTextBoxColumn});
            this.kryptonDataGridView1.DataSource = this.源房缴费明细BindingSource;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(12, 40);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonDataGridView1.RowTemplate.Height = 23;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(696, 343);
            this.kryptonDataGridView1.TabIndex = 1;
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord2.Data.源房);
            // 
            // 源房IDDataGridViewTextBoxColumn
            // 
            this.源房IDDataGridViewTextBoxColumn.DataPropertyName = "源房ID";
            this.源房IDDataGridViewTextBoxColumn.DataSource = this.源房BindingSource;
            this.源房IDDataGridViewTextBoxColumn.DisplayMember = "房名";
            this.源房IDDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.源房IDDataGridViewTextBoxColumn.HeaderText = "源房";
            this.源房IDDataGridViewTextBoxColumn.Name = "源房IDDataGridViewTextBoxColumn";
            this.源房IDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.源房IDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.源房IDDataGridViewTextBoxColumn.ValueMember = "ID";
            // 
            // 缴费项DataGridViewTextBoxColumn
            // 
            this.缴费项DataGridViewTextBoxColumn.DataPropertyName = "缴费项";
            this.缴费项DataGridViewTextBoxColumn.HeaderText = "缴费项";
            this.缴费项DataGridViewTextBoxColumn.Name = "缴费项DataGridViewTextBoxColumn";
            // 
            // 缴费时间DataGridViewTextBoxColumn
            // 
            this.缴费时间DataGridViewTextBoxColumn.DataPropertyName = "缴费时间";
            this.缴费时间DataGridViewTextBoxColumn.HeaderText = "缴费时间";
            this.缴费时间DataGridViewTextBoxColumn.Name = "缴费时间DataGridViewTextBoxColumn";
            // 
            // 缴费金额DataGridViewTextBoxColumn
            // 
            this.缴费金额DataGridViewTextBoxColumn.DataPropertyName = "缴费金额";
            this.缴费金额DataGridViewTextBoxColumn.HeaderText = "缴费金额";
            this.缴费金额DataGridViewTextBoxColumn.Name = "缴费金额DataGridViewTextBoxColumn";
            // 
            // 期始DataGridViewTextBoxColumn
            // 
            this.期始DataGridViewTextBoxColumn.DataPropertyName = "期始";
            this.期始DataGridViewTextBoxColumn.HeaderText = "期始";
            this.期始DataGridViewTextBoxColumn.Name = "期始DataGridViewTextBoxColumn";
            // 
            // 期止DataGridViewTextBoxColumn
            // 
            this.期止DataGridViewTextBoxColumn.DataPropertyName = "期止";
            this.期止DataGridViewTextBoxColumn.HeaderText = "期止";
            this.期止DataGridViewTextBoxColumn.Name = "期止DataGridViewTextBoxColumn";
            // 
            // 付款人DataGridViewTextBoxColumn
            // 
            this.付款人DataGridViewTextBoxColumn.DataPropertyName = "付款人";
            this.付款人DataGridViewTextBoxColumn.HeaderText = "付款人";
            this.付款人DataGridViewTextBoxColumn.Name = "付款人DataGridViewTextBoxColumn";
            // 
            // 收款人DataGridViewTextBoxColumn
            // 
            this.收款人DataGridViewTextBoxColumn.DataPropertyName = "收款人";
            this.收款人DataGridViewTextBoxColumn.HeaderText = "收款人";
            this.收款人DataGridViewTextBoxColumn.Name = "收款人DataGridViewTextBoxColumn";
            // 
            // 备注DataGridViewTextBoxColumn
            // 
            this.备注DataGridViewTextBoxColumn.DataPropertyName = "备注";
            this.备注DataGridViewTextBoxColumn.HeaderText = "备注";
            this.备注DataGridViewTextBoxColumn.Name = "备注DataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 425);
            this.Controls.Add(this.kryptonDataGridView1);
            this.Controls.Add(this.源房缴费明细BindingNavigator);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.源房缴费明细BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房缴费明细BindingNavigator)).EndInit();
            this.源房缴费明细BindingNavigator.ResumeLayout(false);
            this.源房缴费明细BindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource 源房缴费明细BindingSource;
        private System.Windows.Forms.BindingNavigator 源房缴费明细BindingNavigator;
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
        private System.Windows.Forms.ToolStripButton 源房缴费明细BindingNavigatorSaveItem;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.DataGridViewComboBoxColumn 源房IDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn 缴费项DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 缴费时间DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 缴费金额DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 期始DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 期止DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 付款人DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 收款人DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注DataGridViewTextBoxColumn;
    }
}