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
            MessageBox.Show("BindingSource_CurrentItemChanged 调用次数过多");
            //MessageBox.Show("当协议的期止并非刚好间隔支付月数时，协议期内最后一次收租的止付日期需要调整，再计算租金！");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //如果存在过往日志，清除。 
            //string path = Path.Combine(Directory.GetCurrentDirectory(),"log.txt");
            //File.Delete(path);//删除指定的文件。如果指定的文件不存在，则不引发异常。 

            Application.Run(new Main());
            //Application.Run(new Landlord2.UI.testForm());
        }
    }
}
