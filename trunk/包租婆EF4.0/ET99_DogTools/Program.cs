﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ET99_DogTools
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
            //Application.Run(new 加解密校验器());
        }
    }
}
