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
    public partial class 客房收租Form : KryptonForm
    {
        public 客房 kf;
        private 客房租金明细 collectRent;
        public 客房收租Form(客房 kf)
        {
            InitializeComponent();
            this.kf = kf;            
        }

        private void BindingData()
        {
            月租金Label1.Text = (kf.月租金 * kf.支付月数).ToString("F2");
            月宽带费Label1.Text = (kf.月宽带费 * kf.支付月数).ToString("F2");
            月物业费Label1.Text = (kf.月物业费 * kf.支付月数).ToString("F2");
            月厨房费Label1.Text = (kf.月厨房费 * kf.支付月数).ToString("F2");
            押金Label1.Text = kf.押金.ToString("F2");

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
                collectRent.起付日期 = kf.客房租金明细.Max(m => m.止付日期).AddDays(1).Date;
                collectRent.水止码 = kf.客房租金明细.Max(m => m.水止码);//止码设置为始码值，相当于没有用(用户会自行修改)
                collectRent.电止码 = kf.客房租金明细.Max(m => m.电止码);
                collectRent.气止码 = kf.客房租金明细.Max(m => m.气止码);                
                押金Label1.Enabled = false;//非首次收租，押金置灰。
                toolTip1.SetToolTip(tableLayoutPanel1, "非首次收租不涉及押金。");
            }
            collectRent.止付日期 = collectRent.起付日期.AddMonths(kf.支付月数).AddDays(-1);
            //当协议的期止并非刚好间隔支付月数时，协议期内最后一次收租的止付日期需要调整，再计算租金
            //----------wait。。。
            水始码Label1.Text = collectRent.水止码.ToString();
            电始码Label1.Text = collectRent.电止码.ToString();
            气始码Label1.Text = collectRent.气止码.ToString();
            CaculateSum(押金Label1.Enabled);

            Main.context.客房租金明细.AddObject(collectRent);//此操作后可实现外键同步
            客房租金明细BindingSource.DataSource = collectRent;
        }

        /// <summary>
        /// 计算合计应付金额
        /// </summary>
        /// <param name="isFirstTime">是否首次收租，首次收租要交押金</param>
        private void CaculateSum(bool isFirstTime)
        {
            decimal sum = 0.00M;
            sum += kf.月租金 * kf.支付月数;
            sum += kf.月宽带费 * kf.支付月数;
            sum += kf.月物业费 * kf.支付月数;
            sum += kf.月厨房费 * kf.支付月数;
            if (isFirstTime)
                sum += kf.押金;//首次收租要交押金
            //...........
            decimal temp= Helper.calculate水费(kf.源房.阶梯水价, ((decimal)collectRent.水止码 - Convert.ToDecimal(水始码Label1.Text)));
            lbl水费.Text = temp.ToString();
            sum += temp;

            temp = Helper.calculate电费(kf.源房.阶梯电价, ((decimal)collectRent.电止码 - Convert.ToDecimal(电始码Label1.Text)));
            lbl电费.Text = temp.ToString();
            sum += temp;

            temp = (decimal)kf.源房.气单价 * ((decimal)collectRent.气止码 - Convert.ToDecimal(气始码Label1.Text));
            lbl气费.Text = temp.ToString();
            sum += temp;
            collectRent.应付金额 = sum;
        }
        private void 客房收租Form_Load(object sender, EventArgs e)
        {
            kryptonHeader1.Values.Heading = kf.源房.房名;
            kryptonHeader1.Values.Description = kf.命名;
            BindingData();
        }

        private void 客房收租Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Main.context.ObjectStateManager.GetObjectStateEntry(collectRent).State == EntityState.Added)
                Main.context.客房租金明细.Detach(collectRent);
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            Rectangle r = e.CellBounds;

            using (Pen pen = new Pen(Color.DarkGray, 1))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                if (e.Row == (tableLayoutPanel1.RowCount - 1))
                    r.Height -= 1;

                if (e.Column == (tableLayoutPanel1.ColumnCount - 1))
                    r.Width -= 1;

                e.Graphics.DrawRectangle(pen, r);
            }

        }

        private void BtnSelectKF_Click(object sender, EventArgs e)
        {
            
            using (客房选择Form form = new 客房选择Form(客房筛选.客房收租))
            {
                var result = form.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (kf != form.selectedKF)
                    {
                        Main.context.客房租金明细.DeleteObject(collectRent);
                        kf = form.selectedKF;
                        kryptonHeader1.Values.Heading = kf.源房.房名;
                        kryptonHeader1.Values.Description = kf.命名;
                        BindingData();
                    }                    
                }
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
            CaculateSum(押金Label1.Enabled);
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
            if (Helper.saveData(collectRent, out msg))
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
    

    
    }
}
