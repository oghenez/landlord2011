using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Landlord2
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //MessageBox.Show("抄表中水电气始码，校验问题。2个问题");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //如果存在过往日志，清除。 
            //string path = Path.Combine(Directory.GetCurrentDirectory(),"Landlord2.log");
            //File.Delete(path);//删除指定的文件。如果指定的文件不存在，则不引发异常。 

            #region 加密狗判断
            //打开并进入加密狗
            string errMsg;
            if (!Helper.OpenDog(out errMsg))
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(errMsg, "错误",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }
            //软件到期判断
            double days = double.Parse( Helper.ReadOffsetDataAndDecrypt(388, 12));//到期天数            
            if (days != 0)//有日期限制才写狗
            {
                string beginDay = Helper.ReadOffsetDataAndDecrypt(424, 24);//起始时间
                if (string.IsNullOrEmpty(beginDay))//初次使用
                {
                    DateTime dogDay = DateTime.ParseExact(Helper.ReadOffsetDataAndDecrypt(400, 24), "yyyyMMddHHmmss", null);//加密狗生成时间
                    if (DateTime.Now < dogDay)
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("当前系统时间有误，请检查！", "错误",
                                           System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return;
                    }
                    beginDay = DateTime.Now.ToString("yyyyMMddHHmmss");//起始时间
                    string endDay = DateTime.Now.AddDays(days).ToString("yyyyMMddHHmmss");//结束时间
                    Helper.TempAdminWriteDog(beginDay, 424);// 临时获得管理员权限，写入数据到加密狗，然后返回到用户权限
                    Helper.TempAdminWriteDog(endDay, 448);
                }
                else//非初次使用
                {
                    DateTime begin = DateTime.ParseExact(beginDay, "yyyyMMddHHmmss", null);
                    DateTime end = DateTime.ParseExact(Helper.ReadOffsetDataAndDecrypt(448,24),"yyyyMMddHHmmss",null);
                    if (DateTime.Now < begin)
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("当前系统时间有误，请检查！", "错误",
                                           System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return;
                    }
                    else if (DateTime.Now > end)
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("此版本试用期截止，感谢您的试用！", "软件到期提醒",
                                                                  System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        //用当前时间覆盖‘起始时间’
                        beginDay = DateTime.Now.ToString("yyyyMMddHHmmss");
                        Helper.TempAdminWriteDog(beginDay, 424);
                    }
                }
            }
            #endregion

            AppRoot.Inital();//根对象初始化
            Application.Run(new Main());
            //Application.Run(new Landlord2.UI.提醒Form());
        }
    }
}
