using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace Forex
{
    public partial class TechDetail : Form
    {
        private String detailUrl;
        public TechDetail(String url,String title)
        {
            InitializeComponent();
            this.Text = title;
            //http://www.dailyfx.com.hk/techs/xagusd.html
            this.detailUrl = @"http://www.dailyfx.com.hk/techs/" + url;
            webBrowser1.DocumentText = @"<h1>正在加载。。。</h1>";
            updateHtml(detailUrl);
        }

        private void updateHtml(string url)
        {
            Thread t = new Thread(() =>
            {
                String html = getDetailHtml(url);
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    webBrowser1.DocumentText = html;
                }));
            });
            t.IsBackground = true;
            t.Start();
        }

        private String getDetailHtml(String url)
        {
            String html = Utils.GetHtml(url, Encoding.UTF8);
            Match m = Regex.Match(html, @"<div class=""content"">([\s\S]*?)<script[\s\S]*?(<table[\s\S]*?</table>)");
            String table = m.Groups[2].Value.Replace(@"border=""0""", @"border=""1""");

            //http://www.dailyfx.com.hk/ext/dfx.css
            return m.Groups[1].ToString() + "<hr>" + table;
        }
    }
}
