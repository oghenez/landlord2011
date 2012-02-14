using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using Ionic.Zip;
using System.IO;

namespace Landlord2.UI
{
    public enum WebFormCategory
    {
        网上银行,
        生活助手,
        租赁网站
    }
    public partial class WebForm : FormBase
    {
        private WebFormCategory category;
        private string tempDir = string.Empty ;

        public WebForm(WebFormCategory category)
        {
            InitializeComponent();
            this.category = category;
            Text = category.ToString();
        }

        private void WebForm_Load(object sender, EventArgs e)
        {
            switch (category)
            {
                case WebFormCategory.生活助手:
                    //GetWebContent(Properties.Resources.Bank);
                    break;
                case WebFormCategory.网上银行:
                    GetWebContent(Properties.Resources.Bank);
                    break;
                case WebFormCategory.租赁网站:
                    //GetWebContent(Properties.Resources.Bank);
                    break;
                default:
                    break;
            }
            if(!string.IsNullOrEmpty(tempDir))
                webBrowser1.Navigate("file:///" + System.IO.Path.Combine(tempDir, "Default.Html"));
        }

        /// <summary>
        /// 从资源文件中临时生成文件（此文件为zip压缩文件，html及jpg等），调用Ionic.zip.dll解压至临时目录，然后加载进web控件中。
        /// </summary>
        /// <param name="PropertyResource">针对的资源文件</param>
        private void GetWebContent(byte[] PropertyResource)
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(new MemoryStream(PropertyResource)))
                {
                    tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                    zip.ExtractAll(tempDir, ExtractExistingFileAction.OverwriteSilently);
                }
            }
            catch (Exception)
            {
                tempDir = string.Empty;
            }
        }

        private void WebForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Directory.Exists(tempDir))
                Directory.Delete(tempDir,true);//关闭窗体时，删除临时生成的文件
        }
    }
}
