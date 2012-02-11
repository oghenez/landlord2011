using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Landlord2.UI
{
    public partial class Map : FormBase
    {
        public Map()
        {
            InitializeComponent();
            toolStripProgressBar1.Visible = false;
        }

        private void Map_Load(object sender, EventArgs e)
        {
            if (Helper.IsConnectedToInternet())
            {
                webBrowser1.Url =
                    new Uri(
                        @"http://api.51ditu.com/iframe/newmapwindow.html?theme=darkslateblue&showetd=1&showovm=0&topic=p&showtools=1&showrgeo=1&zoom=3&city=wuhan");
            }
            else
            {
                string friendPage =
                    @"<HTML><HEAD><title>友好页面</title></HEAD><body><TABLE cellSpacing='1' cellPadding='1' width='404' align='center' border='1' style='BORDER-RIGHT:gray 1px solid;PADDING-RIGHT:3px;BORDER-TOP:gray 1px solid;PADDING-LEFT:3px;FONT-SIZE:9pt;PADDING-BOTTOM:3px;BORDER-LEFT:gray 1px solid;COLOR:black;PADDING-TOP:3px;BORDER-BOTTOM:gray 1px solid;FONT-FAMILY:宋体;BORDER-COLLAPSE:collapse;BACKGROUND-COLOR:#f7f7f7;TEXT-ALIGN:center'><TR><TD bgcolor='#f6f6f6'><b>页面没有任何内容显示</b></TD></TR><TR bgcolor='#ffffff'><TD align='left'><b>原因：</b><li>请检查当前是否处于联网状态！<li>地图数据庞大，必须从网络服务器实时下载！</TD></TR></TABLE></body></HTML>";
                webBrowser1.DocumentText = friendPage;
                webBrowser1.Navigating += webBrowser1_Navigating;
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            e.Cancel = true;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if ((e.CurrentProgress > 0) && (e.MaximumProgress > 0))
            {
                toolStripProgressBar1.Visible = true;
                long max = e.MaximumProgress;
                long cur = e.CurrentProgress;
                toolStripProgressBar1.Value = (int)(100 * cur / max); //得到进度百分比
                toolStripStatusLabel1.Text = string.Format("地图数据下载中...({0}%)",toolStripProgressBar1.Value);
            }
            else if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel1.Text = @"武汉创方科技有限公司";
            }
        }

        private void Map_FormClosing(object sender, FormClosingEventArgs e)
        {
            webBrowser1.Dispose();
        }
    }
}
