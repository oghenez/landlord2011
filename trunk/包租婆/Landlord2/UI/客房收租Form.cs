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
        private 客房 kf;
        private 客房租金明细 collectRent;
        public 客房收租Form(客房 kf)
        {
            InitializeComponent();
            this.kf = kf;            
        }

        private void BindingData()
        {
            客房BindingSource.DataSource = kf;
            List<客房租金明细> orderedList = kf.客房租金明细.OrderByDescending(m => m.起付日期).ToList();
            参考历史BindingSource.DataSource = orderedList;

            //新对象，根据情况赋予初始值
            collectRent = new 客房租金明细();
            collectRent.付款人 = kf.租户;
            collectRent.客房ID = kf.ID;
            //新对象的‘起付时间’与之前的‘止付时间’连续
            if (orderedList.Count == 0)//改租户第一次交租
            {
                collectRent.起付日期 = kf.期始.Value.AddDays(1).Date;
                collectRent.水止码 = kf.水始码;//止码设置为始码值，相当于没有用
                collectRent.电止码 = kf.电始码;
                collectRent.气止码 = kf.气始码;
            }
            else
            {
                collectRent.起付日期 = kf.客房租金明细.Max(m => m.止付日期).AddDays(1).Date;
                collectRent.水止码 = kf.客房租金明细.Max(m => m.水止码);//止码设置为始码值，相当于没有用
                collectRent.电止码 = kf.客房租金明细.Max(m => m.电止码);
                collectRent.气止码 = kf.客房租金明细.Max(m => m.气止码);
            }
            collectRent.止付日期 = collectRent.起付日期.AddMonths(kf.支付月数).AddDays(-1);
            水始码Label1.Text = collectRent.水止码.ToString();
            电始码Label1.Text = collectRent.电止码.ToString();
            气始码Label1.Text = collectRent.气止码.ToString();
            CaculateSum();

            Main.context.客房租金明细.AddObject(collectRent);
            客房租金明细BindingSource.DataSource = collectRent;
        }

        //计算合计应付金额
        private void CaculateSum()
        {
            decimal sum = 0.00M;
            sum += kf.月租金 * kf.支付月数;
            sum += kf.月宽带费 * kf.支付月数;
            sum += kf.月物业费 * kf.支付月数;
            sum += kf.月厨房费 * kf.支付月数;
            //...........
            decimal temp= Helper.calculate水费(kf.源房.阶梯水价, ((decimal)collectRent.水止码 - Convert.ToDecimal(水始码Label1.Text)));
            lbl水费.Text = temp.ToString();
            sum += temp;

            temp = Helper.calculate电费(kf.源房.阶梯电价, ((decimal)collectRent.电止码 - Convert.ToDecimal(电始码Label1.Text)));
            lbl电费.Text = temp.ToString();
            sum += temp;

            temp = (decimal)kf.源房.气单价 * ((decimal)collectRent.气止码 - Convert.ToDecimal(气始码Label1.Text));
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
            Main.context.客房租金明细.DeleteObject(collectRent);
            using (客房选择Form form = new 客房选择Form(客房筛选.客房收租))
            {
                var result = form.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    kf = form.selectedKF;
                    kryptonHeader1.Values.Heading = kf.源房.房名;
                    kryptonHeader1.Values.Description = kf.命名;
                }
            } 
            BindingData();
        }

        private void kryptonNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    

    
    }
}
