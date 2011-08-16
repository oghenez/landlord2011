using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Landlord2.Data;
using Landlord2.Properties;

namespace Landlord2.UI
{
    public class UC源房ToolStrip:ToolStrip
    {
        public ToolStripLabel toolStripLabel1;
        public ToolStripButton yfBtnAdd;
        public ToolStripButton yfBtnDel;
        public ToolStripButton yfBtnEdit;
        public ToolStripSeparator toolStripSeparator1;
        public ToolStripButton yfBtnAddKeFang;
        public ToolStripSeparator toolStripSeparator2;
        public ToolStripButton yfBtnPayDetail;
        public ToolStripSeparator toolStripSeparator3;
        public ToolStripButton yfBtnSdq;
        public ToolStripSeparator toolStripSeparator4;
        public ToolStripButton yfBtnZhuangXiuDetail;
        public ToolStripButton yfBtnPay;
        public ToolStripButton yfBtnSdqDetail;

        private 源房 yf;
        private TextImageRelation tir = TextImageRelation.ImageAboveText;

        public UC源房ToolStrip()
        {
            this.ImageScalingSize = new System.Drawing.Size(48, 48);//工具栏图标大小，主窗体上是48*48并且文字在图标下；子窗体上24*24，文字在图标右侧。
            AddBtn();
        }
        public UC源房ToolStrip(源房 yf)
        {
            this.ImageScalingSize = new System.Drawing.Size(24, 24);
            tir = TextImageRelation.ImageBeforeText;

            this.yf = yf;
            AddBtn();
        }

        //加入菜单
        private void AddBtn()
        { 
            //Label
            toolStripLabel1 = new ToolStripLabel("源房操作：");

            //以下按钮依次排列
            yfBtnAdd = new ToolStripButton();
            yfBtnAdd.Image = (yf == null)? Resources.源房48Add:Resources.源房24Add;
            yfBtnAdd.TextImageRelation = tir ;
            yfBtnAdd.Text = "新增源房";
            yfBtnAdd.ToolTipText = "新增一套源房信息";
            yfBtnAdd.Click += new System.EventHandler(yfBtnAdd_Click);
            
            yfBtnDel = new ToolStripButton();
            yfBtnDel.Image = (yf == null) ? Resources.源房48Del : Resources.源房24Del;
            yfBtnDel.TextImageRelation = tir;
            yfBtnDel.Text = "删除源房";
            yfBtnDel.ToolTipText = "删除当前选中的源房信息";
            yfBtnDel.Click += new System.EventHandler(yfBtnDel_Click);

            yfBtnEdit = new ToolStripButton();
            yfBtnEdit.Image = (yf == null) ? Resources.源房48Edit : Resources.源房24Edit;
            yfBtnEdit.TextImageRelation = tir;
            yfBtnEdit.Text = "编辑源房";
            yfBtnEdit.ToolTipText = "编辑当前选中的源房信息";
            yfBtnEdit.Click += new System.EventHandler(yfBtnEdit_Click);

            toolStripSeparator1=new ToolStripSeparator();

            yfBtnAddKeFang = new ToolStripButton();
            yfBtnAddKeFang.Image = (yf == null) ? Resources.客房48Add : Resources.客房24Add;
            yfBtnAddKeFang.TextImageRelation = tir;
            yfBtnAddKeFang.Text = "增加客房";
            yfBtnAddKeFang.ToolTipText = "为当前选中的源房增加客房";
            yfBtnAddKeFang.Click += new System.EventHandler(yfBtnAddKeFang_Click);

            toolStripSeparator2 = new ToolStripSeparator();

            yfBtnPay = new ToolStripButton();
            yfBtnPay.Text = "缴费";
            yfBtnPay.ToolTipText = "为当前选中的源房缴费\r\n例如：缴纳房租、水电等";
            yfBtnPay.Click += new System.EventHandler(yfBtnPay_Click);

            yfBtnPayDetail=new ToolStripButton();
            yfBtnPayDetail.Text = "缴费明细";
            yfBtnPayDetail.ToolTipText = "当前选中源房的所有缴费明细";
            yfBtnPayDetail.Click += new System.EventHandler(yfBtnPayDetail_Click);

            toolStripSeparator3 = new ToolStripSeparator();

            yfBtnSdq = new ToolStripButton();
            yfBtnSdq.Text = "抄表";
            yfBtnSdq.ToolTipText = "为当前选中的源房抄表\r\n包括：水、电、气表";
            yfBtnSdq.Click += new System.EventHandler(yfBtnSdq_Click);

            yfBtnSdqDetail = new ToolStripButton();
            yfBtnSdqDetail.Text = "抄表明细";
            yfBtnSdqDetail.ToolTipText = "当前选中源房的所有抄表明细";
            yfBtnSdqDetail.Click += new System.EventHandler(yfBtnSdqDetail_Click);

            toolStripSeparator4 = new ToolStripSeparator();

            yfBtnZhuangXiuDetail = new ToolStripButton();
            yfBtnZhuangXiuDetail.Text = "装修明细";
            yfBtnZhuangXiuDetail.ToolTipText = "当前选中源房的所有装修明细";
            yfBtnZhuangXiuDetail.Click += new System.EventHandler(yfBtnZhuangXiuDetail_Click);

            if (yf == null)
            {
                this.Items.AddRange(new ToolStripItem[] {                        
                        yfBtnAdd,
                        yfBtnDel,
                        yfBtnEdit,
                        toolStripSeparator1,
                        yfBtnPay,
                        yfBtnPayDetail,
                        toolStripSeparator3,
                        yfBtnSdq,
                        yfBtnSdqDetail,
                        toolStripSeparator4,
                        yfBtnZhuangXiuDetail});
            }
            else
            {
                this.Items.AddRange(new ToolStripItem[] {
                        toolStripLabel1,
                        yfBtnAdd,
                        yfBtnDel,
                        yfBtnEdit,
                        toolStripSeparator1,
                        yfBtnAddKeFang,
                        toolStripSeparator2,
                        yfBtnPay,
                        yfBtnPayDetail,
                        toolStripSeparator3,
                        yfBtnSdq,
                        yfBtnSdqDetail,
                        toolStripSeparator4,
                        yfBtnZhuangXiuDetail});
            }
        }
        private void yfBtnAdd_Click(object sender, EventArgs e)
        {
            //新增源房
            yfForm yF = new yfForm(null);
            yF.ShowDialog();
        }
        private void yfBtnDel_Click(object sender, EventArgs e)
        {
            //删除源房
            MessageBox.Show("删除源房");
        }
        private void yfBtnEdit_Click(object sender, EventArgs e)
        {
            //编辑源房
            MessageBox.Show("编辑源房");
        }

        private void yfBtnAddKeFang_Click(object sender, EventArgs e)
        {
            //增加客房
            MessageBox.Show("增加客房");
        }

        private void yfBtnPay_Click(object sender, EventArgs e)
        {
            //缴费
            MessageBox.Show("缴费");
        }

        private void yfBtnPayDetail_Click(object sender, EventArgs e)
        {
            //缴费明细
            MessageBox.Show("缴费明细");
        }

        private void yfBtnSdq_Click(object sender, EventArgs e)
        {
            //抄表
            MessageBox.Show("抄表");
        }

        private void yfBtnSdqDetail_Click(object sender, EventArgs e)
        {
            //抄表明细
            MessageBox.Show("抄表明细");
        }

        private void yfBtnZhuangXiuDetail_Click(object sender, EventArgs e)
        {
            //装修明细
            MessageBox.Show("装修明细");
        }





    }
}
