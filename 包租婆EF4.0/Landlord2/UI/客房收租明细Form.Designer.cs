namespace Landlord2.UI
{
    partial class 客房收租明细Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(客房收租明细Form));
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.客房租金明细BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.llbKF = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.raBtnOne = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.BtnAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.raBtnAll = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.myDataGridViewDateTimePickerColumn1 = new Landlord2.MyDataGridViewDateTimePickerColumn();
            this.myDataGridViewDateTimePickerColumn2 = new Landlord2.MyDataGridViewDateTimePickerColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labCountMoney = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.客房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.起付日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.止付日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.付款日期DataGridViewTextBoxColumn = new Landlord2.MyDataGridViewDateTimePickerColumn();
            this.水止码DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.电止码DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.气止码DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.应付金额DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.实付金额DataGridViewTextBoxColumn = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn();
            this.付款人DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.收款人DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.客房租金明细BindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.客房BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.起付日期DataGridViewTextBoxColumn,
            this.止付日期DataGridViewTextBoxColumn,
            this.付款日期DataGridViewTextBoxColumn,
            this.水止码DataGridViewTextBoxColumn,
            this.电止码DataGridViewTextBoxColumn,
            this.气止码DataGridViewTextBoxColumn,
            this.应付金额DataGridViewTextBoxColumn,
            this.实付金额DataGridViewTextBoxColumn,
            this.付款人DataGridViewTextBoxColumn,
            this.收款人DataGridViewTextBoxColumn,
            this.备注DataGridViewTextBoxColumn});
            this.kryptonDataGridView1.DataSource = this.客房租金明细BindingSource;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 74);
            this.kryptonDataGridView1.MultiSelect = false;
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonDataGridView1.RowHeadersWidth = 24;
            this.kryptonDataGridView1.RowTemplate.Height = 23;
            this.kryptonDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(844, 278);
            this.kryptonDataGridView1.TabIndex = 2;
            this.kryptonDataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.kryptonDataGridView1_CellEndEdit);
            this.kryptonDataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.kryptonDataGridView1_CellFormatting);
            this.kryptonDataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.kryptonDataGridView1_UserDeletedRow);
            this.kryptonDataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.kryptonDataGridView1_UserDeletingRow);
            // 
            // 客房租金明细BindingSource
            // 
            this.客房租金明细BindingSource.DataSource = typeof(Landlord2.Data.客房租金明细);
            this.客房租金明细BindingSource.Sort = "";
            this.客房租金明细BindingSource.DataSourceChanged += new System.EventHandler(this.客房租金明细BindingSource_DataSourceChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.llbKF);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.raBtnOne);
            this.panel1.Controls.Add(this.BtnAdd);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.raBtnAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 60);
            this.panel1.TabIndex = 0;
            // 
            // llbKF
            // 
            this.llbKF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llbKF.Enabled = false;
            this.llbKF.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.llbKF.Location = new System.Drawing.Point(114, 20);
            this.llbKF.Name = "llbKF";
            this.llbKF.Size = new System.Drawing.Size(133, 20);
            this.llbKF.TabIndex = 2;
            this.llbKF.Values.ExtraText = "<请选择>";
            this.llbKF.Values.Text = "单套客房：";
            this.llbKF.LinkClicked += new System.EventHandler(this.llbKF_LinkClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(717, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // raBtnOne
            // 
            this.raBtnOne.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.raBtnOne.Location = new System.Drawing.Point(102, 24);
            this.raBtnOne.Name = "raBtnOne";
            this.raBtnOne.Size = new System.Drawing.Size(18, 12);
            this.raBtnOne.TabIndex = 1;
            this.raBtnOne.Values.Text = "";
            this.raBtnOne.CheckedChanged += new System.EventHandler(this.raBtn_CheckedChanged);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.Location = new System.Drawing.Point(447, 18);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(90, 25);
            this.BtnAdd.TabIndex = 3;
            this.BtnAdd.Values.Text = "新增";
            this.BtnAdd.Visible = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(582, 18);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 4;
            this.btnOK.Values.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // raBtnAll
            // 
            this.raBtnAll.Checked = true;
            this.raBtnAll.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.raBtnAll.Location = new System.Drawing.Point(12, 20);
            this.raBtnAll.Name = "raBtnAll";
            this.raBtnAll.Size = new System.Drawing.Size(72, 20);
            this.raBtnAll.TabIndex = 0;
            this.raBtnAll.Values.Text = "全部客房";
            this.raBtnAll.CheckedChanged += new System.EventHandler(this.raBtn_CheckedChanged);
            // 
            // myDataGridViewDateTimePickerColumn1
            // 
            this.myDataGridViewDateTimePickerColumn1.CalendarTodayDate = new System.DateTime(2011, 9, 12, 0, 0, 0, 0);
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
            this.myDataGridViewDateTimePickerColumn2.CalendarTodayDate = new System.DateTime(2011, 9, 12, 0, 0, 0, 0);
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
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labCountMoney});
            this.statusStrip1.Location = new System.Drawing.Point(0, 352);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(844, 32);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labCountMoney
            // 
            this.labCountMoney.AutoToolTip = true;
            this.labCountMoney.Name = "labCountMoney";
            this.labCountMoney.Size = new System.Drawing.Size(829, 27);
            this.labCountMoney.Spring = true;
            this.labCountMoney.ToolTipText = "合计当前列表显示的项目金额";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 10;
            // 
            // 客房BindingSource
            // 
            this.客房BindingSource.DataSource = typeof(Landlord2.Data.客房);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "客房";
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "客房";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // 起付日期DataGridViewTextBoxColumn
            // 
            this.起付日期DataGridViewTextBoxColumn.DataPropertyName = "起付日期";
            dataGridViewCellStyle1.Format = "d";
            this.起付日期DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.起付日期DataGridViewTextBoxColumn.HeaderText = "起付日期";
            this.起付日期DataGridViewTextBoxColumn.Name = "起付日期DataGridViewTextBoxColumn";
            this.起付日期DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 止付日期DataGridViewTextBoxColumn
            // 
            this.止付日期DataGridViewTextBoxColumn.DataPropertyName = "止付日期";
            dataGridViewCellStyle2.Format = "d";
            this.止付日期DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.止付日期DataGridViewTextBoxColumn.HeaderText = "止付日期";
            this.止付日期DataGridViewTextBoxColumn.Name = "止付日期DataGridViewTextBoxColumn";
            this.止付日期DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 付款日期DataGridViewTextBoxColumn
            // 
            this.付款日期DataGridViewTextBoxColumn.CalendarTodayDate = new System.DateTime(2011, 9, 12, 0, 0, 0, 0);
            this.付款日期DataGridViewTextBoxColumn.Checked = false;
            this.付款日期DataGridViewTextBoxColumn.DataPropertyName = "付款日期";
            this.付款日期DataGridViewTextBoxColumn.HeaderText = "付款日期";
            this.付款日期DataGridViewTextBoxColumn.Name = "付款日期DataGridViewTextBoxColumn";
            this.付款日期DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.付款日期DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.付款日期DataGridViewTextBoxColumn.Width = 100;
            // 
            // 水止码DataGridViewTextBoxColumn
            // 
            this.水止码DataGridViewTextBoxColumn.DataPropertyName = "水止码";
            this.水止码DataGridViewTextBoxColumn.HeaderText = "水止码";
            this.水止码DataGridViewTextBoxColumn.Name = "水止码DataGridViewTextBoxColumn";
            this.水止码DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 电止码DataGridViewTextBoxColumn
            // 
            this.电止码DataGridViewTextBoxColumn.DataPropertyName = "电止码";
            this.电止码DataGridViewTextBoxColumn.HeaderText = "电止码";
            this.电止码DataGridViewTextBoxColumn.Name = "电止码DataGridViewTextBoxColumn";
            this.电止码DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 气止码DataGridViewTextBoxColumn
            // 
            this.气止码DataGridViewTextBoxColumn.DataPropertyName = "气止码";
            this.气止码DataGridViewTextBoxColumn.HeaderText = "气止码";
            this.气止码DataGridViewTextBoxColumn.Name = "气止码DataGridViewTextBoxColumn";
            this.气止码DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 应付金额DataGridViewTextBoxColumn
            // 
            this.应付金额DataGridViewTextBoxColumn.DataPropertyName = "应付金额";
            this.应付金额DataGridViewTextBoxColumn.HeaderText = "应付金额";
            this.应付金额DataGridViewTextBoxColumn.Name = "应付金额DataGridViewTextBoxColumn";
            this.应付金额DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 实付金额DataGridViewTextBoxColumn
            // 
            this.实付金额DataGridViewTextBoxColumn.DataPropertyName = "实付金额";
            this.实付金额DataGridViewTextBoxColumn.DecimalPlaces = 2;
            this.实付金额DataGridViewTextBoxColumn.HeaderText = "实付金额";
            this.实付金额DataGridViewTextBoxColumn.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.实付金额DataGridViewTextBoxColumn.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.实付金额DataGridViewTextBoxColumn.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.实付金额DataGridViewTextBoxColumn.Name = "实付金额DataGridViewTextBoxColumn";
            this.实付金额DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.实付金额DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.实付金额DataGridViewTextBoxColumn.Width = 100;
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
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlToolTip;
            this.kryptonPanel1.Size = new System.Drawing.Size(844, 74);
            this.kryptonPanel1.TabIndex = 4;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AutoSize = false;
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.kryptonLabel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(844, 74);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.ExtraText = resources.GetString("kryptonLabel1.Values.ExtraText");
            this.kryptonLabel1.Values.Image = global::Landlord2.Properties.Resources.info;
            this.kryptonLabel1.Values.Text = "";
            // 
            // 客房收租明细Form
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 444);
            this.Controls.Add(this.kryptonDataGridView1);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "客房收租明细Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "客房收租明细";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.客房收租明细Form_FormClosed);
            this.Load += new System.EventHandler(this.客房收租明细Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.客房租金明细BindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.客房BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.BindingSource 客房租金明细BindingSource;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton raBtnOne;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnAdd;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton raBtnAll;
        private MyDataGridViewDateTimePickerColumn myDataGridViewDateTimePickerColumn1;
        private MyDataGridViewDateTimePickerColumn myDataGridViewDateTimePickerColumn2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labCountMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel llbKF;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.BindingSource 客房BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 起付日期DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 止付日期DataGridViewTextBoxColumn;
        private MyDataGridViewDateTimePickerColumn 付款日期DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 水止码DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 电止码DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 气止码DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 应付金额DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewNumericUpDownColumn 实付金额DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 付款人DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 收款人DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注DataGridViewTextBoxColumn;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}