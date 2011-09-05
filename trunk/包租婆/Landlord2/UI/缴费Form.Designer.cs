namespace Landlord2.UI
{
    partial class 缴费Form
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
            System.Windows.Forms.Label 缴费项Label;
            System.Windows.Forms.Label 缴费时间Label;
            System.Windows.Forms.Label 缴费金额Label;
            System.Windows.Forms.Label 期始Label;
            System.Windows.Forms.Label 期止Label;
            System.Windows.Forms.Label 收款人Label;
            System.Windows.Forms.Label 付款人Label;
            System.Windows.Forms.Label 备注Label;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.源房缴费明细BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.参考历史BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.cmbYF = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPayItem = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonDateTimePicker1 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonNumericUpDown1 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonDateTimePicker2 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonDateTimePicker3 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox3 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BtnOkAndContinue = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.缴费时间DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.缴费项DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.缴费金额DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.期始DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.期止DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.付款人DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.收款人DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            缴费项Label = new System.Windows.Forms.Label();
            缴费时间Label = new System.Windows.Forms.Label();
            缴费金额Label = new System.Windows.Forms.Label();
            期始Label = new System.Windows.Forms.Label();
            期止Label = new System.Windows.Forms.Label();
            收款人Label = new System.Windows.Forms.Label();
            付款人Label = new System.Windows.Forms.Label();
            备注Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房缴费明细BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.参考历史BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPayItem)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 缴费项Label
            // 
            缴费项Label.AutoSize = true;
            缴费项Label.ForeColor = System.Drawing.Color.Red;
            缴费项Label.Location = new System.Drawing.Point(508, 30);
            缴费项Label.Name = "缴费项Label";
            缴费项Label.Size = new System.Drawing.Size(59, 12);
            缴费项Label.TabIndex = 4;
            缴费项Label.Text = "* 缴费项:";
            // 
            // 缴费时间Label
            // 
            缴费时间Label.AutoSize = true;
            缴费时间Label.Location = new System.Drawing.Point(27, 60);
            缴费时间Label.Name = "缴费时间Label";
            缴费时间Label.Size = new System.Drawing.Size(59, 12);
            缴费时间Label.TabIndex = 6;
            缴费时间Label.Text = "缴费时间:";
            // 
            // 缴费金额Label
            // 
            缴费金额Label.AutoSize = true;
            缴费金额Label.Location = new System.Drawing.Point(27, 90);
            缴费金额Label.Name = "缴费金额Label";
            缴费金额Label.Size = new System.Drawing.Size(59, 12);
            缴费金额Label.TabIndex = 8;
            缴费金额Label.Text = "缴费金额:";
            // 
            // 期始Label
            // 
            期始Label.AutoSize = true;
            期始Label.Location = new System.Drawing.Point(281, 60);
            期始Label.Name = "期始Label";
            期始Label.Size = new System.Drawing.Size(35, 12);
            期始Label.TabIndex = 10;
            期始Label.Text = "期始:";
            // 
            // 期止Label
            // 
            期止Label.AutoSize = true;
            期止Label.Location = new System.Drawing.Point(281, 90);
            期止Label.Name = "期止Label";
            期止Label.Size = new System.Drawing.Size(35, 12);
            期止Label.TabIndex = 12;
            期止Label.Text = "期止:";
            // 
            // 收款人Label
            // 
            收款人Label.AutoSize = true;
            收款人Label.Location = new System.Drawing.Point(520, 90);
            收款人Label.Name = "收款人Label";
            收款人Label.Size = new System.Drawing.Size(47, 12);
            收款人Label.TabIndex = 14;
            收款人Label.Text = "收款人:";
            // 
            // 付款人Label
            // 
            付款人Label.AutoSize = true;
            付款人Label.Location = new System.Drawing.Point(520, 60);
            付款人Label.Name = "付款人Label";
            付款人Label.Size = new System.Drawing.Size(47, 12);
            付款人Label.TabIndex = 16;
            付款人Label.Text = "付款人:";
            // 
            // 备注Label
            // 
            备注Label.AutoSize = true;
            备注Label.Location = new System.Drawing.Point(51, 120);
            备注Label.Name = "备注Label";
            备注Label.Size = new System.Drawing.Size(35, 12);
            备注Label.TabIndex = 18;
            备注Label.Text = "备注:";
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord2.Data.源房);
            // 
            // 源房缴费明细BindingSource
            // 
            this.源房缴费明细BindingSource.DataSource = typeof(Landlord2.Data.源房缴费明细);
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AllowUserToDeleteRows = false;
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.缴费时间DataGridViewTextBoxColumn,
            this.缴费项DataGridViewTextBoxColumn,
            this.缴费金额DataGridViewTextBoxColumn,
            this.期始DataGridViewTextBoxColumn,
            this.期止DataGridViewTextBoxColumn,
            this.付款人DataGridViewTextBoxColumn,
            this.收款人DataGridViewTextBoxColumn,
            this.备注DataGridViewTextBoxColumn});
            this.kryptonDataGridView1.DataSource = this.参考历史BindingSource;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonDataGridView1.ReadOnly = true;
            this.kryptonDataGridView1.RowHeadersWidth = 25;
            this.kryptonDataGridView1.RowTemplate.Height = 23;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(692, 202);
            this.kryptonDataGridView1.TabIndex = 1;
            // 
            // 参考历史BindingSource
            // 
            this.参考历史BindingSource.DataSource = typeof(Landlord2.Data.源房缴费明细);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(2, 174);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            this.kryptonGroupBox1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonDataGridView1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(696, 224);
            this.kryptonGroupBox1.TabIndex = 2;
            this.kryptonGroupBox1.Text = "参考：该源房相同缴费项历史缴费";
            this.kryptonGroupBox1.Values.Heading = "参考：该源房相同缴费项历史缴费";
            // 
            // cmbYF
            // 
            this.cmbYF.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.源房缴费明细BindingSource, "源房ID", true));
            this.cmbYF.DataSource = this.源房BindingSource;
            this.cmbYF.DisplayMember = "房名";
            this.cmbYF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYF.DropDownWidth = 158;
            this.cmbYF.Location = new System.Drawing.Point(90, 26);
            this.cmbYF.Name = "cmbYF";
            this.cmbYF.Size = new System.Drawing.Size(369, 21);
            this.cmbYF.TabIndex = 0;
            this.cmbYF.ValueMember = "ID";
            this.cmbYF.SelectedIndexChanged += new System.EventHandler(this.cmbYF_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(39, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "* 源房:";
            // 
            // cmbPayItem
            // 
            this.cmbPayItem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.源房缴费明细BindingSource, "缴费项", true));
            this.cmbPayItem.DropDownWidth = 100;
            this.cmbPayItem.Items.AddRange(new object[] {
            "房租",
            "物业费",
            "水",
            "电",
            "气",
            "宽带费",
            "中介费",
            "押金"});
            this.cmbPayItem.Location = new System.Drawing.Point(571, 26);
            this.cmbPayItem.Name = "cmbPayItem";
            this.cmbPayItem.Size = new System.Drawing.Size(100, 21);
            this.cmbPayItem.TabIndex = 1;
            this.cmbPayItem.TextChanged += new System.EventHandler(this.cmbPayItem_TextChanged);
            // 
            // kryptonDateTimePicker1
            // 
            this.kryptonDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.源房缴费明细BindingSource, "缴费时间", true));
            this.kryptonDateTimePicker1.Location = new System.Drawing.Point(90, 56);
            this.kryptonDateTimePicker1.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.kryptonDateTimePicker1.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.kryptonDateTimePicker1.Name = "kryptonDateTimePicker1";
            this.kryptonDateTimePicker1.Size = new System.Drawing.Size(118, 21);
            this.kryptonDateTimePicker1.TabIndex = 2;
            // 
            // kryptonNumericUpDown1
            // 
            this.kryptonNumericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.源房缴费明细BindingSource, "缴费金额", true));
            this.kryptonNumericUpDown1.Location = new System.Drawing.Point(90, 85);
            this.kryptonNumericUpDown1.Name = "kryptonNumericUpDown1";
            this.kryptonNumericUpDown1.Size = new System.Drawing.Size(118, 22);
            this.kryptonNumericUpDown1.TabIndex = 3;
            // 
            // kryptonDateTimePicker2
            // 
            this.kryptonDateTimePicker2.Checked = false;
            this.kryptonDateTimePicker2.CustomNullText = "<无>";
            this.kryptonDateTimePicker2.DataBindings.Add(new System.Windows.Forms.Binding("ValueNullable", this.源房缴费明细BindingSource, "期始", true));
            this.kryptonDateTimePicker2.Location = new System.Drawing.Point(320, 56);
            this.kryptonDateTimePicker2.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.kryptonDateTimePicker2.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.kryptonDateTimePicker2.Name = "kryptonDateTimePicker2";
            this.kryptonDateTimePicker2.ShowCheckBox = true;
            this.kryptonDateTimePicker2.Size = new System.Drawing.Size(139, 21);
            this.kryptonDateTimePicker2.TabIndex = 4;
            // 
            // kryptonDateTimePicker3
            // 
            this.kryptonDateTimePicker3.Checked = false;
            this.kryptonDateTimePicker3.CustomNullText = "<无>";
            this.kryptonDateTimePicker3.DataBindings.Add(new System.Windows.Forms.Binding("ValueNullable", this.源房缴费明细BindingSource, "期止", true));
            this.kryptonDateTimePicker3.Location = new System.Drawing.Point(320, 86);
            this.kryptonDateTimePicker3.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.kryptonDateTimePicker3.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.kryptonDateTimePicker3.Name = "kryptonDateTimePicker3";
            this.kryptonDateTimePicker3.ShowCheckBox = true;
            this.kryptonDateTimePicker3.Size = new System.Drawing.Size(139, 21);
            this.kryptonDateTimePicker3.TabIndex = 5;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.源房缴费明细BindingSource, "收款人", true));
            this.kryptonTextBox1.Location = new System.Drawing.Point(571, 86);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(100, 20);
            this.kryptonTextBox1.TabIndex = 7;
            // 
            // kryptonTextBox2
            // 
            this.kryptonTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.源房缴费明细BindingSource, "付款人", true));
            this.kryptonTextBox2.Location = new System.Drawing.Point(571, 56);
            this.kryptonTextBox2.Name = "kryptonTextBox2";
            this.kryptonTextBox2.Size = new System.Drawing.Size(100, 20);
            this.kryptonTextBox2.TabIndex = 6;
            // 
            // kryptonTextBox3
            // 
            this.kryptonTextBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.源房缴费明细BindingSource, "备注", true));
            this.kryptonTextBox3.Location = new System.Drawing.Point(90, 116);
            this.kryptonTextBox3.Multiline = true;
            this.kryptonTextBox3.Name = "kryptonTextBox3";
            this.kryptonTextBox3.Size = new System.Drawing.Size(581, 42);
            this.kryptonTextBox3.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.BtnOkAndContinue);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 398);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 60);
            this.panel1.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(579, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BtnOkAndContinue
            // 
            this.BtnOkAndContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOkAndContinue.Location = new System.Drawing.Point(319, 18);
            this.BtnOkAndContinue.Name = "BtnOkAndContinue";
            this.BtnOkAndContinue.Size = new System.Drawing.Size(90, 25);
            this.BtnOkAndContinue.TabIndex = 5;
            this.BtnOkAndContinue.Values.Text = "保存并继续";
            this.BtnOkAndContinue.Visible = false;
            this.BtnOkAndContinue.Click += new System.EventHandler(this.BtnOkAndContinue_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(449, 18);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 4;
            this.btnOK.Values.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // 缴费时间DataGridViewTextBoxColumn
            // 
            this.缴费时间DataGridViewTextBoxColumn.DataPropertyName = "缴费时间";
            this.缴费时间DataGridViewTextBoxColumn.HeaderText = "缴费时间";
            this.缴费时间DataGridViewTextBoxColumn.Name = "缴费时间DataGridViewTextBoxColumn";
            this.缴费时间DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 缴费项DataGridViewTextBoxColumn
            // 
            this.缴费项DataGridViewTextBoxColumn.DataPropertyName = "缴费项";
            this.缴费项DataGridViewTextBoxColumn.HeaderText = "缴费项";
            this.缴费项DataGridViewTextBoxColumn.Name = "缴费项DataGridViewTextBoxColumn";
            this.缴费项DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 缴费金额DataGridViewTextBoxColumn
            // 
            this.缴费金额DataGridViewTextBoxColumn.DataPropertyName = "缴费金额";
            this.缴费金额DataGridViewTextBoxColumn.HeaderText = "缴费金额";
            this.缴费金额DataGridViewTextBoxColumn.Name = "缴费金额DataGridViewTextBoxColumn";
            this.缴费金额DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 期始DataGridViewTextBoxColumn
            // 
            this.期始DataGridViewTextBoxColumn.DataPropertyName = "期始";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.期始DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.期始DataGridViewTextBoxColumn.HeaderText = "期始";
            this.期始DataGridViewTextBoxColumn.Name = "期始DataGridViewTextBoxColumn";
            this.期始DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 期止DataGridViewTextBoxColumn
            // 
            this.期止DataGridViewTextBoxColumn.DataPropertyName = "期止";
            dataGridViewCellStyle2.Format = "d";
            this.期止DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.期止DataGridViewTextBoxColumn.HeaderText = "期止";
            this.期止DataGridViewTextBoxColumn.Name = "期止DataGridViewTextBoxColumn";
            this.期止DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 付款人DataGridViewTextBoxColumn
            // 
            this.付款人DataGridViewTextBoxColumn.DataPropertyName = "付款人";
            this.付款人DataGridViewTextBoxColumn.HeaderText = "付款人";
            this.付款人DataGridViewTextBoxColumn.Name = "付款人DataGridViewTextBoxColumn";
            this.付款人DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 收款人DataGridViewTextBoxColumn
            // 
            this.收款人DataGridViewTextBoxColumn.DataPropertyName = "收款人";
            this.收款人DataGridViewTextBoxColumn.HeaderText = "收款人";
            this.收款人DataGridViewTextBoxColumn.Name = "收款人DataGridViewTextBoxColumn";
            this.收款人DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 备注DataGridViewTextBoxColumn
            // 
            this.备注DataGridViewTextBoxColumn.DataPropertyName = "备注";
            this.备注DataGridViewTextBoxColumn.HeaderText = "备注";
            this.备注DataGridViewTextBoxColumn.Name = "备注DataGridViewTextBoxColumn";
            this.备注DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 缴费Form
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 458);
            this.Controls.Add(备注Label);
            this.Controls.Add(付款人Label);
            this.Controls.Add(this.kryptonTextBox2);
            this.Controls.Add(this.kryptonTextBox3);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(收款人Label);
            this.Controls.Add(期止Label);
            this.Controls.Add(期始Label);
            this.Controls.Add(this.kryptonNumericUpDown1);
            this.Controls.Add(缴费金额Label);
            this.Controls.Add(this.kryptonDateTimePicker3);
            this.Controls.Add(this.kryptonDateTimePicker2);
            this.Controls.Add(this.kryptonDateTimePicker1);
            this.Controls.Add(缴费时间Label);
            this.Controls.Add(缴费项Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPayItem);
            this.Controls.Add(this.cmbYF);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "缴费Form";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "缴费";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.缴费Form_FormClosed);
            this.Load += new System.EventHandler(this.缴费Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房缴费明细BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.参考历史BindingSource)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbYF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPayItem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource 源房缴费明细BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbYF;
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbPayItem;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker1;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox3;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnOkAndContinue;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private System.Windows.Forms.BindingSource 参考历史BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn 缴费时间DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 缴费项DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 缴费金额DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 期始DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 期止DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 付款人DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 收款人DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注DataGridViewTextBoxColumn;
    }
}