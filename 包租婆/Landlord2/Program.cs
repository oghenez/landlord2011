﻿using System;
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
            //MessageBox.Show("暂时先省略非空属性的校验！待测试");
            //MessageBox.Show("源房Form，注意因为每个窗体有context，不要传实体引用，传ID值");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //如果存在过往日志，清除。 
            //string path = Path.Combine(Directory.GetCurrentDirectory(),"log.txt");
            //File.Delete(path);//删除指定的文件。如果指定的文件不存在，则不引发异常。 

            AppRoot.Inital();//根对象初始化
            Application.Run(new Main());
            //Application.Run(new Landlord2.UI.testForm());
        }
    }
}
