namespace Landlord2.UI
{
    partial class 装修明细详情Form
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
            System.Windows.Forms.Label 日期Label;
            System.Windows.Forms.Label 项目名称Label;
            System.Windows.Forms.Label 规格Label;
            System.Windows.Forms.Label 数量Label;
            System.Windows.Forms.Label 单位Label;
            System.Windows.Forms.Label 单价Label;
            System.Windows.Forms.Label 购买地点Label;
            System.Windows.Forms.Label 备注Label;
            System.Windows.Forms.Label 装修分类Label;
            this.装修明细BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonComboBox1 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kryptonDateTimePicker1 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonComboBox2 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonNumericUpDown1 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonTextBox3 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonNumericUpDown2 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonTextBox4 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox5 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label5 = new System.Windows.Forms.Label();
            日期Label = new System.Windows.Forms.Label();
            项目名称Label = new System.Windows.Forms.Label();
            规格Label = new System.Windows.Forms.Label();
            数量Label = new System.Windows.Forms.Label();
            单位Label = new System.Windows.Forms.Label();
            单价Label = new System.Windows.Forms.Label();
            购买地点Label = new System.Windows.Forms.Label();
            备注Label = new System.Windows.Forms.Label();
            装修分类Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.装修明细BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // 装修明细BindingSource
            // 
            this.装修明细BindingSource.DataSource = typeof(Landlord2.Data.装修明细);
            // 
            // 日期Label
            // 
            日期Label.AutoSize = true;
            日期Label.Location = new System.Drawing.Point(18, 26);
            日期Label.Name = "日期Label";
            日期Label.Size = new System.Drawing.Size(35, 12);
            日期Label.TabIndex = 1;
            日期Label.Text = "日期:";
            // 
            // 项目名称Label
            // 
            项目名称Label.AutoSize = true;
            项目名称Label.Location = new System.Drawing.Point(18, 64);
            项目名称Label.Name = "项目名称Label";
            项目名称Label.Size = new System.Drawing.Size(35, 12);
            项目名称Label.TabIndex = 2;
            项目名称Label.Text = "款项:";
            // 
            // 规格Label
            // 
            规格Label.AutoSize = true;
            规格Label.Location = new System.Drawing.Point(179, 64);
            规格Label.Name = "规格Label";
            规格Label.Size = new System.Drawing.Size(35, 12);
            规格Label.TabIndex = 4;
            规格Label.Text = "规格:";
            // 
            // 数量Label
            // 
            数量Label.AutoSize = true;
            数量Label.Location = new System.Drawing.Point(32, 102);
            数量Label.Name = "数量Label";
            数量Label.Size = new System.Drawing.Size(35, 12);
            数量Label.TabIndex = 6;
            数量Label.Text = "数量:";
            // 
            // 单位Label
            // 
            单位Label.AutoSize = true;
            单位Label.Location = new System.Drawing.Point(208, 102);
            单位Label.Name = "单位Label";
            单位Label.Size = new System.Drawing.Size(35, 12);
            单位Label.TabIndex = 8;
            单位Label.Text = "单位:";
            // 
            // 单价Label
            // 
            单价Label.AutoSize = true;
            单价Label.Location = new System.Drawing.Point(32, 133);
            单价Label.Name = "单价Label";
            单价Label.Size = new System.Drawing.Size(35, 12);
            单价Label.TabIndex = 10;
            单价Label.Text = "单价:";
            // 
            // 购买地点Label
            // 
            购买地点Label.AutoSize = true;
            购买地点Label.Location = new System.Drawing.Point(220, 133);
            购买地点Label.Name = "购买地点Label";
            购买地点Label.Size = new System.Drawing.Size(59, 12);
            购买地点Label.TabIndex = 12;
            购买地点Label.Text = "购买地点:";
            // 
            // 备注Label
            // 
            备注Label.AutoSize = true;
            备注Label.Location = new System.Drawing.Point(32, 173);
            备注Label.Name = "备注Label";
            备注Label.Size = new System.Drawing.Size(35, 12);
            备注Label.TabIndex = 14;
            备注Label.Text = "备注:";
            // 
            // kryptonComboBox1
            // 
            this.kryptonComboBox1.DropDownWidth = 121;
            this.kryptonComboBox1.Location = new System.Drawing.Point(220, 22);
            this.kryptonComboBox1.Name = "kryptonComboBox1";
            this.kryptonComboBox1.Size = new System.Drawing.Size(136, 21);
            this.kryptonComboBox1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(179, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "源房:";
            // 
            // kryptonDateTimePicker1
            // 
            this.kryptonDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.装修明细BindingSource, "日期", true));
            this.kryptonDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.kryptonDateTimePicker1.Location = new System.Drawing.Point(59, 22);
            this.kryptonDateTimePicker1.Name = "kryptonDateTimePicker1";
            this.kryptonDateTimePicker1.Size = new System.Drawing.Size(94, 21);
            this.kryptonDateTimePicker1.TabIndex = 18;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(59, 60);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(94, 20);
            this.kryptonTextBox1.TabIndex = 19;
            // 
            // 装修分类Label
            // 
            装修分类Label.AutoSize = true;
            装修分类Label.Location = new System.Drawing.Point(384, 26);
            装修分类Label.Name = "装修分类Label";
            装修分类Label.Size = new System.Drawing.Size(59, 12);
            装修分类Label.TabIndex = 19;
            装修分类Label.Text = "装修分类:";
            // 
            // kryptonComboBox2
            // 
            this.kryptonComboBox2.DropDownWidth = 121;
            this.kryptonComboBox2.Location = new System.Drawing.Point(449, 22);
            this.kryptonComboBox2.Name = "kryptonComboBox2";
            this.kryptonComboBox2.Size = new System.Drawing.Size(90, 21);
            this.kryptonComboBox2.TabIndex = 21;
            // 
            // kryptonTextBox2
            // 
            this.kryptonTextBox2.Location = new System.Drawing.Point(220, 60);
            this.kryptonTextBox2.Name = "kryptonTextBox2";
            this.kryptonTextBox2.Size = new System.Drawing.Size(100, 20);
            this.kryptonTextBox2.TabIndex = 19;
            // 
            // kryptonNumericUpDown1
            // 
            this.kryptonNumericUpDown1.Location = new System.Drawing.Point(73, 99);
            this.kryptonNumericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.kryptonNumericUpDown1.Name = "kryptonNumericUpDown1";
            this.kryptonNumericUpDown1.Size = new System.Drawing.Size(65, 22);
            this.kryptonNumericUpDown1.TabIndex = 22;
            // 
            // kryptonTextBox3
            // 
            this.kryptonTextBox3.Location = new System.Drawing.Point(263, 101);
            this.kryptonTextBox3.Name = "kryptonTextBox3";
            this.kryptonTextBox3.Size = new System.Drawing.Size(100, 20);
            this.kryptonTextBox3.TabIndex = 19;
            // 
            // kryptonNumericUpDown2
            // 
            this.kryptonNumericUpDown2.Location = new System.Drawing.Point(73, 127);
            this.kryptonNumericUpDown2.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.kryptonNumericUpDown2.Name = "kryptonNumericUpDown2";
            this.kryptonNumericUpDown2.Size = new System.Drawing.Size(65, 22);
            this.kryptonNumericUpDown2.TabIndex = 22;
            // 
            // kryptonTextBox4
            // 
            this.kryptonTextBox4.Location = new System.Drawing.Point(285, 130);
            this.kryptonTextBox4.Name = "kryptonTextBox4";
            this.kryptonTextBox4.Size = new System.Drawing.Size(206, 20);
            this.kryptonTextBox4.TabIndex = 19;
            // 
            // kryptonTextBox5
            // 
            this.kryptonTextBox5.Location = new System.Drawing.Point(89, 170);
            this.kryptonTextBox5.Name = "kryptonTextBox5";
            this.kryptonTextBox5.Size = new System.Drawing.Size(307, 20);
            this.kryptonTextBox5.TabIndex = 19;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(386, 288);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 23;
            this.btnOK.Values.Text = "保存";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(507, 288);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Values.Text = "取消";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(384, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "款项金额(单价×数量)：";
            // 
            // 装修明细详情Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 325);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.kryptonNumericUpDown2);
            this.Controls.Add(this.kryptonNumericUpDown1);
            this.Controls.Add(this.kryptonComboBox2);
            this.Controls.Add(装修分类Label);
            this.Controls.Add(this.kryptonTextBox5);
            this.Controls.Add(this.kryptonTextBox4);
            this.Controls.Add(this.kryptonTextBox3);
            this.Controls.Add(this.kryptonTextBox2);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.kryptonDateTimePicker1);
            this.Controls.Add(this.kryptonComboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(备注Label);
            this.Controls.Add(购买地点Label);
            this.Controls.Add(单价Label);
            this.Controls.Add(单位Label);
            this.Controls.Add(数量Label);
            this.Controls.Add(规格Label);
            this.Controls.Add(项目名称Label);
            this.Controls.Add(日期Label);
            this.Name = "装修明细详情Form";
            this.Text = "装修明细详情";
            this.Load += new System.EventHandler(this.装修明细详情Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.装修明细BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource 装修明细BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kryptonComboBox1;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kryptonComboBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox3;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private System.Windows.Forms.Label label5;
    }
}