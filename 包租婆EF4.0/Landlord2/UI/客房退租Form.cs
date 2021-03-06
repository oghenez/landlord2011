﻿using System;
using System.Data;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Landlord2.Data;
using System.Data.Objects;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Landlord2.UI
{
    public partial class 客房退租Form : FormBase
    {
        public 客房 kf;
        private 客房租金明细 collectRent;
        private 客房出租历史记录 history;//【客房出租历史记录】对象
        private bool IsFirstLoad;//是否初次加载，优化初次启动时间，避免多次触发计算函数

        /// <summary>
        /// 实际支付月数（也许协议期内最后一次收租月数小于[客房的支付月数]，2位小数计算‘按天’收取的费用）
        /// </summary>
        private decimal realMonthNum;
        private MyRtf myRtf;

        /// <summary>
        /// 当前客房租户所有余款（实付金额-应付金额），正数表示‘租户多付’，负数表示‘欠款’。
        /// </summary>
        private decimal balancePayment = 0.00M;
        public 客房退租Form(Guid kfID)
        {
            InitializeComponent();
            this.kf = context.客房.FirstOrDefault(m => m.ID == kfID);
            IsFirstLoad = true;
        }

        private void 客房退租Form_Load(object sender, EventArgs e)
        {
            //dtpDateEnd.MinDate = kf.期始.Value.Date;//供用户可调整的结算日期，限定最小值。并
            dtpDateEnd.Value = DateTime.Now.Date; //自动引发Bindingdata();   

            IsFirstLoad = false;//第一次加载结束
        }
        private void dtpDateEnd_ValueChanged(object sender, EventArgs e)
        {
            BindingData();
        }
        private void BindingData()
        {
            //拷贝数据到新的【客房出租历史记录】对象
            history = new 客房出租历史记录();//构造一个新的【客房出租历史记录】对象
            history.备注 = kf.备注;
            history.操作日期 = DateTime.Now;
            history.电话1 = kf.电话1;
            history.电话2 = kf.电话2;
            history.电始码 = kf.电始码;
            history.客房ID = kf.ID; //此时因为还未加入context中，所以不会同步客房引用。
            history.联系地址 = kf.联系地址;
            history.期始 = kf.期始.Value;
            history.期止 = kf.期止.Value;
            history.气始码 = kf.气始码;
            history.身份证号 = kf.身份证号;
            history.水始码 = kf.水始码;
            history.押金 = kf.押金;
            history.月厨房费 = kf.月厨房费;
            history.月宽带费 = kf.月宽带费;
            history.月物业费 = kf.月物业费;
            history.月租金 = kf.月租金;
            history.支付月数 = kf.支付月数;
            history.中介费用 = kf.中介费用;
            history.租户 = kf.租户;
            history.租赁协议照片1 = kf.租赁协议照片1;
            history.租赁协议照片2 = kf.租赁协议照片2;
            history.租赁协议照片3 = kf.租赁协议照片3;


            if(collectRent != null)
                context.客房租金明细.DeleteObject(collectRent);//删除前次新增的对象

            btnOK.Enabled = true;//这里先置true，后续判断该租户没有交租记录会置false的。            

            kryptonHeader1.Values.Heading = kf.源房.房名;
            kryptonHeader1.Values.Description = kf.命名;
            租户Label1.Text = kf.租户;
            协议期label1.Text = kf.期始.Value.ToShortDateString();
            协议期label2.Text = kf.期止.Value.ToShortDateString();

            //进入此界面，理论上客房应该出租了，有租户信息
#if DEBUG
            System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(kf.租户));
#endif
            //针对当前租户的所有协议历史缴费（包括之前续租的）
            List<客房租金明细> orderedList = 客房租金明细.GetRentDetails_Current(kf);
            参考历史BindingSource.DataSource = orderedList;

            if (orderedList.Count == 0)//该租户第一次交租
            {
                var result = KryptonMessageBox.Show("该租户没有交租记录，是否直接清除租户信息？\r\n（客房将转为【未出租】状态）",
                    "清除租户信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    kf.移除租户信息();
                    string msg;
                    if (Helper.saveData(context, kf, out msg))
                    {
                        KryptonMessageBox.Show(msg, "成功清除租户信息");
                        if (this.Owner is Main)
                            (this.Owner as Main).RefreshAndLocateTree(kf);//刷新TreeView，并定位到kf节点。
                        Close();
                    }
                    else
                    {
                        KryptonMessageBox.Show(msg, "失败");
                    }
                }
                else
                {
                    btnOK.Enabled = false;//保存按钮不可用，用户可以在此界面更改欲操作客房。
                }
                return;
            }
            else//非第一次交租情况下的退租：（有可能结算日期小于上次交租的期止时间，这时需要计算的是‘退款’）
            {
                bool IsDrawback = false;//是否为‘退款’
                myRtf = new MyRtf();//初始化
                客房租金明细 lastCollectRent = orderedList[0];//最近交租明细记录

                //新对象，根据情况赋予初始值
                collectRent = new 客房租金明细();
                collectRent.付款人 = kf.租户;
                collectRent.客房ID = kf.ID;
                //新对象的‘起付时间’与之前的‘止付时间’连续
                collectRent.起付日期 = lastCollectRent.止付日期.AddDays(1).Date;
                collectRent.止付日期 = dtpDateEnd.Value.Date;
                collectRent.水止码 = lastCollectRent.水止码;//止码设置为始码值，相当于没有用(用户会自行修改)
                collectRent.电止码 = lastCollectRent.电止码;
                collectRent.气止码 = lastCollectRent.气止码;

#if DEBUG
                System.Diagnostics.Debug.Assert(lastCollectRent.止付日期.Date <= kf.期止.Value.Date);
#endif
                if (dtpDateEnd.Value.Date == kf.期止.Value.Date)
                {
                    myRtf.结算日期VS协议期止日期 = "等于";
                    myRtf.退租类型 = "正常退租";
                    history.状态 = "正常退租"; //正常退租状态下，转入历史记录的

                    if (lastCollectRent.止付日期.Date == kf.期止.Value.Date)//协议租金已全部收讫
                    {
                        collectRent.起付日期 = dtpDateEnd.Value.Date;//这种情况，接下来只计算水电气费用
                    }
                }
                else if (dtpDateEnd.Value.Date > kf.期止.Value.Date)
                {
                    myRtf.结算日期VS协议期止日期 = "大于";
                    myRtf.退租类型 = "逾期退租";
                    history.状态 = "逾期退租"; //逾期退租状态下，转入历史记录的

                }
                else
                {
                    myRtf.结算日期VS协议期止日期 = "小于";
                    myRtf.退租类型 = "提前退租";
                    history.状态 = "提前退租"; //提前退租状态下，转入历史记录的

                    if (dtpDateEnd.Value.Date < lastCollectRent.止付日期.Date)//需退款
                    {
                        IsDrawback = true;
                        //临时对起止日期赋值，退款操作统一计算这段时间应退款。
                        collectRent.起付日期 = dtpDateEnd.Value.Date.AddDays(1);
                        collectRent.止付日期 = lastCollectRent.止付日期.Date;
                    }
                }                

                //计算支付月数
                if(dtpDateEnd.Value.Date == lastCollectRent.止付日期.Date)
                    realMonthNum = 0;
                else
                    CaculateMonth(IsDrawback);

                myRtf.退租支付期Begin = collectRent.起付日期.ToShortDateString();
                myRtf.退租支付期End = collectRent.止付日期.ToShortDateString();

                //更新RichTextBox内容，并调整高度
                int cutHeight;
                richTbox.Rtf = myRtf.getRTF(out cutHeight);
                richTbox.Height =89 - cutHeight; //89为原始高度
                this.Height =610 - cutHeight;//610为原始高度

                //计算该租户历史余款
                foreach (var rent in orderedList)
                {
                    balancePayment += rent.实付金额 - rent.应付金额;
                }

                水始码Label1.Text = collectRent.水止码.ToString();
                电始码Label1.Text = collectRent.电止码.ToString();
                气始码Label1.Text = collectRent.气止码.ToString(); 
                月租金Label1.Text = (kf.月租金 * realMonthNum).ToString("F2");
                月宽带费Label1.Text = (kf.月宽带费 * realMonthNum).ToString("F2");
                月物业费Label1.Text = (kf.月物业费 * realMonthNum).ToString("F2");
                月厨房费Label1.Text = (kf.月厨房费 * realMonthNum).ToString("F2");
                押金Label1.Text = kf.押金.ToString("F2");
                lblBalance.Text = balancePayment.ToString("F2");
                lblBalance.ForeColor = balancePayment >= 0 ? Color.Green : Color.Red;//历史欠款的话，红色

                CaculateSum();

                context.客房租金明细.AddObject(collectRent);//此操作后可实现外键同步
                客房租金明细BindingSource.DataSource = collectRent;
                //----------
                nud水费.Minimum = (decimal)collectRent.水止码;
                nud电费.Minimum = (decimal)collectRent.电止码;
                nud气费.Minimum = (decimal)collectRent.气止码;
    
            }
        }

        private void CaculateMonth(bool IsDrawback)
        {
            realMonthNum = 0;
            DateTime tempBegin;
            DateTime tempEnd = collectRent.起付日期.AddDays(-1);//初始置为起付日期头一天，do-while至少会执行一次的。
            do
            {
                tempBegin = tempEnd.AddDays(1);
                tempEnd = tempBegin.AddMonths(1).AddDays(-1);//支付一个月
                realMonthNum++;
            } while (tempEnd < collectRent.止付日期);
            //-->得到应缴月数(有可能最后一个月尾期天数不足一个月)

            realMonthNum--;
            if (tempEnd == collectRent.止付日期)//正好足月
            {
                myRtf.尾期不足月 = false;
                realMonthNum++;
            }
            else//最后一个月尾期天数不足一个月，且通过前面的do...while此时应该是tempEnd > collectRent.止付日期
            {
                decimal extraDays = (collectRent.止付日期 - tempBegin).Days + 1;
                decimal monthDays = (tempEnd - tempBegin).Days;
                decimal extraMonth = 1;
                string dayOrMonth = cmbDayMonth.SelectedItem.ToString();
                if (dayOrMonth == "天")
                {
                    extraMonth = extraDays / monthDays; //将额外天数变化为‘小数月’
                    realMonthNum += extraMonth;
                }
                else
                {
                    if (!IsDrawback)//非退租。退租情况下意味着：按月算此月不退。
                        realMonthNum++;
                }

                if (!IsDrawback)//非退租
                {
                    myRtf.尾期不足月 = true;
                    myRtf.尾期不足月天数 = extraDays.ToString("F0");
                    myRtf.尾期不足月天数Begin = tempBegin.ToShortDateString();
                    myRtf.尾期不足月天数End = collectRent.止付日期.ToShortDateString();
                    myRtf.DayOrMonth = dayOrMonth;
                    myRtf.租金 = (kf.月租金 * extraMonth).ToString("F2");
                    myRtf.宽带 = (kf.月宽带费 * extraMonth).ToString("F2");
                    myRtf.物业 = (kf.月物业费 * extraMonth).ToString("F2");
                    myRtf.厨房 = (kf.月厨房费 * extraMonth).ToString("F2");
                    myRtf.共计 = ((kf.月租金 + kf.月宽带费 + kf.月物业费 + kf.月厨房费) * extraMonth).ToString("F2");
                }
            }

            if (IsDrawback)
            {
                myRtf.需退尾期 = true;
                myRtf.退租尾期End = collectRent.止付日期.ToShortDateString();
                myRtf.退租金 = (kf.月租金 * realMonthNum).ToString("F2");
                myRtf.退宽带 = (kf.月宽带费 * realMonthNum).ToString("F2");
                myRtf.退物业 = (kf.月物业费 * realMonthNum).ToString("F2");
                myRtf.退厨房 = (kf.月厨房费 * realMonthNum).ToString("F2");
                myRtf.退共计 = ((kf.月租金 + kf.月宽带费 + kf.月物业费 + kf.月厨房费) * realMonthNum).ToString("F2");

                realMonthNum *= -1; //退款置为负值
                collectRent.起付日期 = collectRent.止付日期 = dtpDateEnd.Value.Date;//最后调整期止时间                        
            }
        }
        /// <summary>
        /// 计算合计应付金额
        /// </summary>
        private void CaculateSum()
        {
            decimal sum = 0.00M;
            sum += kf.月租金 * realMonthNum;
            sum += kf.月宽带费 * realMonthNum;
            sum += kf.月物业费 * realMonthNum;
            sum += kf.月厨房费 * realMonthNum;
            sum -= kf.押金;
            sum += nud违约金.Value;

            //...........
            decimal temp = Helper.calculate水费(kf.源房.阶梯水价, ((decimal)collectRent.水止码 - Convert.ToDecimal(水始码Label1.Text)));
            lbl水费.Text = temp.ToString("F2");
            sum += temp;

            temp = Helper.calculate电费(kf.源房.阶梯电价, ((decimal)collectRent.电止码 - Convert.ToDecimal(电始码Label1.Text)));
            lbl电费.Text = temp.ToString("F2");
            sum += temp;

            temp = (-1) * (decimal)kf.源房.气单价 * ((decimal)collectRent.气止码 - Convert.ToDecimal(气始码Label1.Text));//气表剩余读数小于起始读数，计算为负数
            lbl气费.Text = temp.ToString("F2");
            sum += temp;

            collectRent.应付金额 = decimal.Round(sum, 2);
            toolTip1.SetToolTip(应付金额Label, "历史余额未计算在内");

            //考虑历史余额
            collectRent.实付金额 = decimal.Round(sum - balancePayment, 2);

        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Rectangle r = e.CellBounds;

            using (Pen pen = new Pen(Color.DimGray, 1))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                if (e.Row == (tableLayoutPanel1.RowCount - 1))
                    r.Height -= 1;

                if (e.Column == (tableLayoutPanel1.ColumnCount - 1))
                    r.Width -= 1;

                e.Graphics.DrawRectangle(pen, r);
            }

        }


        private void kryptonNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (sender.Equals(nud水费))
                collectRent.水止码 = (double)nud水费.Value;
            if (sender.Equals(nud电费))
                collectRent.电止码 = (double)nud电费.Value;
            if (sender.Equals(nud气费))
                collectRent.气止码 = (double)nud气费.Value;
            
            if(!IsFirstLoad)
                CaculateSum();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            客房租金明细BindingSource.EndEdit();

            //string check = collectRent.CheckRules();
            //if (!string.IsNullOrEmpty(check))
            //{
            //    KryptonMessageBox.Show(check, "数据校验失败");
            //    return;
            //}

            //此时加入新的【客房出租历史记录】对象
            context.客房出租历史记录.AddObject(history);
            //客房删除租户等相关信息，转为‘未出租’状态
            kf.移除租户信息();

            string msg;
            if (Helper.saveData(context, collectRent, out msg))
            {
                KryptonMessageBox.Show(msg, "成功退租");
                if (this.Owner is Main)
                    (this.Owner as Main).RefreshAndLocateTree(kf);//刷新TreeView，并定位到kf节点。
                Close();
            }
            else
            {
                KryptonMessageBox.Show(msg, "失败");
                context.客房出租历史记录.DeleteObject(history);//失败移除
                //恢复kf的租户信息
                kf = context.客房.FirstOrDefault(m => m.ID == kf.ID);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        #region 处理RTF文档
        public class MyRtf
        {
            public string 退租支付期Begin { get; set; }
            public string 退租支付期End { get; set; }
            public string 结算日期VS协议期止日期 { get; set; }
            public string 退租类型 { get; set; }

            public bool 尾期不足月 { get; set; }
            public string 尾期不足月天数 { get; set; }
            public string 尾期不足月天数Begin { get; set; }
            public string 尾期不足月天数End { get; set; }
            public string DayOrMonth { get; set; }
            public string 租金 { get; set; }
            public string 宽带 { get; set; }
            public string 物业 { get; set; }
            public string 厨房 { get; set; }
            public string 共计 { get; set; }

            public bool 需退尾期 { get; set; }
            public string 退租尾期End { get; set; }
            public string 退租金 { get; set; }
            public string 退宽带 { get; set; }
            public string 退物业 { get; set; }
            public string 退厨房 { get; set; }
            public string 退共计 { get; set; }

            private const string rtfHead = @"{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052{\fonttbl{\f0\fnil\fcharset134 \'cb\'ce\'cc\'e5;}}{\colortbl ;\red255\green0\blue0;\red0\green77\blue187;}{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\lang2052\f0\fs18 ";
            private const string rtfEnd = @"}";

            //▶退租支付期：2010-10-10★～2010-10-10★ （结算日期等于★协议期止日期，属【正常退租★】）
            private const string rtf1 = @"\u9654?\'cd\'cb\'d7\'e2\'d6\'a7\'b8\'b6\'c6\'da\'a3\'ba\cf1\b\{{{0}\'a1\'ab{1}\}} \cf0\b0\'a3\'a8\'bd\'e1\'cb\'e3\'c8\'d5\'c6\'da\cf1\b {2}\cf0\b0\'d0\'ad\'d2\'e9\'c6\'da\'d6\'b9\'c8\'d5\'c6\'da\'a3\'ac\'ca\'f4\cf1\'a1\'be{3}\'a1\'bf\cf0\'a3\'a9\'a1\'a3\par "; //若要在 format 中指定单个大括号字符，请指定两个前导大括号字符或尾部大括号字符；即“{{”或“}}”。 

            //▶尾期不足月天数18★天（2010-10-10★～2010-10-10★），按‘天★’计算：
            ////租金（XXXX.XX★元）、宽带费（XXX.XX★元）、物业费（XXX.XX★元）、厨房费（XXX.XX★元），共计XXXX.XX★元。
            private const string rtf2 = @"\u9654?\'ce\'b2\'c6\'da\'b2\'bb\'d7\'e3\'d4\'c2\'cc\'ec\'ca\'fd\cf1 {0}\cf0\'cc\'ec\'a3\'a8{1}\'a1\'ab{2}\'a3\'a9\'a3\'ac\'b0\'b4\cf1\b\lquote {3}\rquote\cf0\b0\'bc\'c6\'cb\'e3\'a3\'ba\par \'d7\'e2\'bd\'f0\'a3\'a8\cf2\b {4}\cf0\b0\'d4\'aa\'a3\'a9\'a1\'a2\'bf\'ed\'b4\'f8\'b7\'d1\'a3\'a8\cf2\b {5}\cf0\b0\'d4\'aa\'a3\'a9\'a1\'a2\'ce\'ef\'d2\'b5\'b7\'d1\'a3\'a8\cf2\b {6}\cf0\b0\'d4\'aa\'a3\'a9\'a1\'a2\'b3\'f8\'b7\'bf\'b7\'d1\'a3\'a8\cf2\b {7}\cf0\b0\'d4\'aa\'a3\'a9\'a3\'ac\'b9\'b2\'bc\'c6\cf1\b {8}\cf0\b0\'d4\'aa\'a1\'a3\par ";

            //▶因租户提前退租且已缴费至2010-10-10★，需退回租户：
            ////租金（XXXX.XX★元）、宽带费（XXX.XX★元）、物业费（XXX.XX★元）、厨房费（XXX.XX★元），共计XXXX.XX★元。
            private const string rtf3 = @"\u9654?\'d2\'f2\'d7\'e2\'bb\'a7\'cc\'e1\'c7\'b0\'cd\'cb\'d7\'e2\'c7\'d2\'d2\'d1\'bd\'c9\'b7\'d1\'d6\'c1{0}\'a3\'ac\'d0\'e8\'cd\'cb\'bb\'d8\'d7\'e2\'bb\'a7\'a3\'ba\par \'d7\'e2\'bd\'f0\'a3\'a8\cf2\b {1}\cf0\b0\'d4\'aa\'a3\'a9\'a1\'a2\'bf\'ed\'b4\'f8\'b7\'d1\'a3\'a8\cf2\b {2}\cf0\b0\'d4\'aa\'a3\'a9\'a1\'a2\'ce\'ef\'d2\'b5\'b7\'d1\'a3\'a8\cf2\b {3}\cf0\b0\'d4\'aa\'a3\'a9\'a1\'a2\'b3\'f8\'b7\'bf\'b7\'d1\'a3\'a8\cf2\b {4}\cf0\b0\'d4\'aa\'a3\'a9\'a3\'ac\'b9\'b2\'bc\'c6\cf1\b {5}\cf0\b0\'d4\'aa\'a1\'a3\par ";

            public string getRTF(out int cutHeight)
            {
                cutHeight = 0;
                StringBuilder sb = new StringBuilder();
                sb.Append(rtfHead);
                sb.Append(string.Format(rtf1, 退租支付期Begin, 退租支付期End, 结算日期VS协议期止日期, 退租类型));
                if (尾期不足月)
                    sb.Append(string.Format(rtf2, 尾期不足月天数, 尾期不足月天数Begin, 尾期不足月天数End, DayOrMonth, 租金, 宽带, 物业, 厨房, 共计));
                else
                    cutHeight += 34;//2行34px高度
                if (需退尾期)
                    sb.Append(string.Format(rtf3, 退租尾期End, 退租金, 退宽带, 退物业, 退厨房, 退共计));
                else
                    cutHeight += 34;
                sb.Append(rtfEnd);
                return sb.ToString();
            }
        }
        
        #endregion


    }
}
