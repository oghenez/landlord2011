namespace Landlord2.UI
{
    partial class UCBase
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BasePanel = new DoubleBufferdPanel();
            this.SuspendLayout();
            // 
            // BasePanel
            // 
            this.BasePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BasePanel.Location = new System.Drawing.Point(16, 43);
            this.BasePanel.Name = "BasePanel";
            this.BasePanel.Size = new System.Drawing.Size(569, 372);
            this.BasePanel.TabIndex = 0;
            // 
            // UCBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.BasePanel);
            this.Name = "UCBase";
            this.Size = new System.Drawing.Size(588, 429);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.UCBase_Layout);
            this.ResumeLayout(false);

        }

        #endregion

        protected DoubleBufferdPanel BasePanel;


    }
}
