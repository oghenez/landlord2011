using System;
using System.Data;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Landlord2.Data;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.UI
{
    public partial class 客房Form : FormBase
    {
        private 客房 kf;
        private Guid yfID;//客房隶属的源房id
        private bool isNew;//是否新增操作

        public 客房Form()
        {
            InitializeComponent();
            isNew = true;
        }
        public 客房Form(客房 kf)
        {
            InitializeComponent();
            isNew = false;
            this.kf = context.客房.FirstOrDefault(m=>m.ID == kf.ID);
        }

        public 客房Form(Guid yfGuid)
        {
            InitializeComponent();
            isNew = true;
            this.yfID = yfGuid;
        }

        private void kfForm_Load(object sender, EventArgs e)
        {
            Text = string.Format("{0}客房",isNew? "新增":"编辑");
            源房BindingSource.DataSource = 源房.GetYF(context).Execute(MergeOption.AppendOnly); 

            if (isNew)//新增
            {
                BtnOkAndContinue.Visible = true;//保存并继续按钮可见
                kf = new 客房();
                kf.源房ID = this.yfID;
                cmbYF.SelectedValue = this.yfID;
                context.客房.AddObject(kf);//此操作后可实现外键同步
            }
            else//编辑
            {
                cmbYF.SelectedValue = kf.源房ID;

                //如果存在交租记录，那么不允许编辑水电气始码
                if (kf.客房租金明细.Count > 0)
                {
                    uC客房详细1.tbKF水始码.Enabled = false;
                    uC客房详细1.tbKF电始码.Enabled = false;
                    uC客房详细1.tbKF气始码.Enabled = false;
                }
            }
            uC客房详细1.客房BindingSource.DataSource = kf;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            uC客房详细1.客房BindingSource.EndEdit();

            string check = kf.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }
            if (isNew)//新增
            {
                
                string msg;
                if (Helper.saveData(context, kf, out msg))
                {
                    KryptonMessageBox.Show(msg, "成功新增客房");
                    if (this.Owner is Main)
                        (this.Owner as Main).RefreshAndLocateTree(kf);//刷新TreeView，并定位到kf节点。
                    Close();
                }
                else
                {
                    KryptonMessageBox.Show(msg, "失败");
                }
            }
            else//编辑
            {                
                if (context.ObjectStateManager.GetObjectStateEntry(kf).State == EntityState.Unchanged)
                {
                    Close(); //如果编辑状态下，未做任何修改，则直接退出
                }
                else
                {
                    //-----如果客房租户名或身份证变更，那么需同时更改[客房出租历史记录]里相关项。（判断同一个租户的关键依据<租户有可能同名同姓>）----------
                    var kfModifies = context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified).First(m=>m.Entity.Equals(kf));
                    string origin租户 = null;
                    string origin身份证号 = null;
                    if (kfModifies.GetModifiedProperties().Contains("租户"))
                        origin租户 = kfModifies.OriginalValues["租户"].ToString();
                    if (kfModifies.GetModifiedProperties().Contains("身份证号"))
                        origin身份证号 = kfModifies.OriginalValues["身份证号"].ToString();
                    if (origin租户 != null || origin身份证号 != null)//客房租户名或身份证有变动
                    {
                        if (origin租户 == null) //租户未更改
                            origin租户 = kf.租户;
                        if (origin身份证号 == null) //身份证号未更改
                            origin身份证号 = kf.身份证号;
                        //通过origin值查询历史记录，看有无此租户对应记录
                        foreach (var history in kf.客房出租历史记录.Where(m => m.租户 == origin租户 && m.身份证号 == origin身份证号))
                        {
                            history.身份证号 = kf.身份证号;
                            history.租户 = kf.租户;
                        }
                    }
                                        
                    string msg;
                    if (Helper.saveData(context, kf, out msg))
                    {
                        KryptonMessageBox.Show(msg, "成功编辑客房");
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
        private void BtnOkAndContinue_Click(object sender, EventArgs e)
        {
            uC客房详细1.客房BindingSource.EndEdit();

            string check = kf.CheckRules();
            if (!string.IsNullOrEmpty(check))
            {
                KryptonMessageBox.Show(check, "数据校验失败");
                return;
            }

#if DEBUG
            System.Diagnostics.Debug.Assert(isNew);//只有新增状态才有此按钮
#endif

            string msg;
            if (Helper.saveData(context, kf, out msg))
            {
                KryptonMessageBox.Show(string.Format("成功新增客房[{0}]。您可以继续添加客房！", kf.命名), "成功新增客房");
                if (this.Owner is Main)
                    (this.Owner as Main).RefreshAndLocateTree(kf);//刷新TreeView，并定位到kf节点。
                客房 old = kf;
                kf = new 客房()
                {
                    面积 = old.面积,
                    含厨房 = old.含厨房,
                    含卫生间 = old.含卫生间,
                    源房ID = old.源房ID,
                    押金 = old.押金,
                    月租金 = old.月租金,
                    支付月数 = old.支付月数,
                    水始码 = old.水始码,
                    电始码 = old.电始码,
                    气始码 = old.气始码,
                    月宽带费 = old.月宽带费,
                    月物业费 = old.月物业费,
                    月厨房费 = old.月厨房费,
                    备注 = old.备注
                };
                context.客房.AddObject(kf);//此操作后可实现外键同步

                uC客房详细1.客房BindingSource.DataSource = kf;
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

        private void cmbYF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbYF.SelectedValue != null)
                kf.源房ID = (Guid)cmbYF.SelectedValue;
        }


    }
}
