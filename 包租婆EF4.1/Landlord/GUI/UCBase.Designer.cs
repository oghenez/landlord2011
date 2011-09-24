namespace Landlord.GUI
{
    partial class UCBase
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.radGroupBoxInfo = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBoxInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBoxInfo
            // 
            this.radGroupBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBoxInfo.FooterImageIndex = -1;
            this.radGroupBoxInfo.FooterImageKey = "";
            this.radGroupBoxInfo.HeaderImageIndex = -1;
            this.radGroupBoxInfo.HeaderImageKey = "";
            this.radGroupBoxInfo.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBoxInfo.HeaderText = "radGroupBoxInfo";
            this.radGroupBoxInfo.Location = new System.Drawing.Point(0, 0);
            this.radGroupBoxInfo.Margin = new System.Windows.Forms.Padding(10);
            this.radGroupBoxInfo.Name = "radGroupBoxInfo";
            this.radGroupBoxInfo.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            // 
            // 
            // 
            this.radGroupBoxInfo.RootElement.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.radGroupBoxInfo.Size = new System.Drawing.Size(588, 497);
            this.radGroupBoxInfo.TabIndex = 0;
            this.radGroupBoxInfo.Text = "radGroupBoxInfo";
            // 
            // UCBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radGroupBoxInfo);
            this.Name = "UCBase";
            this.Size = new System.Drawing.Size(588, 497);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBoxInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.UI.RadGroupBox radGroupBoxInfo;

    }
}
