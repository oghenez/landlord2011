namespace Landlord2.UI
{
    partial class 客房收租Form
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
            System.Windows.Forms.Label 付款日期Label;
            System.Windows.Forms.Label 实付金额Label;
            System.Windows.Forms.Label 付款人Label;
            System.Windows.Forms.Label 收款人Label;
            System.Windows.Forms.Label 备注Label;
            System.Windows.Forms.Label 月租金Label;
            System.Windows.Forms.Label 月宽带费Label;
            System.Windows.Forms.Label 月物业费Label;
            System.Windows.Forms.Label 月厨房费Label;
            System.Windows.Forms.Label 水始码Label;
            System.Windows.Forms.Label 电始码Label;
            System.Windows.Forms.Label 气始码Label;
            System.Windows.Forms.Label 起付日期Label;
            System.Windows.Forms.Label 止付日期Label;
            System.Windows.Forms.Label 租户Label;
            System.Windows.Forms.Label 押金Label;
            System.Windows.Forms.Label 历史余额label;
            ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel2;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.应付金额Label = new System.Windows.Forms.Label();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.客房租金明细BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonDateTimePicker2 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.nud水费 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.nud电费 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.nud气费 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown5 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txt备注 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDayMonth = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblDayMonth = new System.Windows.Forms.Label();
            this.参考历史BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.起付日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.止付日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.付款日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.水止码DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.电止码DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.气止码DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.应付金额DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.实付金额DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.付款人DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.收款人DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.月租金Label1 = new System.Windows.Forms.Label();
            this.水始码Label1 = new System.Windows.Forms.Label();
            this.lbl水费 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.月宽带费Label1 = new System.Windows.Forms.Label();
            this.电始码Label1 = new System.Windows.Forms.Label();
            this.lbl电费 = new System.Windows.Forms.Label();
            this.月物业费Label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.气始码Label1 = new System.Windows.Forms.Label();
            this.lbl气费 = new System.Windows.Forms.Label();
            this.kryptonSeparator1 = new ComponentFactory.Krypton.Toolkit.KryptonSeparator();
            this.月厨房费Label1 = new System.Windows.Forms.Label();
            this.押金Label1 = new System.Windows.Forms.Label();
            this.起付日期Label1 = new System.Windows.Forms.Label();
            this.止付日期Label1 = new System.Windows.Forms.Label();
            this.租户Label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            付款日期Label = new System.Windows.Forms.Label();
            实付金额Label = new System.Windows.Forms.Label();
            付款人Label = new System.Windows.Forms.Label();
            收款人Label = new System.Windows.Forms.Label();
            备注Label = new System.Windows.Forms.Label();
            月租金Label = new System.Windows.Forms.Label();
            月宽带费Label = new System.Windows.Forms.Label();
            月物业费Label = new System.Windows.Forms.Label();
            月厨房费Label = new System.Windows.Forms.Label();
            水始码Label = new System.Windows.Forms.Label();
            电始码Label = new System.Windows.Forms.Label();
            气始码Label = new System.Windows.Forms.Label();
            起付日期Label = new System.Windows.Forms.Label();
            止付日期Label = new System.Windows.Forms.Label();
            租户Label = new System.Windows.Forms.Label();
            押金Label = new System.Windows.Forms.Label();
            历史余额label = new System.Windows.Forms.Label();
            kryptonWrapLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            ((System.ComponentModel.ISupportInitialize)(this.客房租金明细BindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDayMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.参考历史BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator1)).BeginInit();
            this.SuspendLayout();
            // 
            // 付款日期Label
            // 
            付款日期Label.AutoSize = true;
            付款日期Label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            付款日期Label.Location = new System.Drawing.Point(523, 46);
            付款日期Label.Name = "付款日期Label";
            付款日期Label.Size = new System.Drawing.Size(70, 14);
            付款日期Label.TabIndex = 7;
            付款日期Label.Text = "收租日期:";
            // 
            // 实付金额Label
            // 
            实付金额Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            实付金额Label.AutoSize = true;
            实付金额Label.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            实付金额Label.ForeColor = System.Drawing.Color.Red;
            实付金额Label.Location = new System.Drawing.Point(506, 106);
            实付金额Label.Name = "实付金额Label";
            实付金额Label.Size = new System.Drawing.Size(64, 12);
            实付金额Label.TabIndex = 17;
            实付金额Label.Text = "实付金额:";
            // 
            // 付款人Label
            // 
            付款人Label.AutoSize = true;
            付款人Label.Location = new System.Drawing.Point(30, 211);
            付款人Label.Name = "付款人Label";
            付款人Label.Size = new System.Drawing.Size(47, 12);
            付款人Label.TabIndex = 19;
            付款人Label.Text = "付款人:";
            // 
            // 收款人Label
            // 
            收款人Label.AutoSize = true;
            收款人Label.Location = new System.Drawing.Point(209, 211);
            收款人Label.Name = "收款人Label";
            收款人Label.Size = new System.Drawing.Size(47, 12);
            收款人Label.TabIndex = 21;
            收款人Label.Text = "收款人:";
            // 
            // 备注Label
            // 
            备注Label.AutoSize = true;
            备注Label.Location = new System.Drawing.Point(397, 211);
            备注Label.Name = "备注Label";
            备注Label.Size = new System.Drawing.Size(35, 12);
            备注Label.TabIndex = 23;
            备注Label.Text = "备注:";
            // 
            // 月租金Label
            // 
            月租金Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            月租金Label.AutoSize = true;
            月租金Label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            月租金Label.Location = new System.Drawing.Point(345, 9);
            月租金Label.Name = "月租金Label";
            月租金Label.Size = new System.Drawing.Size(45, 14);
            月租金Label.TabIndex = 28;
            月租金Label.Text = "租金:";
            // 
            // 月宽带费Label
            // 
            月宽带费Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            月宽带费Label.AutoSize = true;
            月宽带费Label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            月宽带费Label.Location = new System.Drawing.Point(330, 41);
            月宽带费Label.Name = "月宽带费Label";
            月宽带费Label.Size = new System.Drawing.Size(60, 14);
            月宽带费Label.TabIndex = 28;
            月宽带费Label.Text = "宽带费:";
            // 
            // 月物业费Label
            // 
            月物业费Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            月物业费Label.AutoSize = true;
            月物业费Label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            月物业费Label.Location = new System.Drawing.Point(330, 73);
            月物业费Label.Name = "月物业费Label";
            月物业费Label.Size = new System.Drawing.Size(60, 14);
            月物业费Label.TabIndex = 28;
            月物业费Label.Text = "物业费:";
            // 
            // 月厨房费Label
            // 
            月厨房费Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            月厨房费Label.AutoSize = true;
            月厨房费Label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            月厨房费Label.Location = new System.Drawing.Point(330, 105);
            月厨房费Label.Name = "月厨房费Label";
            月厨房费Label.Size = new System.Drawing.Size(60, 14);
            月厨房费Label.TabIndex = 28;
            月厨房费Label.Text = "厨房费:";
            // 
            // 水始码Label
            // 
            水始码Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            水始码Label.AutoSize = true;
            水始码Label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            水始码Label.Location = new System.Drawing.Point(22, 41);
            水始码Label.Name = "水始码Label";
            水始码Label.Size = new System.Drawing.Size(45, 14);
            水始码Label.TabIndex = 29;
            水始码Label.Text = "水费:";
            // 
            // 电始码Label
            // 
            电始码Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            电始码Label.AutoSize = true;
            电始码Label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            电始码Label.Location = new System.Drawing.Point(22, 73);
            电始码Label.Name = "电始码Label";
            电始码Label.Size = new System.Drawing.Size(45, 14);
            电始码Label.TabIndex = 30;
            电始码Label.Text = "电费:";
            // 
            // 气始码Label
            // 
            气始码Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            气始码Label.AutoSize = true;
            气始码Label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            气始码Label.Location = new System.Drawing.Point(22, 105);
            气始码Label.Name = "气始码Label";
            气始码Label.Size = new System.Drawing.Size(45, 14);
            气始码Label.TabIndex = 31;
            气始码Label.Text = "气费:";
            // 
            // 起付日期Label
            // 
            起付日期Label.AutoSize = true;
            起付日期Label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            起付日期Label.Location = new System.Drawing.Point(231, 46);
            起付日期Label.Name = "起付日期Label";
            起付日期Label.Size = new System.Drawing.Size(56, 14);
            起付日期Label.TabIndex = 36;
            起付日期Label.Text = "支付期:";
            // 
            // 止付日期Label
            // 
            止付日期Label.AutoSize = true;
            止付日期Label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            止付日期Label.Location = new System.Drawing.Point(362, 46);
            止付日期Label.Name = "止付日期Label";
            止付日期Label.Size = new System.Drawing.Size(21, 14);
            止付日期Label.TabIndex = 37;
            止付日期Label.Text = "～";
            // 
            // 租户Label
            // 
            租户Label.AutoSize = true;
            租户Label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            租户Label.Location = new System.Drawing.Point(35, 46);
            租户Label.Name = "租户Label";
            租户Label.Size = new System.Drawing.Size(42, 14);
            租户Label.TabIndex = 38;
            租户Label.Text = "租户:";
            // 
            // 押金Label
            // 
            押金Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            押金Label.AutoSize = true;
            押金Label.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            押金Label.Location = new System.Drawing.Point(525, 9);
            押金Label.Name = "押金Label";
            押金Label.Size = new System.Drawing.Size(45, 14);
            押金Label.TabIndex = 39;
            押金Label.Text = "押金:";
            // 
            // 历史余额label
            // 
            历史余额label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            历史余额label.AutoSize = true;
            历史余额label.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            历史余额label.ForeColor = System.Drawing.Color.Green;
            历史余额label.Location = new System.Drawing.Point(506, 74);
            历史余额label.Name = "历史余额label";
            历史余额label.Size = new System.Drawing.Size(64, 12);
            历史余额label.TabIndex = 39;
            历史余额label.Text = "历史余额:";
            // 
            // kryptonWrapLabel2
            // 
            kryptonWrapLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            kryptonWrapLabel2.ForeColor = System.Drawing.Color.Black;
            kryptonWrapLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            kryptonWrapLabel2.Location = new System.Drawing.Point(6, 17);
            kryptonWrapLabel2.Name = "kryptonWrapLabel2";
            kryptonWrapLabel2.Size = new System.Drawing.Size(160, 15);
            kryptonWrapLabel2.Text = "尾期不足月按：               计算";
            kryptonWrapLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            kryptonWrapLabel2.UseMnemonic = false;
            // 
            // 应付金额Label
            // 
            this.应付金额Label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.应付金额Label.AutoSize = true;
            this.应付金额Label.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.应付金额Label.ForeColor = System.Drawing.Color.Red;
            this.应付金额Label.Location = new System.Drawing.Point(506, 42);
            this.应付金额Label.Name = "应付金额Label";
            this.应付金额Label.Size = new System.Drawing.Size(64, 12);
            this.应付金额Label.TabIndex = 15;
            this.应付金额Label.Text = "本期应付:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(613, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(482, 18);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 0;
            this.btnOK.Values.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // 客房租金明细BindingSource
            // 
            this.客房租金明细BindingSource.DataSource = typeof(Landlord2.Data.客房租金明细);
            // 
            // kryptonDateTimePicker2
            // 
            this.kryptonDateTimePicker2.CalendarTodayDate = new System.DateTime(2011, 9, 10, 0, 0, 0, 0);
            this.kryptonDateTimePicker2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.客房租金明细BindingSource, "付款日期", true));
            this.kryptonDateTimePicker2.Location = new System.Drawing.Point(595, 42);
            this.kryptonDateTimePicker2.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.kryptonDateTimePicker2.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.kryptonDateTimePicker2.Name = "kryptonDateTimePicker2";
            this.kryptonDateTimePicker2.Size = new System.Drawing.Size(110, 21);
            this.kryptonDateTimePicker2.TabIndex = 0;
            // 
            // nud水费
            // 
            this.nud水费.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nud水费.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.客房租金明细BindingSource, "水止码", true));
            this.nud水费.DecimalPlaces = 1;
            this.nud水费.Location = new System.Drawing.Point(143, 37);
            this.nud水费.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nud水费.Name = "nud水费";
            this.nud水费.Size = new System.Drawing.Size(74, 22);
            this.nud水费.TabIndex = 0;
            this.nud水费.ValueChanged += new System.EventHandler(this.kryptonNumericUpDown_ValueChanged);
            // 
            // nud电费
            // 
            this.nud电费.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nud电费.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.客房租金明细BindingSource, "电止码", true));
            this.nud电费.DecimalPlaces = 1;
            this.nud电费.Location = new System.Drawing.Point(143, 69);
            this.nud电费.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nud电费.Name = "nud电费";
            this.nud电费.Size = new System.Drawing.Size(74, 22);
            this.nud电费.TabIndex = 1;
            this.nud电费.ValueChanged += new System.EventHandler(this.kryptonNumericUpDown_ValueChanged);
            // 
            // nud气费
            // 
            this.nud气费.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nud气费.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.客房租金明细BindingSource, "气止码", true));
            this.nud气费.DecimalPlaces = 1;
            this.nud气费.Location = new System.Drawing.Point(143, 101);
            this.nud气费.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nud气费.Name = "nud气费";
            this.nud气费.Size = new System.Drawing.Size(74, 22);
            this.nud气费.TabIndex = 2;
            this.nud气费.ValueChanged += new System.EventHandler(this.kryptonNumericUpDown_ValueChanged);
            // 
            // kryptonNumericUpDown5
            // 
            this.kryptonNumericUpDown5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonNumericUpDown5.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.客房租金明细BindingSource, "实付金额", true));
            this.kryptonNumericUpDown5.DecimalPlaces = 2;
            this.kryptonNumericUpDown5.Location = new System.Drawing.Point(576, 101);
            this.kryptonNumericUpDown5.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.kryptonNumericUpDown5.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.kryptonNumericUpDown5.Name = "kryptonNumericUpDown5";
            this.kryptonNumericUpDown5.Size = new System.Drawing.Size(91, 21);
            this.kryptonNumericUpDown5.StateCommon.Content.Color1 = System.Drawing.Color.Red;
            this.kryptonNumericUpDown5.StateCommon.Content.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonNumericUpDown5.TabIndex = 3;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.客房租金明细BindingSource, "付款人", true));
            this.kryptonTextBox1.Location = new System.Drawing.Point(82, 207);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(80, 20);
            this.kryptonTextBox1.TabIndex = 1;
            // 
            // kryptonTextBox2
            // 
            this.kryptonTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.客房租金明细BindingSource, "收款人", true));
            this.kryptonTextBox2.Location = new System.Drawing.Point(438, 207);
            this.kryptonTextBox2.Name = "kryptonTextBox2";
            this.kryptonTextBox2.Size = new System.Drawing.Size(267, 20);
            this.kryptonTextBox2.TabIndex = 2;
            // 
            // txt备注
            // 
            this.txt备注.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.客房租金明细BindingSource, "备注", true));
            this.txt备注.Location = new System.Drawing.Point(262, 208);
            this.txt备注.Multiline = true;
            this.txt备注.Name = "txt备注";
            this.txt备注.Size = new System.Drawing.Size(80, 19);
            this.txt备注.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 397);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 60);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDayMonth);
            this.groupBox1.Controls.Add(kryptonWrapLabel2);
            this.groupBox1.Controls.Add(this.lblDayMonth);
            this.groupBox1.Location = new System.Drawing.Point(19, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 42);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // cmbDayMonth
            // 
            this.cmbDayMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDayMonth.DropDownWidth = 54;
            this.cmbDayMonth.Items.AddRange(new object[] {
            "月",
            "天"});
            this.cmbDayMonth.Location = new System.Drawing.Point(95, 14);
            this.cmbDayMonth.Name = "cmbDayMonth";
            this.cmbDayMonth.Size = new System.Drawing.Size(41, 21);
            this.cmbDayMonth.StateCommon.ComboBox.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbDayMonth.TabIndex = 63;
            this.cmbDayMonth.Text = "月";
            this.cmbDayMonth.SelectedIndexChanged += new System.EventHandler(this.cmbDayMonth_Changed);
            // 
            // lblDayMonth
            // 
            this.lblDayMonth.AutoSize = true;
            this.lblDayMonth.ForeColor = System.Drawing.Color.Red;
            this.lblDayMonth.Location = new System.Drawing.Point(172, 19);
            this.lblDayMonth.Name = "lblDayMonth";
            this.lblDayMonth.Size = new System.Drawing.Size(155, 12);
            this.lblDayMonth.TabIndex = 65;
            this.lblDayMonth.Text = "尾期{0}～{1}不足月({2}天)";
            // 
            // 参考历史BindingSource
            // 
            this.参考历史BindingSource.DataSource = typeof(Landlord2.Data.客房租金明细);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(0, 233);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            this.kryptonGroupBox1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonDataGridView1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(740, 164);
            this.kryptonGroupBox1.TabIndex = 25;
            this.kryptonGroupBox1.Text = "参考：该客房历史缴费";
            this.kryptonGroupBox1.Values.Heading = "参考：该客房历史缴费";
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AllowUserToAddRows = false;
            this.kryptonDataGridView1.AllowUserToDeleteRows = false;
            this.kryptonDataGridView1.AutoGenerateColumns = false;
            this.kryptonDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.kryptonDataGridView1.DataSource = this.参考历史BindingSource;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonDataGridView1.ReadOnly = true;
            this.kryptonDataGridView1.RowHeadersWidth = 25;
            this.kryptonDataGridView1.RowTemplate.Height = 23;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(736, 142);
            this.kryptonDataGridView1.TabIndex = 1;
            // 
            // 起付日期DataGridViewTextBoxColumn
            // 
            this.起付日期DataGridViewTextBoxColumn.DataPropertyName = "起付日期";
            dataGridViewCellStyle1.Format = "d";
            this.起付日期DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.起付日期DataGridViewTextBoxColumn.FillWeight = 90F;
            this.起付日期DataGridViewTextBoxColumn.HeaderText = "起付日期";
            this.起付日期DataGridViewTextBoxColumn.Name = "起付日期DataGridViewTextBoxColumn";
            this.起付日期DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 止付日期DataGridViewTextBoxColumn
            // 
            this.止付日期DataGridViewTextBoxColumn.DataPropertyName = "止付日期";
            dataGridViewCellStyle2.Format = "d";
            this.止付日期DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.止付日期DataGridViewTextBoxColumn.FillWeight = 90F;
            this.止付日期DataGridViewTextBoxColumn.HeaderText = "止付日期";
            this.止付日期DataGridViewTextBoxColumn.Name = "止付日期DataGridViewTextBoxColumn";
            this.止付日期DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 付款日期DataGridViewTextBoxColumn
            // 
            this.付款日期DataGridViewTextBoxColumn.DataPropertyName = "付款日期";
            dataGridViewCellStyle3.Format = "d";
            this.付款日期DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.付款日期DataGridViewTextBoxColumn.FillWeight = 90F;
            this.付款日期DataGridViewTextBoxColumn.HeaderText = "付款日期";
            this.付款日期DataGridViewTextBoxColumn.Name = "付款日期DataGridViewTextBoxColumn";
            this.付款日期DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 水止码DataGridViewTextBoxColumn
            // 
            this.水止码DataGridViewTextBoxColumn.DataPropertyName = "水止码";
            this.水止码DataGridViewTextBoxColumn.FillWeight = 80F;
            this.水止码DataGridViewTextBoxColumn.HeaderText = "水止码";
            this.水止码DataGridViewTextBoxColumn.Name = "水止码DataGridViewTextBoxColumn";
            this.水止码DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 电止码DataGridViewTextBoxColumn
            // 
            this.电止码DataGridViewTextBoxColumn.DataPropertyName = "电止码";
            this.电止码DataGridViewTextBoxColumn.FillWeight = 80F;
            this.电止码DataGridViewTextBoxColumn.HeaderText = "电止码";
            this.电止码DataGridViewTextBoxColumn.Name = "电止码DataGridViewTextBoxColumn";
            this.电止码DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 气止码DataGridViewTextBoxColumn
            // 
            this.气止码DataGridViewTextBoxColumn.DataPropertyName = "气止码";
            this.气止码DataGridViewTextBoxColumn.FillWeight = 80F;
            this.气止码DataGridViewTextBoxColumn.HeaderText = "气止码";
            this.气止码DataGridViewTextBoxColumn.Name = "气止码DataGridViewTextBoxColumn";
            this.气止码DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 应付金额DataGridViewTextBoxColumn
            // 
            this.应付金额DataGridViewTextBoxColumn.DataPropertyName = "应付金额";
            this.应付金额DataGridViewTextBoxColumn.FillWeight = 82F;
            this.应付金额DataGridViewTextBoxColumn.HeaderText = "应付金额";
            this.应付金额DataGridViewTextBoxColumn.Name = "应付金额DataGridViewTextBoxColumn";
            this.应付金额DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 实付金额DataGridViewTextBoxColumn
            // 
            this.实付金额DataGridViewTextBoxColumn.DataPropertyName = "实付金额";
            this.实付金额DataGridViewTextBoxColumn.FillWeight = 82F;
            this.实付金额DataGridViewTextBoxColumn.HeaderText = "实付金额";
            this.实付金额DataGridViewTextBoxColumn.Name = "实付金额DataGridViewTextBoxColumn";
            this.实付金额DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 付款人DataGridViewTextBoxColumn
            // 
            this.付款人DataGridViewTextBoxColumn.DataPropertyName = "付款人";
            this.付款人DataGridViewTextBoxColumn.FillWeight = 75F;
            this.付款人DataGridViewTextBoxColumn.HeaderText = "付款人";
            this.付款人DataGridViewTextBoxColumn.Name = "付款人DataGridViewTextBoxColumn";
            this.付款人DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 收款人DataGridViewTextBoxColumn
            // 
            this.收款人DataGridViewTextBoxColumn.DataPropertyName = "收款人";
            this.收款人DataGridViewTextBoxColumn.FillWeight = 75F;
            this.收款人DataGridViewTextBoxColumn.HeaderText = "收款人";
            this.收款人DataGridViewTextBoxColumn.Name = "收款人DataGridViewTextBoxColumn";
            this.收款人DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 备注DataGridViewTextBoxColumn
            // 
            this.备注DataGridViewTextBoxColumn.DataPropertyName = "备注";
            this.备注DataGridViewTextBoxColumn.FillWeight = 40F;
            this.备注DataGridViewTextBoxColumn.HeaderText = "备注";
            this.备注DataGridViewTextBoxColumn.Name = "备注DataGridViewTextBoxColumn";
            this.备注DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(740, 33);
            this.kryptonHeader1.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonHeader1.TabIndex = 26;
            this.kryptonHeader1.Values.Description = "客房";
            this.kryptonHeader1.Values.Heading = "当前选择的源房";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel1.Controls.Add(月租金Label, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.月租金Label1, 6, 0);
            this.tableLayoutPanel1.Controls.Add(水始码Label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.水始码Label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.nud水费, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl水费, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(月宽带费Label, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.月宽带费Label1, 6, 1);
            this.tableLayoutPanel1.Controls.Add(电始码Label, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.电始码Label1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.nud电费, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl电费, 3, 2);
            this.tableLayoutPanel1.Controls.Add(月物业费Label, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.月物业费Label1, 6, 2);
            this.tableLayoutPanel1.Controls.Add(历史余额label, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBalance, 8, 2);
            this.tableLayoutPanel1.Controls.Add(气始码Label, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.气始码Label1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.nud气费, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl气费, 3, 3);
            this.tableLayoutPanel1.Controls.Add(实付金额Label, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.kryptonNumericUpDown5, 8, 3);
            this.tableLayoutPanel1.Controls.Add(this.kryptonSeparator1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.月厨房费Label1, 6, 3);
            this.tableLayoutPanel1.Controls.Add(月厨房费Label, 5, 3);
            this.tableLayoutPanel1.Controls.Add(押金Label, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.应付金额Label, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.押金Label1, 8, 0);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(35, 69);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(670, 128);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // 月租金Label1
            // 
            this.月租金Label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.月租金Label1.AutoSize = true;
            this.月租金Label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.月租金Label1.ForeColor = System.Drawing.Color.Blue;
            this.月租金Label1.Location = new System.Drawing.Point(465, 9);
            this.月租金Label1.Name = "月租金Label1";
            this.月租金Label1.Size = new System.Drawing.Size(15, 14);
            this.月租金Label1.TabIndex = 29;
            this.月租金Label1.Text = "0";
            // 
            // 水始码Label1
            // 
            this.水始码Label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.水始码Label1.AutoSize = true;
            this.水始码Label1.Location = new System.Drawing.Point(73, 42);
            this.水始码Label1.Name = "水始码Label1";
            this.水始码Label1.Size = new System.Drawing.Size(35, 12);
            this.水始码Label1.TabIndex = 30;
            this.水始码Label1.Text = "12345";
            // 
            // lbl水费
            // 
            this.lbl水费.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl水费.AutoSize = true;
            this.lbl水费.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl水费.ForeColor = System.Drawing.Color.Blue;
            this.lbl水费.Location = new System.Drawing.Point(250, 41);
            this.lbl水费.Name = "lbl水费";
            this.lbl水费.Size = new System.Drawing.Size(15, 14);
            this.lbl水费.TabIndex = 34;
            this.lbl水费.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "本期始码";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "本期止码";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "金额";
            // 
            // 月宽带费Label1
            // 
            this.月宽带费Label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.月宽带费Label1.AutoSize = true;
            this.月宽带费Label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.月宽带费Label1.ForeColor = System.Drawing.Color.Blue;
            this.月宽带费Label1.Location = new System.Drawing.Point(465, 41);
            this.月宽带费Label1.Name = "月宽带费Label1";
            this.月宽带费Label1.Size = new System.Drawing.Size(15, 14);
            this.月宽带费Label1.TabIndex = 29;
            this.月宽带费Label1.Text = "0";
            // 
            // 电始码Label1
            // 
            this.电始码Label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.电始码Label1.AutoSize = true;
            this.电始码Label1.Location = new System.Drawing.Point(73, 74);
            this.电始码Label1.Name = "电始码Label1";
            this.电始码Label1.Size = new System.Drawing.Size(35, 12);
            this.电始码Label1.TabIndex = 31;
            this.电始码Label1.Text = "12345";
            // 
            // lbl电费
            // 
            this.lbl电费.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl电费.AutoSize = true;
            this.lbl电费.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl电费.ForeColor = System.Drawing.Color.Blue;
            this.lbl电费.Location = new System.Drawing.Point(250, 73);
            this.lbl电费.Name = "lbl电费";
            this.lbl电费.Size = new System.Drawing.Size(15, 14);
            this.lbl电费.TabIndex = 35;
            this.lbl电费.Text = "0";
            // 
            // 月物业费Label1
            // 
            this.月物业费Label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.月物业费Label1.AutoSize = true;
            this.月物业费Label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.月物业费Label1.ForeColor = System.Drawing.Color.Blue;
            this.月物业费Label1.Location = new System.Drawing.Point(465, 73);
            this.月物业费Label1.Name = "月物业费Label1";
            this.月物业费Label1.Size = new System.Drawing.Size(15, 14);
            this.月物业费Label1.TabIndex = 29;
            this.月物业费Label1.Text = "0";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.客房租金明细BindingSource, "应付金额", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "F2"));
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(615, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 14);
            this.label4.TabIndex = 32;
            this.label4.Text = "12345";
            this.toolTip1.SetToolTip(this.label4, "[历史余额]不计算在内");
            // 
            // lblBalance
            // 
            this.lblBalance.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.lblBalance.ForeColor = System.Drawing.Color.Green;
            this.lblBalance.Location = new System.Drawing.Point(651, 73);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(16, 14);
            this.lblBalance.TabIndex = 40;
            this.lblBalance.Text = "0";
            // 
            // 气始码Label1
            // 
            this.气始码Label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.气始码Label1.AutoSize = true;
            this.气始码Label1.Location = new System.Drawing.Point(73, 106);
            this.气始码Label1.Name = "气始码Label1";
            this.气始码Label1.Size = new System.Drawing.Size(35, 12);
            this.气始码Label1.TabIndex = 32;
            this.气始码Label1.Text = "12345";
            // 
            // lbl气费
            // 
            this.lbl气费.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl气费.AutoSize = true;
            this.lbl气费.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl气费.ForeColor = System.Drawing.Color.Blue;
            this.lbl气费.Location = new System.Drawing.Point(250, 105);
            this.lbl气费.Name = "lbl气费";
            this.lbl气费.Size = new System.Drawing.Size(15, 14);
            this.lbl气费.TabIndex = 36;
            this.lbl气费.Text = "0";
            // 
            // kryptonSeparator1
            // 
            this.kryptonSeparator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSeparator1.Location = new System.Drawing.Point(295, 0);
            this.kryptonSeparator1.Margin = new System.Windows.Forms.Padding(0);
            this.kryptonSeparator1.Name = "kryptonSeparator1";
            this.tableLayoutPanel1.SetRowSpan(this.kryptonSeparator1, 4);
            this.kryptonSeparator1.Size = new System.Drawing.Size(8, 128);
            this.kryptonSeparator1.TabIndex = 41;
            // 
            // 月厨房费Label1
            // 
            this.月厨房费Label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.月厨房费Label1.AutoSize = true;
            this.月厨房费Label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.月厨房费Label1.ForeColor = System.Drawing.Color.Blue;
            this.月厨房费Label1.Location = new System.Drawing.Point(465, 105);
            this.月厨房费Label1.Name = "月厨房费Label1";
            this.月厨房费Label1.Size = new System.Drawing.Size(15, 14);
            this.月厨房费Label1.TabIndex = 29;
            this.月厨房费Label1.Text = "0";
            // 
            // 押金Label1
            // 
            this.押金Label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.押金Label1.AutoSize = true;
            this.押金Label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.押金Label1.ForeColor = System.Drawing.Color.Blue;
            this.押金Label1.Location = new System.Drawing.Point(652, 9);
            this.押金Label1.Name = "押金Label1";
            this.押金Label1.Size = new System.Drawing.Size(15, 14);
            this.押金Label1.TabIndex = 40;
            this.押金Label1.Text = "0";
            // 
            // 起付日期Label1
            // 
            this.起付日期Label1.AutoSize = true;
            this.起付日期Label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.客房租金明细BindingSource, "起付日期", true));
            this.起付日期Label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.起付日期Label1.Location = new System.Drawing.Point(287, 46);
            this.起付日期Label1.Name = "起付日期Label1";
            this.起付日期Label1.Size = new System.Drawing.Size(77, 14);
            this.起付日期Label1.TabIndex = 37;
            this.起付日期Label1.Text = "2010-10-10";
            // 
            // 止付日期Label1
            // 
            this.止付日期Label1.AutoSize = true;
            this.止付日期Label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.客房租金明细BindingSource, "止付日期", true));
            this.止付日期Label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.止付日期Label1.Location = new System.Drawing.Point(379, 46);
            this.止付日期Label1.Name = "止付日期Label1";
            this.止付日期Label1.Size = new System.Drawing.Size(77, 14);
            this.止付日期Label1.TabIndex = 38;
            this.止付日期Label1.Text = "2010-10-10";
            // 
            // 租户Label1
            // 
            this.租户Label1.AutoSize = true;
            this.租户Label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.租户Label1.Location = new System.Drawing.Point(80, 46);
            this.租户Label1.Name = "租户Label1";
            this.租户Label1.Size = new System.Drawing.Size(63, 14);
            this.租户Label1.TabIndex = 39;
            this.租户Label1.Text = "租户姓名";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 10;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "起付日期";
            dataGridViewCellStyle4.Format = "d";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.FillWeight = 85F;
            this.dataGridViewTextBoxColumn1.HeaderText = "起付日期";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "止付日期";
            dataGridViewCellStyle5.Format = "d";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.FillWeight = 84F;
            this.dataGridViewTextBoxColumn2.HeaderText = "止付日期";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 64;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "付款日期";
            dataGridViewCellStyle6.Format = "d";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.FillWeight = 86F;
            this.dataGridViewTextBoxColumn3.HeaderText = "付款日期";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 65;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "水止码";
            this.dataGridViewTextBoxColumn4.FillWeight = 82.08121F;
            this.dataGridViewTextBoxColumn4.HeaderText = "水止码";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 65;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "电止码";
            this.dataGridViewTextBoxColumn5.FillWeight = 82.08121F;
            this.dataGridViewTextBoxColumn5.HeaderText = "电止码";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 64;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "气止码";
            this.dataGridViewTextBoxColumn6.FillWeight = 82.08121F;
            this.dataGridViewTextBoxColumn6.HeaderText = "气止码";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 65;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "应付金额";
            this.dataGridViewTextBoxColumn7.FillWeight = 82.08121F;
            this.dataGridViewTextBoxColumn7.HeaderText = "应付金额";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 64;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "实付金额";
            this.dataGridViewTextBoxColumn8.FillWeight = 82.08121F;
            this.dataGridViewTextBoxColumn8.HeaderText = "实付金额";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 65;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "付款人";
            this.dataGridViewTextBoxColumn9.FillWeight = 79.18787F;
            this.dataGridViewTextBoxColumn9.HeaderText = "付款人";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 65;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "收款人";
            this.dataGridViewTextBoxColumn10.FillWeight = 80F;
            this.dataGridViewTextBoxColumn10.HeaderText = "收款人";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 64;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "备注";
            this.dataGridViewTextBoxColumn11.FillWeight = 82.08121F;
            this.dataGridViewTextBoxColumn11.HeaderText = "备注";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 65;
            // 
            // 客房收租Form
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(740, 457);
            this.Controls.Add(备注Label);
            this.Controls.Add(租户Label);
            this.Controls.Add(this.租户Label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.kryptonHeader1);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonTextBox2);
            this.Controls.Add(付款日期Label);
            this.Controls.Add(this.kryptonDateTimePicker2);
            this.Controls.Add(起付日期Label);
            this.Controls.Add(this.起付日期Label1);
            this.Controls.Add(止付日期Label);
            this.Controls.Add(this.止付日期Label1);
            this.Controls.Add(付款人Label);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(收款人Label);
            this.Controls.Add(this.txt备注);
            this.Name = "客房收租Form";
            this.Text = "客房收租";
            this.Load += new System.EventHandler(this.客房收租Form_Load);
            this.Shown += new System.EventHandler(this.客房收租Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.客房租金明细BindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDayMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.参考历史BindingSource)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private System.Windows.Forms.BindingSource 客房租金明细BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker2;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nud水费;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nud电费;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nud气费;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt备注;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource 参考历史BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label 月租金Label1;
        private System.Windows.Forms.Label 月厨房费Label1;
        private System.Windows.Forms.Label 月物业费Label1;
        private System.Windows.Forms.Label 月宽带费Label1;
        private System.Windows.Forms.Label 气始码Label1;
        private System.Windows.Forms.Label 电始码Label1;
        private System.Windows.Forms.Label 水始码Label1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl水费;
        private System.Windows.Forms.Label lbl电费;
        private System.Windows.Forms.Label lbl气费;
        private System.Windows.Forms.Label 起付日期Label1;
        private System.Windows.Forms.Label 止付日期Label1;
        private System.Windows.Forms.Label 租户Label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 起付日期DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 止付日期DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 付款日期DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 水止码DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 电止码DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 气止码DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 应付金额DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 实付金额DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 付款人DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 收款人DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注DataGridViewTextBoxColumn;
        private System.Windows.Forms.Label 押金Label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblBalance;
        private ComponentFactory.Krypton.Toolkit.KryptonSeparator kryptonSeparator1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label 应付金额Label;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbDayMonth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDayMonth;
    }
}