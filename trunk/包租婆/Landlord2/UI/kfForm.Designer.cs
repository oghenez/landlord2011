namespace Landlord2.UI
{
    partial class kfForm
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
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbYF = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BtnOkAndContinue = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.uC客房详细1 = new Landlord2.UI.UC客房详细();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(684, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(554, 265);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Values.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(20, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "隶属源房：";
            // 
            // cmbYF
            // 
            this.cmbYF.DataSource = this.源房BindingSource;
            this.cmbYF.DisplayMember = "房名";
            this.cmbYF.DropDownWidth = 215;
            this.cmbYF.Location = new System.Drawing.Point(84, 267);
            this.cmbYF.Name = "cmbYF";
            this.cmbYF.Size = new System.Drawing.Size(215, 21);
            this.cmbYF.TabIndex = 5;
            this.cmbYF.ValueMember = "ID";
            this.cmbYF.SelectedIndexChanged += new System.EventHandler(this.cmbYF_SelectedIndexChanged);
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord2.Data.源房);
            // 
            // BtnOkAndContinue
            // 
            this.BtnOkAndContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOkAndContinue.Location = new System.Drawing.Point(424, 265);
            this.BtnOkAndContinue.Name = "BtnOkAndContinue";
            this.BtnOkAndContinue.Size = new System.Drawing.Size(90, 25);
            this.BtnOkAndContinue.TabIndex = 2;
            this.BtnOkAndContinue.Values.Text = "保存并继续";
            this.BtnOkAndContinue.Visible = false;
            this.BtnOkAndContinue.Click += new System.EventHandler(this.BtnOkAndContinue_Click);
            // 
            // uC客房详细1
            // 
            this.uC客房详细1.BackColor = System.Drawing.Color.Transparent;
            this.uC客房详细1.Location = new System.Drawing.Point(10, 10);
            this.uC客房详细1.Name = "uC客房详细1";
            this.uC客房详细1.Size = new System.Drawing.Size(783, 240);
            this.uC客房详细1.TabIndex = 0;
            // 
            // kfForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 302);
            this.Controls.Add(this.cmbYF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.BtnOkAndContinue);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.uC客房详细1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kfForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "客房";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.kfForm_FormClosed);
            this.Load += new System.EventHandler(this.kfForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbYF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC客房详细 uC客房详细1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbYF;
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private ComponentFactory.Krypton.Toolkit.KryptonButton BtnOkAndContinue;
    }
}