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
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.缴费时间DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn();
            this.缴费项DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.缴费金额DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn();
            this.期始DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn();
            this.期止DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn();
            this.付款人DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.收款人DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.备注DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.源房缴费明细BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.kryptonComboBox1 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.缴收项目BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房缴费明细BindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.缴收项目BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.label1);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.btnOK);
            this.kryptonSplitContainer1.Panel2.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(844, 435);
            this.kryptonSplitContainer1.SplitterDistance = 380;
            this.kryptonSplitContainer1.SplitterWidth = 1;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.缴费时间DataGridViewTextBoxColumn,
            this.缴费项DataGridViewTextBoxColumn,
            this.缴费金额DataGridViewTextBoxColumn,
            this.期始DataGridViewTextBoxColumn,
            this.期止DataGridViewTextBoxColumn,
            this.付款人DataGridViewTextBoxColumn,
            this.收款人DataGridViewTextBoxColumn,
            this.备注DataGridViewTextBoxColumn});
            this.kryptonDataGridView1.DataSource = this.源房缴费明细BindingSource;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonDataGridView1.RowTemplate.Height = 23;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(844, 348);
            this.kryptonDataGridView1.TabIndex = 0;
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
            this.缴费项DataGridViewTextBoxColumn.Name = "缴费项DataGridViewTextBoxColumn";
            this.缴费项DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.缴费项DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.缴费项DataGridViewTextBoxColumn.Width = 100;
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
            this.缴费金额DataGridViewTextBoxColumn.Width = 100;
            // 
            // 期始DataGridViewTextBoxColumn
            // 
            this.期始DataGridViewTextBoxColumn.CalendarTodayDate = new System.DateTime(2011, 8, 25, 0, 0, 0, 0);
            this.期始DataGridViewTextBoxColumn.Checked = false;
            this.期始DataGridViewTextBoxColumn.DataPropertyName = "期始";
            this.期始DataGridViewTextBoxColumn.HeaderText = "期始";
            this.期始DataGridViewTextBoxColumn.Name = "期始DataGridViewTextBoxColumn";
            this.期始DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.期始DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.期始DataGridViewTextBoxColumn.Width = 100;
            // 
            // 期止DataGridViewTextBoxColumn
            // 
            this.期止DataGridViewTextBoxColumn.CalendarTodayDate = new System.DateTime(2011, 8, 25, 0, 0, 0, 0);
            this.期止DataGridViewTextBoxColumn.Checked = false;
            this.期止DataGridViewTextBoxColumn.DataPropertyName = "期止";
            this.期止DataGridViewTextBoxColumn.HeaderText = "期止";
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
            // 源房缴费明细BindingSource
            // 
            this.源房缴费明细BindingSource.DataSource = typeof(Landlord2.Data.源房缴费明细);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 348);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(844, 32);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.Image = global::Landlord2.Properties.Resources.Filter;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(133, 30);
            this.toolStripSplitButton1.Text = "按 [缴费项] 筛选";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(696, 27);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "当前合计金额：";
            // 
            // kryptonComboBox1
            // 
            this.kryptonComboBox1.DisplayMember = "房名";
            this.kryptonComboBox1.DropDownWidth = 215;
            this.kryptonComboBox1.Location = new System.Drawing.Point(76, 17);
            this.kryptonComboBox1.Name = "kryptonComboBox1";
            this.kryptonComboBox1.Size = new System.Drawing.Size(215, 21);
            this.kryptonComboBox1.TabIndex = 9;
            this.kryptonComboBox1.ValueMember = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "隶属源房：";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(721, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Values.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(591, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 6;
            this.btnOK.Values.Text = "保存";
            // 
            // 缴收项目BindingSource
            // 
            this.缴收项目BindingSource.DataSource = typeof(Landlord2.Data.缴收项目);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.源房缴费明细BindingSource;
            // 
            // 缴费明细Form
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(844, 435);
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Name = "缴费明细Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "源房缴费明细";
            this.Load += new System.EventHandler(this.缴费Form_Load);
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房缴费明细BindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.缴收项目BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.BindingSource 源房缴费明细BindingSource;
        private System.Windows.Forms.BindingSource 缴收项目BindingSource;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kryptonComboBox1;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn 缴费时间DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn 缴费项DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn 缴费金额DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn 期始DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewDateTimePickerColumn 期止DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn 付款人DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn 收款人DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn 备注DataGridViewTextBoxColumn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}