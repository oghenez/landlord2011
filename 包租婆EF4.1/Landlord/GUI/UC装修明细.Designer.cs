namespace Landlord.GUI
{
    partial class UC装修明细
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewComboBoxColumn gridViewComboBoxColumn2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn3 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn4 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewSummaryItem gridViewSummaryItem2 = new Telerik.WinControls.UI.GridViewSummaryItem();
            this.装修分类BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radToolStrip1 = new Telerik.WinControls.UI.RadToolStrip();
            this.radToolStripElement1 = new Telerik.WinControls.UI.RadToolStripElement();
            this.radToolStripItem1 = new Telerik.WinControls.UI.RadToolStripItem();
            this.radToolStripLabelElement1 = new Telerik.WinControls.UI.RadToolStripLabelElement();
            this.radComboBoxElement1 = new Telerik.WinControls.UI.RadComboBoxElement();
            this.源房BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radToolStripElement2 = new Telerik.WinControls.UI.RadToolStripElement();
            this.radToolStripItem2 = new Telerik.WinControls.UI.RadToolStripItem();
            this.radToolStripLabelElement2 = new Telerik.WinControls.UI.RadToolStripLabelElement();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.装修明细BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBoxInfo)).BeginInit();
            this.radGroupBoxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.装修分类BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToolStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radComboBoxElement1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.装修明细BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBoxInfo
            // 
            this.radGroupBoxInfo.Controls.Add(this.radGridView1);
            this.radGroupBoxInfo.Controls.Add(this.radToolStrip1);
            this.radGroupBoxInfo.HeaderText = "装修明细";
            // 
            // 
            // 
            this.radGroupBoxInfo.RootElement.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.radGroupBoxInfo.Text = "装修明细";
            // 
            // 装修分类BindingSource
            // 
            this.装修分类BindingSource.DataSource = typeof(Landlord.装修分类);
            // 
            // radToolStrip1
            // 
            this.radToolStrip1.AllowDragging = false;
            this.radToolStrip1.AllowFloating = false;
            this.radToolStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radToolStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radToolStripElement1,
            this.radToolStripElement2});
            this.radToolStrip1.Location = new System.Drawing.Point(10, 20);
            this.radToolStrip1.MinimumSize = new System.Drawing.Size(5, 5);
            this.radToolStrip1.Name = "radToolStrip1";
            this.radToolStrip1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            this.radToolStrip1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.radToolStrip1.RootElement.MinSize = new System.Drawing.Size(5, 5);
            this.radToolStrip1.ShowOverFlowButton = true;
            this.radToolStrip1.Size = new System.Drawing.Size(568, 52);
            this.radToolStrip1.TabIndex = 0;
            this.radToolStrip1.Text = "radToolStrip1";
            // 
            // radToolStripElement1
            // 
            this.radToolStripElement1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radToolStripItem1});
            this.radToolStripElement1.Name = "radToolStripElement1";
            // 
            // radToolStripItem1
            // 
            this.radToolStripItem1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radToolStripLabelElement1,
            this.radComboBoxElement1});
            this.radToolStripItem1.Key = "0";
            this.radToolStripItem1.Name = "radToolStripItem1";
            this.radToolStripItem1.Text = "radToolStripItem1";
            // 
            // radToolStripLabelElement1
            // 
            this.radToolStripLabelElement1.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radToolStripLabelElement1.Name = "radToolStripLabelElement1";
            this.radToolStripLabelElement1.Text = "选择源房：";
            // 
            // radComboBoxElement1
            // 
            this.radComboBoxElement1.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radComboBoxElement1.ArrowButtonMinWidth = 16;
            this.radComboBoxElement1.DataSource = this.源房BindingSource;
            this.radComboBoxElement1.DefaultValue = null;
            this.radComboBoxElement1.DisplayMember = "房名";
            this.radComboBoxElement1.EditorElement = this.radComboBoxElement1;
            this.radComboBoxElement1.EditorManager = null;
            this.radComboBoxElement1.Focusable = true;
            this.radComboBoxElement1.MaxSize = new System.Drawing.Size(118, 20);
            this.radComboBoxElement1.MaxValue = null;
            this.radComboBoxElement1.MinSize = new System.Drawing.Size(118, 17);
            this.radComboBoxElement1.MinValue = null;
            this.radComboBoxElement1.Name = "radComboBoxElement1";
            this.radComboBoxElement1.NullTextColor = System.Drawing.SystemColors.GrayText;
            this.radComboBoxElement1.NullValue = null;
            this.radComboBoxElement1.OwnerOffset = 0;
            this.radComboBoxElement1.Value = null;
            this.radComboBoxElement1.ValueMember = "ID";
            // 
            // 源房BindingSource
            // 
            this.源房BindingSource.DataSource = typeof(Landlord.源房);
            // 
            // radToolStripElement2
            // 
            this.radToolStripElement2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radToolStripItem2});
            this.radToolStripElement2.Name = "radToolStripElement2";
            this.radToolStripElement2.Text = "radToolStripElement2";
            // 
            // radToolStripItem2
            // 
            this.radToolStripItem2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radToolStripLabelElement2});
            this.radToolStripItem2.Key = "0";
            this.radToolStripItem2.Name = "radToolStripItem2";
            this.radToolStripItem2.Text = "radToolStripItem2";
            // 
            // radToolStripLabelElement2
            // 
            this.radToolStripLabelElement2.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radToolStripLabelElement2.Name = "radToolStripLabelElement2";
            this.radToolStripLabelElement2.Text = "选择分类：";
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.SystemColors.Control;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radGridView1.ForeColor = System.Drawing.Color.Black;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(10, 72);
            // 
            // radGridView1
            // 
            gridViewDateTimeColumn2.DataType = typeof(System.DateTime);
            gridViewDateTimeColumn2.FieldName = "日期";
            gridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            gridViewDateTimeColumn2.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewDateTimeColumn2.FormatString = "{0:yy年MM月dd日}";
            gridViewDateTimeColumn2.HeaderText = "日期";
            gridViewDateTimeColumn2.IsAutoGenerated = true;
            gridViewDateTimeColumn2.Name = "日期";
            gridViewDateTimeColumn2.Width = 70;
            gridViewComboBoxColumn2.DataSource = this.装修分类BindingSource;
            gridViewComboBoxColumn2.DisplayMember = "类别";
            gridViewComboBoxColumn2.FieldName = "装修分类";
            gridViewComboBoxColumn2.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewComboBoxColumn2.HeaderText = "装修分类";
            gridViewComboBoxColumn2.Name = "column1";
            gridViewComboBoxColumn2.ValueMember = "类别";
            gridViewComboBoxColumn2.Width = 60;
            gridViewTextBoxColumn7.FieldName = "项目名称";
            gridViewTextBoxColumn7.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn7.HeaderText = "项目名称";
            gridViewTextBoxColumn7.IsAutoGenerated = true;
            gridViewTextBoxColumn7.Name = "项目名称";
            gridViewTextBoxColumn7.Width = 80;
            gridViewTextBoxColumn8.FieldName = "规格";
            gridViewTextBoxColumn8.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn8.HeaderText = "规格";
            gridViewTextBoxColumn8.IsAutoGenerated = true;
            gridViewTextBoxColumn8.Name = "规格";
            gridViewDecimalColumn3.DataType = typeof(decimal);
            gridViewDecimalColumn3.FieldName = "数量";
            gridViewDecimalColumn3.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewDecimalColumn3.HeaderText = "数量";
            gridViewDecimalColumn3.IsAutoGenerated = true;
            gridViewDecimalColumn3.Name = "数量";
            gridViewDecimalColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn9.FieldName = "单位";
            gridViewTextBoxColumn9.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn9.HeaderText = "单位";
            gridViewTextBoxColumn9.IsAutoGenerated = true;
            gridViewTextBoxColumn9.Name = "单位";
            gridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewDecimalColumn4.DataType = typeof(decimal);
            gridViewDecimalColumn4.FieldName = "单价";
            gridViewDecimalColumn4.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewDecimalColumn4.HeaderText = "单价";
            gridViewDecimalColumn4.IsAutoGenerated = true;
            gridViewDecimalColumn4.Name = "单价";
            gridViewDecimalColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn10.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn10.HeaderText = "小计";
            gridViewTextBoxColumn10.Name = "小计";
            gridViewTextBoxColumn10.ReadOnly = true;
            gridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn10.Width = 90;
            gridViewTextBoxColumn11.FieldName = "购买地点";
            gridViewTextBoxColumn11.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn11.HeaderText = "购买地点";
            gridViewTextBoxColumn11.IsAutoGenerated = true;
            gridViewTextBoxColumn11.Name = "购买地点";
            gridViewTextBoxColumn11.Width = 100;
            gridViewTextBoxColumn12.FieldName = "备注";
            gridViewTextBoxColumn12.FormatInfo = new System.Globalization.CultureInfo("");
            gridViewTextBoxColumn12.HeaderText = "备注";
            gridViewTextBoxColumn12.IsAutoGenerated = true;
            gridViewTextBoxColumn12.Name = "备注";
            gridViewTextBoxColumn12.Width = 150;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDateTimeColumn2,
            gridViewComboBoxColumn2,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewDecimalColumn3,
            gridViewTextBoxColumn9,
            gridViewDecimalColumn4,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.radGridView1.MasterTemplate.DataSource = this.装修明细BindingSource;
            gridViewSummaryItem2.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Sum;
            gridViewSummaryItem2.FormatString = "合计： {0:c}";
            gridViewSummaryItem2.Name = "小计";
            this.radGridView1.MasterTemplate.SummaryRowsBottom.Add(new Telerik.WinControls.UI.GridViewSummaryRowItem(new Telerik.WinControls.UI.GridViewSummaryItem[] {
                gridViewSummaryItem2}));
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.radGridView1.RootElement.ForeColor = System.Drawing.Color.Black;
            this.radGridView1.RootElement.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.radGridView1.Size = new System.Drawing.Size(568, 415);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.Text = "radGridView1";
            // 
            // 装修明细BindingSource
            // 
            this.装修明细BindingSource.DataSource = typeof(Landlord.装修明细);
            // 
            // UC装修明细
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "UC装修明细";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBoxInfo)).EndInit();
            this.radGroupBoxInfo.ResumeLayout(false);
            this.radGroupBoxInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.装修分类BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToolStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radComboBoxElement1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.源房BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.装修明细BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadToolStrip radToolStrip1;
        private Telerik.WinControls.UI.RadToolStripElement radToolStripElement1;
        private Telerik.WinControls.UI.RadToolStripItem radToolStripItem1;
        private Telerik.WinControls.UI.RadToolStripLabelElement radToolStripLabelElement1;
        private Telerik.WinControls.UI.RadComboBoxElement radComboBoxElement1;
        private System.Windows.Forms.BindingSource 源房BindingSource;
        private Telerik.WinControls.UI.RadToolStripElement radToolStripElement2;
        private Telerik.WinControls.UI.RadToolStripItem radToolStripItem2;
        private Telerik.WinControls.UI.RadToolStripLabelElement radToolStripLabelElement2;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private System.Windows.Forms.BindingSource 装修明细BindingSource;
        private System.Windows.Forms.BindingSource 装修分类BindingSource;
    }
}
