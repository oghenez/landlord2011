namespace Landlord2.UI
{
    partial class 客房出租历史记录Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(客房出租历史记录Form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.llbKF = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.raBtnOne = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.raBtnAll = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.llbKF);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.raBtnOne);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.raBtnAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 60);
            this.panel1.TabIndex = 1;
            // 
            // llbKF
            // 
            this.llbKF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llbKF.Enabled = false;
            this.llbKF.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.llbKF.Location = new System.Drawing.Point(114, 20);
            this.llbKF.Name = "llbKF";
            this.llbKF.Size = new System.Drawing.Size(133, 20);
            this.llbKF.TabIndex = 2;
            this.llbKF.Values.ExtraText = "<请选择>";
            this.llbKF.Values.Text = "单套客房：";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(717, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Values.Text = "取消";
            // 
            // raBtnOne
            // 
            this.raBtnOne.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.raBtnOne.Location = new System.Drawing.Point(102, 24);
            this.raBtnOne.Name = "raBtnOne";
            this.raBtnOne.Size = new System.Drawing.Size(18, 12);
            this.raBtnOne.TabIndex = 1;
            this.raBtnOne.Values.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(582, 18);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 4;
            this.btnOK.Values.Text = "保存";
            // 
            // raBtnAll
            // 
            this.raBtnAll.Checked = true;
            this.raBtnAll.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.raBtnAll.Location = new System.Drawing.Point(12, 20);
            this.raBtnAll.Name = "raBtnAll";
            this.raBtnAll.Size = new System.Drawing.Size(72, 20);
            this.raBtnAll.TabIndex = 0;
            this.raBtnAll.Values.Text = "全部客房";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlToolTip;
            this.kryptonPanel1.Size = new System.Drawing.Size(844, 66);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.AutoSize = false;
            this.kryptonWrapLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonWrapLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(61, 5);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(778, 56);
            this.kryptonWrapLabel1.Text = resources.GetString("kryptonWrapLabel1.Text");
            this.kryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.kryptonLabel1.Location = new System.Drawing.Point(5, 5);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(56, 56);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Image = global::Landlord2.Properties.Resources.info;
            this.kryptonLabel1.Values.Text = "";
            // 
            // 客房出租历史记录Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 444);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "客房出租历史记录Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "客房出租历史记录";
            this.Load += new System.EventHandler(this.客房出租历史记录Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel llbKF;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton raBtnOne;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton raBtnAll;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
    }
}