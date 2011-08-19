namespace Landlord2.UI
{
    partial class 阶梯水价Form
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
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLinkLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.raBtnUse = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.raBtnNoUse = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonNumericUpDown1 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kryptonNumericUpDown21 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown11 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown30 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown20 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown10 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown3 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonNumericUpDown2 = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDefault = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonLinkLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlToolTip;
            this.kryptonPanel1.Size = new System.Drawing.Size(385, 106);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonLinkLabel1
            // 
            this.kryptonLinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kryptonLinkLabel1.Location = new System.Drawing.Point(220, 8);
            this.kryptonLinkLabel1.Name = "kryptonLinkLabel1";
            this.kryptonLinkLabel1.Size = new System.Drawing.Size(152, 20);
            this.kryptonLinkLabel1.TabIndex = 1;
            this.kryptonLinkLabel1.Values.Text = "<武汉市城市供水价格表>";
            this.kryptonLinkLabel1.LinkClicked += new System.EventHandler(this.kryptonLinkLabel1_LinkClicked);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AutoSize = false;
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.kryptonLabel1.Location = new System.Drawing.Point(5, 5);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(375, 96);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.ExtraText = "举例：“1.90,0,25;2.45,25,33;3.00,33\" ，格式说明如下：\r\n1.90元/吨，  0<用水量≤25吨；\r\n2.45元/吨，25<用水量≤" +
    "33吨；\r\n3.00元/吨，33吨以上。\r\n";
            this.kryptonLabel1.Values.Image = global::Landlord2.Properties.Resources.info;
            this.kryptonLabel1.Values.Text = "武汉市2006年5月1日实施阶梯水价";
            // 
            // raBtnUse
            // 
            this.raBtnUse.Checked = true;
            this.raBtnUse.Location = new System.Drawing.Point(60, 118);
            this.raBtnUse.Name = "raBtnUse";
            this.raBtnUse.Size = new System.Drawing.Size(97, 20);
            this.raBtnUse.TabIndex = 0;
            this.raBtnUse.Values.Text = "使用阶梯水价";
            this.raBtnUse.CheckedChanged += new System.EventHandler(this.kryptonRadioButton_CheckedChanged);
            // 
            // raBtnNoUse
            // 
            this.raBtnNoUse.Location = new System.Drawing.Point(215, 118);
            this.raBtnNoUse.Name = "raBtnNoUse";
            this.raBtnNoUse.Size = new System.Drawing.Size(110, 20);
            this.raBtnNoUse.TabIndex = 1;
            this.raBtnNoUse.Values.Text = "不使用阶梯水价";
            this.raBtnNoUse.CheckedChanged += new System.EventHandler(this.kryptonRadioButton_CheckedChanged);
            // 
            // kryptonNumericUpDown1
            // 
            this.kryptonNumericUpDown1.DecimalPlaces = 2;
            this.kryptonNumericUpDown1.Location = new System.Drawing.Point(14, 22);
            this.kryptonNumericUpDown1.Name = "kryptonNumericUpDown1";
            this.kryptonNumericUpDown1.Size = new System.Drawing.Size(55, 22);
            this.kryptonNumericUpDown1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "元/吨";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kryptonNumericUpDown21);
            this.groupBox1.Controls.Add(this.kryptonNumericUpDown11);
            this.groupBox1.Controls.Add(this.kryptonNumericUpDown30);
            this.groupBox1.Controls.Add(this.kryptonNumericUpDown20);
            this.groupBox1.Controls.Add(this.kryptonNumericUpDown10);
            this.groupBox1.Controls.Add(this.kryptonNumericUpDown3);
            this.groupBox1.Controls.Add(this.kryptonNumericUpDown2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.kryptonNumericUpDown1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 136);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // kryptonNumericUpDown21
            // 
            this.kryptonNumericUpDown21.Location = new System.Drawing.Point(268, 63);
            this.kryptonNumericUpDown21.Name = "kryptonNumericUpDown21";
            this.kryptonNumericUpDown21.Size = new System.Drawing.Size(55, 22);
            this.kryptonNumericUpDown21.TabIndex = 5;
            // 
            // kryptonNumericUpDown11
            // 
            this.kryptonNumericUpDown11.Location = new System.Drawing.Point(268, 22);
            this.kryptonNumericUpDown11.Name = "kryptonNumericUpDown11";
            this.kryptonNumericUpDown11.Size = new System.Drawing.Size(55, 22);
            this.kryptonNumericUpDown11.TabIndex = 2;
            // 
            // kryptonNumericUpDown30
            // 
            this.kryptonNumericUpDown30.Location = new System.Drawing.Point(130, 102);
            this.kryptonNumericUpDown30.Name = "kryptonNumericUpDown30";
            this.kryptonNumericUpDown30.Size = new System.Drawing.Size(55, 22);
            this.kryptonNumericUpDown30.TabIndex = 7;
            // 
            // kryptonNumericUpDown20
            // 
            this.kryptonNumericUpDown20.Location = new System.Drawing.Point(130, 63);
            this.kryptonNumericUpDown20.Name = "kryptonNumericUpDown20";
            this.kryptonNumericUpDown20.Size = new System.Drawing.Size(55, 22);
            this.kryptonNumericUpDown20.TabIndex = 4;
            // 
            // kryptonNumericUpDown10
            // 
            this.kryptonNumericUpDown10.Location = new System.Drawing.Point(130, 22);
            this.kryptonNumericUpDown10.Name = "kryptonNumericUpDown10";
            this.kryptonNumericUpDown10.Size = new System.Drawing.Size(55, 22);
            this.kryptonNumericUpDown10.TabIndex = 1;
            // 
            // kryptonNumericUpDown3
            // 
            this.kryptonNumericUpDown3.DecimalPlaces = 2;
            this.kryptonNumericUpDown3.Location = new System.Drawing.Point(14, 102);
            this.kryptonNumericUpDown3.Name = "kryptonNumericUpDown3";
            this.kryptonNumericUpDown3.Size = new System.Drawing.Size(55, 22);
            this.kryptonNumericUpDown3.TabIndex = 6;
            // 
            // kryptonNumericUpDown2
            // 
            this.kryptonNumericUpDown2.DecimalPlaces = 2;
            this.kryptonNumericUpDown2.Location = new System.Drawing.Point(14, 63);
            this.kryptonNumericUpDown2.Name = "kryptonNumericUpDown2";
            this.kryptonNumericUpDown2.Size = new System.Drawing.Size(55, 22);
            this.kryptonNumericUpDown2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "吨";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(191, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "< 用水量";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "< 用水量 ≤";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "元/吨";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "吨";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "元/吨";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "< 用水量 ≤";
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(12, 305);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(90, 25);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Values.Text = "恢复默认值";
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(166, 305);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Values.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(280, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // 阶梯水价Form
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(385, 351);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.raBtnNoUse);
            this.Controls.Add(this.raBtnUse);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "阶梯水价Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "阶梯水价";
            this.Load += new System.EventHandler(this.阶梯水价Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton raBtnUse;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton raBtnNoUse;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown21;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown11;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown30;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown20;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown10;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown3;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown kryptonNumericUpDown2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDefault;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
    }
}