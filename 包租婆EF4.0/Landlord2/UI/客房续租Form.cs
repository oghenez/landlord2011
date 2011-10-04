using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Landlord2.Data;

namespace Landlord2.UI
{
    public partial class 客房续租Form : FormBase
    {
        private 客房 kf;        
        private 客房出租历史记录 history = new 客房出租历史记录();//构造一个新的【客房出租历史记录】对象，并赋值
        public 客房续租Form(Guid kfID)
        {
            InitializeComponent();
            uC客房详细1.tbKfName.ReadOnly = true;//客房名字不许更改
            uC客房详细1.tbKfName.StateCommon.Content.Color1 = Color.Red;
            this.kf = context.客房.FirstOrDefault(m => m.ID == kfID);
        }

        private void 客房续租Form_Load(object sender, EventArgs e)
        {
            BindingData();
        }

        private void BindingData()
        {
            uC客房详细1.客房BindingSource.DataSource = kf;
            kryptonHeader1.Values.Heading = kf.源房.房名;
            kryptonHeader1.Values.Description = kf.命名;

            //校验，看此客房是否可以【续租】（前提：进入此UI的，都为已租。）
            //协议到期;协议未到期，并且租户协议期内租金已全部收讫
            if (kf.期止 < DateTime.Now || 
                (kf.客房租金明细.Count > 0 && kf.客房租金明细.Max(m => m.止付日期.Date) >= kf.期止.Value.Date))
            {
                btnOK.Enabled = true;
                lblAlarm.Visible = false;

                //拷贝数据到新的【客房出租历史记录】对象
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
                history.状态 = "续租"; //续租状态下，转入历史记录的
                history.租户 = kf.租户;
                history.租赁协议照片1 = kf.租赁协议照片1;
                history.租赁协议照片2 = kf.租赁协议照片2;
                history.租赁协议照片3 = kf.租赁协议照片3;

                //调整新的期始、期止时间
                kf.期始 = history.期止.AddDays(1).Date;
                kf.期止 = null;//等待用户输入
            }
            else
            {
                btnOK.Enabled = false;
                lblAlarm.Visible = true;
            }
        }

        private void BtnSelectKF_Click(object sender, EventArgs e)
        {
            using (客房选择Form form = new 客房选择Form(context, 客房筛选.客房续租))
            {
                var result = form.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    kf = form.selectedKF;
                    BindingData();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            uC客房详细1.客房BindingSource.EndEdit();                  
            
            //特殊校验: 必须有租户，且租户姓名、身份证号必须和以前一致。
            if (kf.租户 != history.租户 || kf.身份证号 != history.身份证号)
            {
                KryptonMessageBox.Show("【续租】时，租户姓名、身份证号必须和之前协议相同。", "数据校验失败");
                return;
            }
            //协议时间必须连续
            if (kf.期始.Value.Date != history.期止.AddDays(1).Date)
            {
                KryptonMessageBox.Show("【续租】时，协议时间必须和之前协议时间连续。", "数据校验失败");
                return;
            }

            string check = kf.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }

            //此时加入新的【客房出租历史记录】对象
            context.客房出租历史记录.AddObject(history);

            string msg;
            if (Helper.saveData(context, kf, out msg))
            {
                KryptonMessageBox.Show(msg, "成功续租客房");
                if (this.Owner is Main)
                    (this.Owner as Main).RefreshAndLocateTree(kf);//刷新TreeView，并定位到kf节点。
                Close();
            }
            else
            {
                KryptonMessageBox.Show(msg, "失败");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}
