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
            this.uC客房详细1 = new Landlord2.UI.UC客房详细();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // uC客房详细1
            // 
            this.uC客房详细1.BackColor = System.Drawing.Color.Transparent;
            this.uC客房详细1.Location = new System.Drawing.Point(10, 10);
            this.uC客房详细1.Name = "uC客房详细1";
            this.uC客房详细1.Size = new System.Drawing.Size(749, 240);
            this.uC客房详细1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(652, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(521, 265);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Values.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // kfForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(768, 302);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.uC客房详细1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kfForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "kfForm";
            this.Load += new System.EventHandler(this.kfForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UC客房详细 uC客房详细1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
    }
}