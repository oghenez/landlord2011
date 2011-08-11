namespace Landlord2.UI
{
    partial class UC源房详细
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label 房名Label;
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.房名TextBox = new System.Windows.Forms.TextBox();
            房名Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(房名Label);
            this.kryptonPanel1.Controls.Add(this.房名TextBox);
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord2.Data.源房);
            // 
            // 房名Label
            // 
            房名Label.AutoSize = true;
            房名Label.Location = new System.Drawing.Point(91, 76);
            房名Label.Name = "房名Label";
            房名Label.Size = new System.Drawing.Size(35, 12);
            房名Label.TabIndex = 0;
            房名Label.Text = "房名:";
            // 
            // 房名TextBox
            // 
            this.房名TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.源房BindingSource, "房名", true));
            this.房名TextBox.Location = new System.Drawing.Point(132, 73);
            this.房名TextBox.Name = "房名TextBox";
            this.房名TextBox.Size = new System.Drawing.Size(100, 21);
            this.房名TextBox.TabIndex = 1;
            // 
            // UC源房详细
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "UC源房详细";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox 房名TextBox;
        private System.Windows.Forms.BindingSource 源房BindingSource;

    }
}
