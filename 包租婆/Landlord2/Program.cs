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
            MessageBox.Show("客房收租里，首次收租加上押金！首次收租不计算水电气！");
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
