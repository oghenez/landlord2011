namespace Landlord2.UI
{
    partial class 日常损耗Form
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
            System.Windows.Forms.Label 备注Label;
            System.Windows.Forms.Label 客房IDLabel;
            System.Windows.Forms.Label 项目Label;
            System.Windows.Forms.Label 源房IDLabel;
            System.Windows.Forms.Label 支出金额Label;
            System.Windows.Forms.Label 支出日期Label;
            this.日常损耗BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmb源房 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmb客房 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.客房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonNumericUpDown2 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonDateTimePicker1 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            备注Label = new System.Windows.Forms.Label();
            客房IDLabel = new System.Windows.Forms.Label();
            项目Label = new System.Windows.Forms.Label();
            源房IDLabel = new System.Windows.Forms.Label();
            支出金额Label = new System.Windows.Forms.Label();
            支出日期Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.日常损耗BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb源房)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb客房)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.客房BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // 备注Label
            // 
            备注Label.AutoSize = true;
            备注Label.Location = new System.Drawing.Point(21, 137);
            备注Label.Name = "备注Label";
            备注Label.Size = new System.Drawing.Size(59, 12);
            备注Label.TabIndex = 3;
            备注Label.Text = "备    注:";
            // 
            // 客房IDLabel
            // 
            客房IDLabel.AutoSize = true;
            客房IDLabel.Location = new System.Drawing.Point(264, 25);
            客房IDLabel.Name = "客房IDLabel";
            客房IDLabel.Size = new System.Drawing.Size(35, 12);
            客房IDLabel.TabIndex = 5;
            客房IDLabel.Text = "客房:";
            // 
            // 项目Label
            // 
            项目Label.AutoSize = true;
            项目Label.Location = new System.Drawing.Point(21, 60);
            项目Label.Name = "项目Label";
            项目Label.Size = new System.Drawing.Size(59, 12);
            项目Label.TabIndex = 7;
            项目Label.Text = "项    目:";
            // 
            // 源房IDLabel
            // 
            源房IDLabel.AutoSize = true;
            源房IDLabel.Location = new System.Drawing.Point(21, 25);
            源房IDLabel.Name = "源房IDLabel";
            源房IDLabel.Size = new System.Drawing.Size(59, 12);
            源房IDLabel.TabIndex = 9;
            源房IDLabel.Text = "源    房:";
            // 
            // 支出金额Label
            // 
            支出金额Label.AutoSize = true;
            支出金额Label.Location = new System.Drawing.Point(21, 95);
            支出金额Label.Name = "支出金额Label";
            支出金额Label.Size = new System.Drawing.Size(59, 12);
            支出金额Label.TabIndex = 11;
            支出金额Label.Text = "支出金额:";
            // 
            // 支出日期Label
            // 
            支出日期Label.AutoSize = true;
            支出日期Label.Location = new System.Drawing.Point(240, 95);
            支出日期Label.Name = "支出日期Label";
            支出日期Label.Size = new System.Drawing.Size(59, 12);
            支出日期Label.TabIndex = 13;
            支出日期Label.Text = "支出日期:";
            // 
            // 日常损耗BindingSource
            // 
            this.日常损耗BindingSource.DataSource = typeof(Landlord2.Data.日常损耗);
            // 
            // cmb源房
            // 
            this.cmb源房.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.日常损耗BindingSource, "源房ID", true));
            this.cmb源房.DataSource = this.源房BindingSource;
            this.cmb源房.DisplayMember = "房名";
            this.cmb源房.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb源房.DropDownWidth = 134;
            this.cmb源房.Location = new System.Drawing.Point(83, 21);
            this.cmb源房.Name = "cmb源房";
            this.cmb源房.Size = new System.Drawing.Size(134, 21);
            this.cmb源房.TabIndex = 2;
            this.cmb源房.ValueMember = "ID";
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord2.Data.源房);
            this.源房BindingSource.PositionChanged += new System.EventHandler(this.源房BindingSource_PositionChanged);
            // 
            // cmb客房
            // 
            this.cmb客房.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.日常损耗BindingSource, "客房ID", true));
            this.cmb客房.DataSource = this.客房BindingSource;
            this.cmb客房.DisplayMember = "命名";
            this.cmb客房.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb客房.DropDownWidth = 134;
            this.cmb客房.Location = new System.Drawing.Point(299, 21);
            this.cmb客房.Name = "cmb客房";
            this.cmb客房.Size = new System.Drawing.Size(110, 21);
            this.cmb客房.TabIndex = 3;
            this.cmb客房.ValueMember = "ID";
            // 
            // 客房BindingSource
            // 
            this.客房BindingSource.DataSource = typeof(Landlord2.Data.客房);
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.日常损耗BindingSource, "备注", true));
            this.kryptonTextBox1.Location = new System.Drawing.Point(83, 125);
            this.kryptonTextBox1.Multiline = true;
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(326, 36);
            this.kryptonTextBox1.TabIndex = 7;
            // 
            // kryptonTextBox2
            // 
            this.kryptonTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.日常损耗BindingSource, "项目", true));
            this.kryptonTextBox2.Location = new System.Drawing.Point(83, 56);
            this.kryptonTextBox2.Name = "kryptonTextBox2";
            this.kryptonTextBox2.Size = new System.Drawing.Size(326, 20);
            this.kryptonTextBox2.TabIndex = 4;
            // 
            // kryptonNumericUpDown2
            // 
            this.kryptonNumericUpDown2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.日常损耗BindingSource, "支出金额", true));
            this.kryptonNumericUpDown2.DecimalPlaces = 2;
            this.kryptonNumericUpDown2.Location = new System.Drawing.Point(83, 90);
            this.kryptonNumericUpDown2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.kryptonNumericUpDown2.Name = "kryptonNumericUpDown2";
            this.kryptonNumericUpDown2.Size = new System.Drawing.Size(134, 22);
            this.kryptonNumericUpDown2.TabIndex = 5;
            // 
            // kryptonDateTimePicker1
            // 
            this.kryptonDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.日常损耗BindingSource, "支出日期", true));
            this.kryptonDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.kryptonDateTimePicker1.Location = new System.Drawing.Point(299, 91);
            this.kryptonDateTimePicker1.Name = "kryptonDateTimePicker1";
            this.kryptonDateTimePicker1.Size = new System.Drawing.Size(110, 21);
            this.kryptonDateTimePicker1.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(216, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 0;
            this.btnOK.Values.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(331, 183);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // 日常损耗Form
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 220);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.kryptonTextBox2);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.cmb客房);
            this.Controls.Add(this.cmb源房);
            this.Controls.Add(备注Label);
            this.Controls.Add(客房IDLabel);
            this.Controls.Add(this.kryptonNumericUpDown2);
            this.Controls.Add(项目Label);
            this.Controls.Add(源房IDLabel);
            this.Controls.Add(支出金额Label);
            this.Controls.Add(支出日期Label);
            this.Controls.Add(this.kryptonDateTimePicker1);
            this.Name = "日常损耗Form";
            this.Text = "日常损耗";
            this.Load += new System.EventHandler(this.日常损耗Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.日常损耗BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb源房)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb客房)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.客房BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource 日常损耗BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb源房;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb客房;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown2;
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private System.Windows.Forms.BindingSource 客房BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
    }
}