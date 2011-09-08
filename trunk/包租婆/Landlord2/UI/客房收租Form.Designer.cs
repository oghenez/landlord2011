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
            System.Windows.Forms.Label 起付日期Label;
            System.Windows.Forms.Label 付款日期Label;
            System.Windows.Forms.Label 止付日期Label;
            System.Windows.Forms.Label 水止码Label;
            System.Windows.Forms.Label 电止码Label;
            System.Windows.Forms.Label 气止码Label;
            System.Windows.Forms.Label 应付金额Label;
            System.Windows.Forms.Label 实付金额Label;
            System.Windows.Forms.Label 付款人Label;
            System.Windows.Forms.Label 收款人Label;
            System.Windows.Forms.Label 备注Label;
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.BtnSelectKF = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.客房租金明细BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kryptonDateTimePicker1 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonDateTimePicker2 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonDateTimePicker3 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonNumericUpDown1 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown2 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown3 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown4 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown5 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox3 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            起付日期Label = new System.Windows.Forms.Label();
            付款日期Label = new System.Windows.Forms.Label();
            止付日期Label = new System.Windows.Forms.Label();
            水止码Label = new System.Windows.Forms.Label();
            电止码Label = new System.Windows.Forms.Label();
            气止码Label = new System.Windows.Forms.Label();
            应付金额Label = new System.Windows.Forms.Label();
            实付金额Label = new System.Windows.Forms.Label();
            付款人Label = new System.Windows.Forms.Label();
            收款人Label = new System.Windows.Forms.Label();
            备注Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.客房租金明细BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.BtnSelectKF);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlToolTip;
            this.kryptonPanel1.Size = new System.Drawing.Size(633, 40);
            this.kryptonPanel1.TabIndex = 4;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel1.Location = new System.Drawing.Point(5, 5);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(185, 30);
            this.kryptonLabel1.StateNormal.LongText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kryptonLabel1.StateNormal.LongText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.ExtraText = "客房";
            this.kryptonLabel1.Values.Text = "当前选择的源房";
            // 
            // BtnSelectKF
            // 
            this.BtnSelectKF.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSelectKF.Location = new System.Drawing.Point(497, 5);
            this.BtnSelectKF.Name = "BtnSelectKF";
            this.BtnSelectKF.Size = new System.Drawing.Size(131, 30);
            this.BtnSelectKF.TabIndex = 0;
            this.BtnSelectKF.Values.Text = "选择其他客房";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(497, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Values.Text = "取消";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(366, 401);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 5;
            this.btnOK.Values.Text = "保存";
            // 
            // 客房租金明细BindingSource
            // 
            this.客房租金明细BindingSource.DataSource = typeof(Landlord2.Data.客房租金明细);
            // 
            // 起付日期Label
            // 
            起付日期Label.AutoSize = true;
            起付日期Label.Location = new System.Drawing.Point(23, 71);
            起付日期Label.Name = "起付日期Label";
            起付日期Label.Size = new System.Drawing.Size(59, 12);
            起付日期Label.TabIndex = 6;
            起付日期Label.Text = "起付日期:";
            // 
            // kryptonDateTimePicker1
            // 
            this.kryptonDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.客房租金明细BindingSource, "起付日期", true));
            this.kryptonDateTimePicker1.Location = new System.Drawing.Point(88, 62);
            this.kryptonDateTimePicker1.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.kryptonDateTimePicker1.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.kryptonDateTimePicker1.Name = "kryptonDateTimePicker1";
            this.kryptonDateTimePicker1.Size = new System.Drawing.Size(115, 21);
            this.kryptonDateTimePicker1.TabIndex = 7;
            // 
            // 付款日期Label
            // 
            付款日期Label.AutoSize = true;
            付款日期Label.Location = new System.Drawing.Point(23, 166);
            付款日期Label.Name = "付款日期Label";
            付款日期Label.Size = new System.Drawing.Size(59, 12);
            付款日期Label.TabIndex = 7;
            付款日期Label.Text = "付款日期:";
            // 
            // kryptonDateTimePicker2
            // 
            this.kryptonDateTimePicker2.Location = new System.Drawing.Point(88, 157);
            this.kryptonDateTimePicker2.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.kryptonDateTimePicker2.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.kryptonDateTimePicker2.Name = "kryptonDateTimePicker2";
            this.kryptonDateTimePicker2.Size = new System.Drawing.Size(115, 21);
            this.kryptonDateTimePicker2.TabIndex = 7;
            // 
            // 止付日期Label
            // 
            止付日期Label.AutoSize = true;
            止付日期Label.Location = new System.Drawing.Point(37, 118);
            止付日期Label.Name = "止付日期Label";
            止付日期Label.Size = new System.Drawing.Size(59, 12);
            止付日期Label.TabIndex = 7;
            止付日期Label.Text = "止付日期:";
            // 
            // kryptonDateTimePicker3
            // 
            this.kryptonDateTimePicker3.Location = new System.Drawing.Point(102, 109);
            this.kryptonDateTimePicker3.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.kryptonDateTimePicker3.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.kryptonDateTimePicker3.Name = "kryptonDateTimePicker3";
            this.kryptonDateTimePicker3.Size = new System.Drawing.Size(115, 21);
            this.kryptonDateTimePicker3.TabIndex = 7;
            // 
            // 水止码Label
            // 
            水止码Label.AutoSize = true;
            水止码Label.Location = new System.Drawing.Point(442, 105);
            水止码Label.Name = "水止码Label";
            水止码Label.Size = new System.Drawing.Size(47, 12);
            水止码Label.TabIndex = 9;
            水止码Label.Text = "水止码:";
            // 
            // kryptonNumericUpDown1
            // 
            this.kryptonNumericUpDown1.Location = new System.Drawing.Point(493, 95);
            this.kryptonNumericUpDown1.Name = "kryptonNumericUpDown1";
            this.kryptonNumericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.kryptonNumericUpDown1.TabIndex = 10;
            // 
            // 电止码Label
            // 
            电止码Label.AutoSize = true;
            电止码Label.Location = new System.Drawing.Point(442, 134);
            电止码Label.Name = "电止码Label";
            电止码Label.Size = new System.Drawing.Size(47, 12);
            电止码Label.TabIndex = 11;
            电止码Label.Text = "电止码:";
            // 
            // kryptonNumericUpDown2
            // 
            this.kryptonNumericUpDown2.Location = new System.Drawing.Point(493, 124);
            this.kryptonNumericUpDown2.Name = "kryptonNumericUpDown2";
            this.kryptonNumericUpDown2.Size = new System.Drawing.Size(120, 22);
            this.kryptonNumericUpDown2.TabIndex = 10;
            // 
            // 气止码Label
            // 
            气止码Label.AutoSize = true;
            气止码Label.Location = new System.Drawing.Point(442, 160);
            气止码Label.Name = "气止码Label";
            气止码Label.Size = new System.Drawing.Size(47, 12);
            气止码Label.TabIndex = 13;
            气止码Label.Text = "气止码:";
            // 
            // kryptonNumericUpDown3
            // 
            this.kryptonNumericUpDown3.DecimalPlaces = 1;
            this.kryptonNumericUpDown3.Location = new System.Drawing.Point(493, 152);
            this.kryptonNumericUpDown3.Name = "kryptonNumericUpDown3";
            this.kryptonNumericUpDown3.Size = new System.Drawing.Size(120, 22);
            this.kryptonNumericUpDown3.TabIndex = 10;
            // 
            // 应付金额Label
            // 
            应付金额Label.AutoSize = true;
            应付金额Label.Location = new System.Drawing.Point(37, 220);
            应付金额Label.Name = "应付金额Label";
            应付金额Label.Size = new System.Drawing.Size(59, 12);
            应付金额Label.TabIndex = 15;
            应付金额Label.Text = "应付金额:";
            // 
            // kryptonNumericUpDown4
            // 
            this.kryptonNumericUpDown4.DecimalPlaces = 2;
            this.kryptonNumericUpDown4.Location = new System.Drawing.Point(102, 210);
            this.kryptonNumericUpDown4.Name = "kryptonNumericUpDown4";
            this.kryptonNumericUpDown4.Size = new System.Drawing.Size(120, 22);
            this.kryptonNumericUpDown4.TabIndex = 10;
            this.kryptonNumericUpDown4.ThousandsSeparator = true;
            // 
            // 实付金额Label
            // 
            实付金额Label.AutoSize = true;
            实付金额Label.Location = new System.Drawing.Point(37, 248);
            实付金额Label.Name = "实付金额Label";
            实付金额Label.Size = new System.Drawing.Size(59, 12);
            实付金额Label.TabIndex = 17;
            实付金额Label.Text = "实付金额:";
            // 
            // kryptonNumericUpDown5
            // 
            this.kryptonNumericUpDown5.DecimalPlaces = 2;
            this.kryptonNumericUpDown5.Location = new System.Drawing.Point(102, 238);
            this.kryptonNumericUpDown5.Name = "kryptonNumericUpDown5";
            this.kryptonNumericUpDown5.Size = new System.Drawing.Size(120, 22);
            this.kryptonNumericUpDown5.TabIndex = 10;
            this.kryptonNumericUpDown5.ThousandsSeparator = true;
            // 
            // 付款人Label
            // 
            付款人Label.AutoSize = true;
            付款人Label.Location = new System.Drawing.Point(299, 219);
            付款人Label.Name = "付款人Label";
            付款人Label.Size = new System.Drawing.Size(47, 12);
            付款人Label.TabIndex = 19;
            付款人Label.Text = "付款人:";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(364, 212);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(100, 20);
            this.kryptonTextBox1.TabIndex = 20;
            // 
            // 收款人Label
            // 
            收款人Label.AutoSize = true;
            收款人Label.Location = new System.Drawing.Point(299, 248);
            收款人Label.Name = "收款人Label";
            收款人Label.Size = new System.Drawing.Size(47, 12);
            收款人Label.TabIndex = 21;
            收款人Label.Text = "收款人:";
            // 
            // kryptonTextBox2
            // 
            this.kryptonTextBox2.Location = new System.Drawing.Point(364, 240);
            this.kryptonTextBox2.Name = "kryptonTextBox2";
            this.kryptonTextBox2.Size = new System.Drawing.Size(100, 20);
            this.kryptonTextBox2.TabIndex = 20;
            // 
            // 备注Label
            // 
            备注Label.AutoSize = true;
            备注Label.Location = new System.Drawing.Point(289, 283);
            备注Label.Name = "备注Label";
            备注Label.Size = new System.Drawing.Size(35, 12);
            备注Label.TabIndex = 23;
            备注Label.Text = "备注:";
            // 
            // kryptonTextBox3
            // 
            this.kryptonTextBox3.Location = new System.Drawing.Point(330, 275);
            this.kryptonTextBox3.Name = "kryptonTextBox3";
            this.kryptonTextBox3.Size = new System.Drawing.Size(100, 20);
            this.kryptonTextBox3.TabIndex = 20;
            // 
            // 客房收租Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(633, 438);
            this.Controls.Add(备注Label);
            this.Controls.Add(收款人Label);
            this.Controls.Add(this.kryptonTextBox3);
            this.Controls.Add(this.kryptonTextBox2);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(付款人Label);
            this.Controls.Add(实付金额Label);
            this.Controls.Add(应付金额Label);
            this.Controls.Add(气止码Label);
            this.Controls.Add(电止码Label);
            this.Controls.Add(this.kryptonNumericUpDown5);
            this.Controls.Add(this.kryptonNumericUpDown4);
            this.Controls.Add(this.kryptonNumericUpDown3);
            this.Controls.Add(this.kryptonNumericUpDown2);
            this.Controls.Add(this.kryptonNumericUpDown1);
            this.Controls.Add(水止码Label);
            this.Controls.Add(止付日期Label);
            this.Controls.Add(付款日期Label);
            this.Controls.Add(this.kryptonDateTimePicker2);
            this.Controls.Add(this.kryptonDateTimePicker3);
            this.Controls.Add(this.kryptonDateTimePicker1);
            this.Controls.Add(起付日期Label);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "客房收租Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "客房收租";
            this.Load += new System.EventHandler(this.客房收租Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.客房租金明细BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnSelectKF;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private System.Windows.Forms.BindingSource 客房租金明细BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker3;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown1;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown2;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown3;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown4;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox3;
    }
}