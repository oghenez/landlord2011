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
            //MessageBox.Show("装修明细过滤及合计");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //如果存在过往日志，清除。 
            //string path = Path.Combine(Directory.GetCurrentDirectory(),"Landlord2.log");
            //File.Delete(path);//删除指定的文件。如果指定的文件不存在，则不引发异常。 

            AppRoot.Inital();//根对象初始化
            Application.Run(new Main());
            //Application.Run(new Landlord2.UI.Form1());
        }
    }
}
