namespace Landlord2.UI
{
    partial class 提醒Form
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
            System.Windows.Forms.Label 创建日期Label;
            System.Windows.Forms.Label 客房IDLabel;
            System.Windows.Forms.Label 事项Label;
            System.Windows.Forms.Label 提醒时间Label;
            System.Windows.Forms.Label 完成日期Label;
            System.Windows.Forms.Label 已完成Label;
            System.Windows.Forms.Label 源房IDLabel;
            this.提醒BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonDateTimePicker1 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.cmb客房 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.客房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonDateTimePicker2 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonDateTimePicker3 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.cmb源房 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BtnOkAndContinue = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonCheckBox1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            创建日期Label = new System.Windows.Forms.Label();
            客房IDLabel = new System.Windows.Forms.Label();
            事项Label = new System.Windows.Forms.Label();
            提醒时间Label = new System.Windows.Forms.Label();
            完成日期Label = new System.Windows.Forms.Label();
            已完成Label = new System.Windows.Forms.Label();
            源房IDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.提醒BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb客房)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.客房BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb源房)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // 创建日期Label
            // 
            创建日期Label.AutoSize = true;
            创建日期Label.Location = new System.Drawing.Point(280, 25);
            创建日期Label.Name = "创建日期Label";
            创建日期Label.Size = new System.Drawing.Size(59, 12);
            创建日期Label.TabIndex = 3;
            创建日期Label.Text = "创建日期:";
            // 
            // 客房IDLabel
            // 
            客房IDLabel.AutoSize = true;
            客房IDLabel.Location = new System.Drawing.Point(280, 142);
            客房IDLabel.Name = "客房IDLabel";
            客房IDLabel.Size = new System.Drawing.Size(59, 12);
            客房IDLabel.TabIndex = 5;
            客房IDLabel.Text = "相关客房:";
            this.toolTip1.SetToolTip(客房IDLabel, "此条提醒涉及到的客房。（如不涉及客房，选择‘无’。）");
            // 
            // 事项Label
            // 
            事项Label.AutoSize = true;
            事项Label.Location = new System.Drawing.Point(45, 68);
            事项Label.Name = "事项Label";
            事项Label.Size = new System.Drawing.Size(35, 12);
            事项Label.TabIndex = 7;
            事项Label.Text = "事项:";
            // 
            // 提醒时间Label
            // 
            提醒时间Label.AutoSize = true;
            提醒时间Label.Location = new System.Drawing.Point(21, 25);
            提醒时间Label.Name = "提醒时间Label";
            提醒时间Label.Size = new System.Drawing.Size(59, 12);
            提醒时间Label.TabIndex = 9;
            提醒时间Label.Text = "提醒日期:";
            this.toolTip1.SetToolTip(提醒时间Label, "系统将根据【提醒设置】中设定的‘自定义提醒提前天数’，于此日期前XX日开始提醒。");
            // 
            // 完成日期Label
            // 
            完成日期Label.AutoSize = true;
            完成日期Label.Location = new System.Drawing.Point(280, 108);
            完成日期Label.Name = "完成日期Label";
            完成日期Label.Size = new System.Drawing.Size(59, 12);
            完成日期Label.TabIndex = 11;
            完成日期Label.Text = "完成日期:";
            // 
            // 已完成Label
            // 
            已完成Label.AutoSize = true;
            已完成Label.Location = new System.Drawing.Point(33, 108);
            已完成Label.Name = "已完成Label";
            已完成Label.Size = new System.Drawing.Size(47, 12);
            已完成Label.TabIndex = 13;
            已完成Label.Text = "已完成:";
            // 
            // 源房IDLabel
            // 
            源房IDLabel.AutoSize = true;
            源房IDLabel.Location = new System.Drawing.Point(21, 142);
            源房IDLabel.Name = "源房IDLabel";
            源房IDLabel.Size = new System.Drawing.Size(59, 12);
            源房IDLabel.TabIndex = 15;
            源房IDLabel.Text = "相关源房:";
            this.toolTip1.SetToolTip(源房IDLabel, "此条提醒涉及到的源房。");
            // 
            // 提醒BindingSource
            // 
            this.提醒BindingSource.DataSource = typeof(Landlord2.Data.提醒);
            // 
            // kryptonDateTimePicker1
            // 
            this.kryptonDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.提醒BindingSource, "创建日期", true));
            this.kryptonDateTimePicker1.Location = new System.Drawing.Point(345, 21);
            this.kryptonDateTimePicker1.Name = "kryptonDateTimePicker1";
            this.kryptonDateTimePicker1.Size = new System.Drawing.Size(134, 21);
            this.kryptonDateTimePicker1.TabIndex = 17;
            // 
            // cmb客房
            // 
            this.cmb客房.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.提醒BindingSource, "客房ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmb客房.DataSource = this.客房BindingSource;
            this.cmb客房.DisplayMember = "命名";
            this.cmb客房.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb客房.DropDownWidth = 134;
            this.cmb客房.Location = new System.Drawing.Point(345, 138);
            this.cmb客房.Name = "cmb客房";
            this.cmb客房.Size = new System.Drawing.Size(134, 21);
            this.cmb客房.TabIndex = 18;
            this.toolTip1.SetToolTip(this.cmb客房, "此条提醒涉及到的客房。（如不涉及客房，选择‘无’。）");
            this.cmb客房.ValueMember = "ID";
            // 
            // 客房BindingSource
            // 
            this.客房BindingSource.DataSource = typeof(Landlord2.Data.客房);
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.提醒BindingSource, "事项", true));
            this.kryptonTextBox1.Location = new System.Drawing.Point(86, 56);
            this.kryptonTextBox1.Multiline = true;
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(393, 36);
            this.kryptonTextBox1.TabIndex = 19;
            // 
            // kryptonDateTimePicker2
            // 
            this.kryptonDateTimePicker2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.提醒BindingSource, "提醒时间", true));
            this.kryptonDateTimePicker2.Location = new System.Drawing.Point(86, 21);
            this.kryptonDateTimePicker2.Name = "kryptonDateTimePicker2";
            this.kryptonDateTimePicker2.Size = new System.Drawing.Size(134, 21);
            this.kryptonDateTimePicker2.TabIndex = 17;
            this.toolTip1.SetToolTip(this.kryptonDateTimePicker2, "系统将根据【提醒设置】中设定的‘自定义提醒提前天数’，于此日期前XX日开始提醒。");
            // 
            // kryptonDateTimePicker3
            // 
            this.kryptonDateTimePicker3.Checked = false;
            this.kryptonDateTimePicker3.CustomNullText = "- 无 -";
            this.kryptonDateTimePicker3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.提醒BindingSource, "已完成", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.kryptonDateTimePicker3.DataBindings.Add(new System.Windows.Forms.Binding("ValueNullable", this.提醒BindingSource, "完成日期", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.kryptonDateTimePicker3.Location = new System.Drawing.Point(345, 104);
            this.kryptonDateTimePicker3.Name = "kryptonDateTimePicker3";
            this.kryptonDateTimePicker3.Size = new System.Drawing.Size(134, 21);
            this.kryptonDateTimePicker3.TabIndex = 17;
            // 
            // cmb源房
            // 
            this.cmb源房.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.提醒BindingSource, "源房ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmb源房.DataSource = this.源房BindingSource;
            this.cmb源房.DisplayMember = "房名";
            this.cmb源房.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb源房.DropDownWidth = 134;
            this.cmb源房.Location = new System.Drawing.Point(86, 138);
            this.cmb源房.Name = "cmb源房";
            this.cmb源房.Size = new System.Drawing.Size(134, 21);
            this.cmb源房.TabIndex = 18;
            this.toolTip1.SetToolTip(this.cmb源房, "此条提醒涉及到的源房。");
            this.cmb源房.ValueMember = "ID";
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord2.Data.源房);
            this.源房BindingSource.PositionChanged += new System.EventHandler(this.源房BindingSource_PositionChanged);
            // 
            // BtnOkAndContinue
            // 
            this.BtnOkAndContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOkAndContinue.Location = new System.Drawing.Point(176, 199);
            this.BtnOkAndContinue.Name = "BtnOkAndContinue";
            this.BtnOkAndContinue.Size = new System.Drawing.Size(90, 25);
            this.BtnOkAndContinue.TabIndex = 29;
            this.BtnOkAndContinue.Values.Text = "保存并继续";
            this.BtnOkAndContinue.Visible = false;
            this.BtnOkAndContinue.Click += new System.EventHandler(this.BtnOkAndContinue_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(291, 199);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 27;
            this.btnOK.Values.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(406, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // kryptonCheckBox1
            // 
            this.kryptonCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.提醒BindingSource, "已完成", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.kryptonCheckBox1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonCheckBox1.Location = new System.Drawing.Point(86, 107);
            this.kryptonCheckBox1.Name = "kryptonCheckBox1";
            this.kryptonCheckBox1.Size = new System.Drawing.Size(19, 13);
            this.kryptonCheckBox1.TabIndex = 30;
            this.kryptonCheckBox1.Values.Text = "";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.ReshowDelay = 10;
            this.toolTip1.ShowAlways = true;
            // 
            // 提醒Form
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 236);
            this.Controls.Add(this.kryptonCheckBox1);
            this.Controls.Add(this.BtnOkAndContinue);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.cmb源房);
            this.Controls.Add(this.cmb客房);
            this.Controls.Add(this.kryptonDateTimePicker3);
            this.Controls.Add(this.kryptonDateTimePicker2);
            this.Controls.Add(this.kryptonDateTimePicker1);
            this.Controls.Add(创建日期Label);
            this.Controls.Add(客房IDLabel);
            this.Controls.Add(事项Label);
            this.Controls.Add(提醒时间Label);
            this.Controls.Add(完成日期Label);
            this.Controls.Add(已完成Label);
            this.Controls.Add(源房IDLabel);
            this.Name = "提醒Form";
            this.Text = "自定义提醒";
            this.Load += new System.EventHandler(this.提醒Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.提醒BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb客房)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.客房BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb源房)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource 提醒BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb客房;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb源房;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnOkAndContinue;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private System.Windows.Forms.BindingSource 客房BindingSource;
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox kryptonCheckBox1;
        public System.Windows.Forms.ToolTip toolTip1;
    }
}