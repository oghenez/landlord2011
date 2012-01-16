namespace Landlord2.UI
{
    partial class 源房抄表Form
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
            System.Windows.Forms.Label 源房IDLabel;
            System.Windows.Forms.Label 抄表时间Label;
            System.Windows.Forms.Label 备注Label;
            System.Windows.Forms.Label 抄表人Label;
            System.Windows.Forms.Label 电账户余额Label;
            System.Windows.Forms.Label 电止码Label;
            System.Windows.Forms.Label 水止码Label;
            System.Windows.Forms.Label 水账户余额Label;
            System.Windows.Forms.Label 气表剩余字数Label;
            this.源房抄表BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonComboBox1 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonDateTimePicker1 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.nud水止码 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.nud电止码 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.nud气止码 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox3 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox4 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            源房IDLabel = new System.Windows.Forms.Label();
            抄表时间Label = new System.Windows.Forms.Label();
            备注Label = new System.Windows.Forms.Label();
            抄表人Label = new System.Windows.Forms.Label();
            电账户余额Label = new System.Windows.Forms.Label();
            电止码Label = new System.Windows.Forms.Label();
            水止码Label = new System.Windows.Forms.Label();
            水账户余额Label = new System.Windows.Forms.Label();
            气表剩余字数Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.源房抄表BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // 源房IDLabel
            // 
            源房IDLabel.AutoSize = true;
            源房IDLabel.Location = new System.Drawing.Point(21, 25);
            源房IDLabel.Name = "源房IDLabel";
            源房IDLabel.Size = new System.Drawing.Size(35, 12);
            源房IDLabel.TabIndex = 0;
            源房IDLabel.Text = "源房:";
            // 
            // 抄表时间Label
            // 
            抄表时间Label.AutoSize = true;
            抄表时间Label.Location = new System.Drawing.Point(192, 60);
            抄表时间Label.Name = "抄表时间Label";
            抄表时间Label.Size = new System.Drawing.Size(59, 12);
            抄表时间Label.TabIndex = 2;
            抄表时间Label.Text = "抄表时间:";
            // 
            // 备注Label
            // 
            备注Label.AutoSize = true;
            备注Label.Location = new System.Drawing.Point(32, 200);
            备注Label.Name = "备注Label";
            备注Label.Size = new System.Drawing.Size(35, 12);
            备注Label.TabIndex = 4;
            备注Label.Text = "备注:";
            // 
            // 抄表人Label
            // 
            抄表人Label.AutoSize = true;
            抄表人Label.Location = new System.Drawing.Point(21, 60);
            抄表人Label.Name = "抄表人Label";
            抄表人Label.Size = new System.Drawing.Size(47, 12);
            抄表人Label.TabIndex = 6;
            抄表人Label.Text = "抄表人:";
            // 
            // 电账户余额Label
            // 
            电账户余额Label.AutoSize = true;
            电账户余额Label.Location = new System.Drawing.Point(192, 130);
            电账户余额Label.Name = "电账户余额Label";
            电账户余额Label.Size = new System.Drawing.Size(71, 12);
            电账户余额Label.TabIndex = 8;
            电账户余额Label.Text = "电账户余额:";
            this.toolTip1.SetToolTip(电账户余额Label, "请保证其准确性。如不清楚可不填，系统将自动推算。");
            // 
            // 电止码Label
            // 
            电止码Label.AutoSize = true;
            电止码Label.Location = new System.Drawing.Point(21, 130);
            电止码Label.Name = "电止码Label";
            电止码Label.Size = new System.Drawing.Size(47, 12);
            电止码Label.TabIndex = 10;
            电止码Label.Text = "电止码:";
            // 
            // 水止码Label
            // 
            水止码Label.AutoSize = true;
            水止码Label.Location = new System.Drawing.Point(21, 95);
            水止码Label.Name = "水止码Label";
            水止码Label.Size = new System.Drawing.Size(47, 12);
            水止码Label.TabIndex = 12;
            水止码Label.Text = "水止码:";
            // 
            // 水账户余额Label
            // 
            水账户余额Label.AutoSize = true;
            水账户余额Label.Location = new System.Drawing.Point(192, 95);
            水账户余额Label.Name = "水账户余额Label";
            水账户余额Label.Size = new System.Drawing.Size(71, 12);
            水账户余额Label.TabIndex = 14;
            水账户余额Label.Text = "水账户余额:";
            this.toolTip1.SetToolTip(水账户余额Label, "请保证其准确性。如不清楚可不填，系统将自动推算。");
            // 
            // 气表剩余字数Label
            // 
            气表剩余字数Label.AutoSize = true;
            气表剩余字数Label.Location = new System.Drawing.Point(21, 165);
            气表剩余字数Label.Name = "气表剩余字数Label";
            气表剩余字数Label.Size = new System.Drawing.Size(47, 12);
            气表剩余字数Label.TabIndex = 16;
            气表剩余字数Label.Text = "气止码:";
            this.toolTip1.SetToolTip(气表剩余字数Label, "气表剩余字数");
            // 
            // 源房抄表BindingSource
            // 
            this.源房抄表BindingSource.DataSource = typeof(Landlord2.Data.源房抄表);
            // 
            // kryptonComboBox1
            // 
            this.kryptonComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.源房抄表BindingSource, "源房ID", true));
            this.kryptonComboBox1.DataSource = this.源房BindingSource;
            this.kryptonComboBox1.DisplayMember = "房名";
            this.kryptonComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kryptonComboBox1.DropDownWidth = 121;
            this.kryptonComboBox1.Location = new System.Drawing.Point(74, 21);
            this.kryptonComboBox1.Name = "kryptonComboBox1";
            this.kryptonComboBox1.Size = new System.Drawing.Size(269, 21);
            this.kryptonComboBox1.TabIndex = 1;
            this.kryptonComboBox1.ValueMember = "ID";
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord2.Data.源房);
            // 
            // kryptonDateTimePicker1
            // 
            this.kryptonDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.源房抄表BindingSource, "抄表时间", true));
            this.kryptonDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.kryptonDateTimePicker1.Location = new System.Drawing.Point(249, 56);
            this.kryptonDateTimePicker1.Name = "kryptonDateTimePicker1";
            this.kryptonDateTimePicker1.Size = new System.Drawing.Size(94, 21);
            this.kryptonDateTimePicker1.TabIndex = 4;
            // 
            // nud水止码
            // 
            this.nud水止码.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.源房抄表BindingSource, "水止码", true));
            this.nud水止码.DecimalPlaces = 1;
            this.nud水止码.Location = new System.Drawing.Point(74, 90);
            this.nud水止码.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nud水止码.Name = "nud水止码";
            this.nud水止码.Size = new System.Drawing.Size(74, 22);
            this.nud水止码.TabIndex = 18;
            // 
            // nud电止码
            // 
            this.nud电止码.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.源房抄表BindingSource, "电止码", true));
            this.nud电止码.DecimalPlaces = 1;
            this.nud电止码.Location = new System.Drawing.Point(74, 125);
            this.nud电止码.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nud电止码.Name = "nud电止码";
            this.nud电止码.Size = new System.Drawing.Size(74, 22);
            this.nud电止码.TabIndex = 19;
            // 
            // nud气止码
            // 
            this.nud气止码.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.源房抄表BindingSource, "气表剩余字数", true));
            this.nud气止码.DecimalPlaces = 1;
            this.nud气止码.Location = new System.Drawing.Point(76, 160);
            this.nud气止码.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nud气止码.Name = "nud气止码";
            this.nud气止码.Size = new System.Drawing.Size(74, 22);
            this.nud气止码.TabIndex = 20;
            this.toolTip1.SetToolTip(this.nud气止码, "气表剩余字数");
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.源房抄表BindingSource, "水账户余额", true));
            this.kryptonTextBox1.Location = new System.Drawing.Point(269, 91);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(74, 20);
            this.kryptonTextBox1.TabIndex = 4;
            this.toolTip1.SetToolTip(this.kryptonTextBox1, "请保证其准确性。如不清楚可不填，系统将自动推算。");
            // 
            // kryptonTextBox2
            // 
            this.kryptonTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.源房抄表BindingSource, "电账户余额", true));
            this.kryptonTextBox2.Location = new System.Drawing.Point(269, 126);
            this.kryptonTextBox2.Name = "kryptonTextBox2";
            this.kryptonTextBox2.Size = new System.Drawing.Size(74, 20);
            this.kryptonTextBox2.TabIndex = 4;
            this.toolTip1.SetToolTip(this.kryptonTextBox2, "请保证其准确性。如不清楚可不填，系统将自动推算。");
            // 
            // kryptonTextBox3
            // 
            this.kryptonTextBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.源房抄表BindingSource, "备注", true));
            this.kryptonTextBox3.Location = new System.Drawing.Point(76, 194);
            this.kryptonTextBox3.Multiline = true;
            this.kryptonTextBox3.Name = "kryptonTextBox3";
            this.kryptonTextBox3.Size = new System.Drawing.Size(267, 43);
            this.kryptonTextBox3.TabIndex = 4;
            // 
            // kryptonTextBox4
            // 
            this.kryptonTextBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.源房抄表BindingSource, "抄表人", true));
            this.kryptonTextBox4.Location = new System.Drawing.Point(74, 56);
            this.kryptonTextBox4.Name = "kryptonTextBox4";
            this.kryptonTextBox4.Size = new System.Drawing.Size(74, 20);
            this.kryptonTextBox4.TabIndex = 4;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 10;
            this.toolTip1.ShowAlways = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(82, 259);
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
            this.btnCancel.Location = new System.Drawing.Point(197, 259);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.源房抄表BindingSource;
            // 
            // 源房抄表Form
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(368, 296);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.nud水止码);
            this.Controls.Add(this.nud电止码);
            this.Controls.Add(this.nud气止码);
            this.Controls.Add(气表剩余字数Label);
            this.Controls.Add(水账户余额Label);
            this.Controls.Add(水止码Label);
            this.Controls.Add(电止码Label);
            this.Controls.Add(电账户余额Label);
            this.Controls.Add(抄表人Label);
            this.Controls.Add(备注Label);
            this.Controls.Add(this.kryptonDateTimePicker1);
            this.Controls.Add(抄表时间Label);
            this.Controls.Add(this.kryptonTextBox2);
            this.Controls.Add(this.kryptonTextBox4);
            this.Controls.Add(this.kryptonTextBox3);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.kryptonComboBox1);
            this.Controls.Add(源房IDLabel);
            this.Name = "源房抄表Form";
            this.Text = "源房抄表";
            this.Load += new System.EventHandler(this.源房抄表Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.源房抄表BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource 源房抄表BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox kryptonComboBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker1;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nud水止码;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nud电止码;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown nud气止码;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox4;
        private System.Windows.Forms.ToolTip toolTip1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}