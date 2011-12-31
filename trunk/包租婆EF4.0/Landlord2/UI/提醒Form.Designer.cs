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
            this.kryptonComboBox1 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.客房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonDateTimePicker2 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonDateTimePicker3 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonComboBox2 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BtnOkAndContinue = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonCheckBox1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            创建日期Label = new System.Windows.Forms.Label();
            客房IDLabel = new System.Windows.Forms.Label();
            事项Label = new System.Windows.Forms.Label();
            提醒时间Label = new System.Windows.Forms.Label();
            完成日期Label = new System.Windows.Forms.Label();
            已完成Label = new System.Windows.Forms.Label();
            源房IDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.提醒BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.客房BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox2)).BeginInit();
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
            // kryptonComboBox1
            // 
            this.kryptonComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.提醒BindingSource, "客房ID", true));
            this.kryptonComboBox1.DataSource = this.客房BindingSource;
            this.kryptonComboBox1.DisplayMember = "命名";
            this.kryptonComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kryptonComboBox1.DropDownWidth = 134;
            this.kryptonComboBox1.Location = new System.Drawing.Point(345, 138);
            this.kryptonComboBox1.Name = "kryptonComboBox1";
            this.kryptonComboBox1.Size = new System.Drawing.Size(134, 21);
            this.kryptonComboBox1.TabIndex = 18;
            this.kryptonComboBox1.ValueMember = "ID";
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
            // 
            // kryptonDateTimePicker3
            // 
            this.kryptonDateTimePicker3.DataBindings.Add(new System.Windows.Forms.Binding("ValueNullable", this.提醒BindingSource, "完成日期", true));
            this.kryptonDateTimePicker3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.提醒BindingSource, "已完成", true));
            this.kryptonDateTimePicker3.Location = new System.Drawing.Point(345, 104);
            this.kryptonDateTimePicker3.Name = "kryptonDateTimePicker3";
            this.kryptonDateTimePicker3.Size = new System.Drawing.Size(134, 21);
            this.kryptonDateTimePicker3.TabIndex = 17;
            // 
            // kryptonComboBox2
            // 
            this.kryptonComboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.提醒BindingSource, "源房ID", true));
            this.kryptonComboBox2.DataSource = this.源房BindingSource;
            this.kryptonComboBox2.DisplayMember = "房名";
            this.kryptonComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kryptonComboBox2.DropDownWidth = 134;
            this.kryptonComboBox2.Location = new System.Drawing.Point(86, 138);
            this.kryptonComboBox2.Name = "kryptonComboBox2";
            this.kryptonComboBox2.Size = new System.Drawing.Size(134, 21);
            this.kryptonComboBox2.TabIndex = 18;
            this.kryptonComboBox2.ValueMember = "ID";
            this.kryptonComboBox2.SelectedIndexChanged += new System.EventHandler(this.kryptonComboBox2_SelectedIndexChanged);
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord2.Data.源房);
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
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(291, 199);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 27;
            this.btnOK.Values.Text = "保存";
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
            // 
            // kryptonCheckBox1
            // 
            this.kryptonCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.提醒BindingSource, "已完成", true));
            this.kryptonCheckBox1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonCheckBox1.Location = new System.Drawing.Point(86, 107);
            this.kryptonCheckBox1.Name = "kryptonCheckBox1";
            this.kryptonCheckBox1.Size = new System.Drawing.Size(19, 13);
            this.kryptonCheckBox1.TabIndex = 30;
            this.kryptonCheckBox1.Values.Text = "";
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
            this.Controls.Add(this.kryptonComboBox2);
            this.Controls.Add(this.kryptonComboBox1);
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
            this.Text = "提醒";
            this.Load += new System.EventHandler(this.提醒Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.提醒BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.客房BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource 提醒BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kryptonComboBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kryptonComboBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnOkAndContinue;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private System.Windows.Forms.BindingSource 客房BindingSource;
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox kryptonCheckBox1;
    }
}