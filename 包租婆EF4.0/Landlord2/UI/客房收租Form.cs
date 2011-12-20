using System;
using System.Data;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Landlord2.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace Landlord2.UI
{
    public partial class 客房收租Form : FormBase
    {
        public 客房 kf;
        private 客房租金明细 collectRent;
        private bool IsFirstLoad;//是否初次加载，优化初次启动时间，避免多次触发计算函数
        /// <summary>
        /// 实际支付月数（也许协议期内最后一次收租月数小于[客房的支付月数]）
        /// </summary>
        private decimal realMonthNum;

        /// <summary>
        /// 是否首次收租，首次收租要交押金
        /// </summary>
        private bool isFirstTime;

        /// <summary>
        /// 当前客房租户所有余款（实付金额-应付金额），正数表示‘租户多付’，负数表示‘欠款’。
        /// </summary>
        private decimal balancePayment = 0.00M;

        public 客房收租Form(Guid kfID)
        {
            InitializeComponent();
            this.kf = context.客房.FirstOrDefault(m=>m.ID == kfID);
            IsFirstLoad = true;
        }
        private void 客房收租Form_Load(object sender, EventArgs e)
        {
            BindingData();
            IsFirstLoad = false;//第一次加载结束
        }
        private void BindingData()
        {
            if (collectRent != null)
                context.客房租金明细.DeleteObject(collectRent);//删除前次新增的对象

            kryptonHeader1.Values.Heading = kf.源房.房名;
            kryptonHeader1.Values.Description = kf.命名;
            租户Label1.Text = kf.租户;

            //进入此界面，理论上客房应该出租了，有租户信息
#if DEBUG
            System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(kf.租户));
#endif
            //针对当前租户的所有协议历史缴费（包括之前续租的）
            List<客房租金明细> orderedList = 客房租金明细.GetRentDetails_Current(kf);
            参考历史BindingSource.DataSource = orderedList;

            //新对象，根据情况赋予初始值
            collectRent = new 客房租金明细();
            collectRent.付款人 = kf.租户;
            collectRent.客房ID = kf.ID;
            //新对象的‘起付时间’与之前的‘止付时间’连续
            if (orderedList.Count == 0)//该租户第一次交租
            {
                isFirstTime = true;
                collectRent.起付日期 = kf.期始.Value.Date;
                collectRent.水止码 = kf.水始码;//止码设置为始码值，相当于没有用
                collectRent.电止码 = kf.电始码;
                collectRent.气止码 = kf.气始码;
                nud水费.Enabled = false;//首次收租，不需要调整水电气
                nud电费.Enabled = false;
                nud气费.Enabled = false;
                toolTip1.SetToolTip(tableLayoutPanel1, "首次收租不涉及水电气费用，如需调整始码，请进行[客房编辑]操作。");
            }
            else
            {
                客房租金明细 lastCollectRent = orderedList[0];//最近交租明细记录
                isFirstTime = false;
                collectRent.起付日期 = lastCollectRent.止付日期.AddDays(1).Date;
                collectRent.水止码 = lastCollectRent.水止码;//止码设置为始码值，相当于没有用(用户会自行修改)
                collectRent.电止码 = lastCollectRent.电止码;
                collectRent.气止码 = lastCollectRent.气止码;
                押金Label1.ForeColor = Color.Gray ;//非首次收租，押金置灰。
                toolTip1.SetToolTip(押金Label1, "非首次收租不涉及押金。");

                //非初次交租，计算该租户历史余款
                foreach (var rent in orderedList)
                {
                    balancePayment += rent.实付金额 - rent.应付金额;
                }
            }
            collectRent.止付日期 = collectRent.起付日期.AddMonths(kf.支付月数).AddDays(-1);
            
            //当协议的期止并非刚好间隔支付月数时，协议期内最后一次收租的止付日期需要调整，再计算租金
            realMonthNum = kf.支付月数;
            if (collectRent.止付日期 > kf.期止.Value.Date)
            {
                collectRent.止付日期 = kf.期止.Value.Date;//赋值，后续将进入‘计算月数’函数

                //计算支付月数
                if (collectRent.起付日期 > kf.期止.Value.Date)
                    realMonthNum = 0;
                else
                    CaculateMonth();
            }
            //----------
            nud水费.Minimum = (decimal)collectRent.水止码;
            nud电费.Minimum = (decimal)collectRent.电止码;
            nud气费.Minimum = (decimal)collectRent.气止码;
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
        }

        private void CaculateMonth()
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
                groupBox1.Visible = false;
                realMonthNum++;
            }
            else//最后一个月尾期天数不足一个月，且通过前面的do...while此时应该是tempEnd > collectRent.止付日期
            {
                groupBox1.Visible = true;
                decimal extraDays = (collectRent.止付日期 - tempBegin).Days + 1;
                decimal monthDays = (tempEnd - tempBegin).Days;
                string dayOrMonth = cmbDayMonth.SelectedItem.ToString();
                if (dayOrMonth == "天")
                {
                    realMonthNum += extraDays / monthDays; //将额外天数变化为‘小数月’
                }
                else
                {
                    realMonthNum++;
                }
                lblDayMonth.Text = string.Format("尾期{0}～{1}不足月({2}天)"
                    ,tempBegin.ToShortDateString()
                    ,collectRent.止付日期.ToShortDateString()
                    ,extraDays.ToString("F0"));
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
            if (isFirstTime)
                sum += kf.押金;//首次收租要交押金
            //...........
            decimal temp= Helper.calculate水费(kf.源房.阶梯水价, ((decimal)collectRent.水止码 - Convert.ToDecimal(水始码Label1.Text)));
            lbl水费.Text = temp.ToString("F2");
            sum += temp;

            temp = Helper.calculate电费(kf.源房.阶梯电价, ((decimal)collectRent.电止码 - Convert.ToDecimal(电始码Label1.Text)));
            lbl电费.Text = temp.ToString("F2");
            sum += temp;

            temp = (decimal)kf.源房.气单价 * ((decimal)collectRent.气止码 - Convert.ToDecimal(气始码Label1.Text));
            lbl气费.Text = temp.ToString("F2");
            sum += temp;

            collectRent.应付金额 = decimal.Round(sum,2);
            toolTip1.SetToolTip(应付金额Label, "历史余额未计算在内");        
    
            //考虑历史余额
            collectRent.实付金额 = decimal.Round(sum - balancePayment,2);
        }

        private void cmbDayMonth_Changed(object sender, EventArgs e)
        {
            BindingData();
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
            if(sender.Equals(nud水费))
                collectRent.水止码 = (double)nud水费.Value;
            if (sender.Equals(nud电费))
                collectRent.电止码 = (double)nud电费.Value;
            if (sender.Equals(nud气费))
                collectRent.气止码 = (double)nud气费.Value;

            if (!IsFirstLoad) 
                CaculateSum();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            客房租金明细BindingSource.EndEdit();

            string check = collectRent.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }

            string msg;
            if (Helper.saveData(context, collectRent, out msg))
            {
                KryptonMessageBox.Show(msg, "成功收租");
                if (this.Owner is Main)
                    (this.Owner as Main).RefreshAndLocateTree(kf);//刷新TreeView，并定位到kf节点。
                Close();
            }
            else
            {
                KryptonMessageBox.Show(msg, "失败");
            }

        }

        private void 客房收租Form_Shown(object sender, EventArgs e)
        {
            Check();
        }

        /// <summary>
        /// 校验是否租户协议期内租金已全部收讫
        /// </summary>
        private void Check()
        {
            if (collectRent.起付日期 > kf.期止.Value.Date)
            {
                collectRent.止付日期 = DateTime.MaxValue.Date;//这里显示最大值，以免造成误会。
                KryptonMessageBox.Show("租户协议期内租金已全部收讫，请先【续租】！");
                btnOK.Enabled = false;
            }
            else
                btnOK.Enabled = true;
        }
    

    
    }
}
