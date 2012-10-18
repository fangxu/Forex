using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Forex
{
    public partial class ChartForm : Form
    {
        private String pair;
        private const string CHART_URL = @"http://www.dailyfx.com.hk/exchange/chart.php?pair=";
        public ChartForm(String pair)
        {
            InitializeComponent();
            this.pair = pair;
            this.Text = pair + " - 正在加载，请稍后。。。";      
            updateImages();            
        }

        private void updateImages()
        {
            Thread t = new Thread(() =>
            {
                //http://rates.fxcm.com/PriceShort?s=USDJPY&page=rates_a&period=short
                Image shortChart = Utils.getImage(@"http://rates.fxcm.com/PriceShort?s="
                    + pair + @"&page=rates_a&period=short");
                //http://rates.fxcm.com/PriceLong?s=USDJPY&page=rates_a&period=long
                Image longChart = Utils.getImage(@"http://rates.fxcm.com/PriceLong?s="
                    + pair + @"&page=rates_a&period=long");
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    //webBrowser1.DocumentText = html;
                    pictureBoxShort.Image = shortChart;
                    pictureBoxLong.Image = longChart;
                    this.Text = pair;
                }));
            });
            t.IsBackground = true;
            t.Start();
        }        
    }
}
