using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Forex.Model;
using System.Text.RegularExpressions;
using System.Timers;

namespace Forex
{
    public partial class Form1 : Form
    {
        private List<Pair> data = null;
        //private List<String> selected = null;  
        private System.Timers.Timer aTimer;
        public Dictionary<String, bool> selectedPair = null;
        public Form1()
        {
            selectedPair = new Dictionary<string, bool>();
            InitializeComponent();
            updateData();
            foreach (Pair p in data)
            {
                selectedPair.Add(p.Symbol, false);
            }
            selectedPair["GBPUSD"] = true;
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            updateData();
            updateList();
        }
        private void updateData()
        {
            data = new List<Pair>();
            Pair p = null;
            String dataString = getData();
            /*******************  symbol        name         current      up  */
            String patten = @"\['([\s\S]*?)','([\s\S]*?)',([\s\S]*?),([\s\S]*?),";
            /**********  down        opening       highest      lowest  */
            patten += @"([\s\S]*?),([\s\S]*?),([\s\S]*?),([\s\S]*?),";
            /**********  amplitude        buy       sell         time  */
            patten += @"([\s\S]*?),'([\s\S]*?)','([\s\S]*?)','([\s\S]*?)']";
            MatchCollection matches = Regex.Matches(dataString, patten);
            foreach (Match m in matches)
            {
                p = new Pair();
                p.Symbol = m.Groups[1].ToString();
                p.Name = m.Groups[2].ToString();
                p.Current = float.Parse(m.Groups[3].ToString());
                p.Up = float.Parse(m.Groups[4].ToString());
                p.Down = float.Parse(m.Groups[5].ToString());
                p.Opening = float.Parse(m.Groups[6].ToString());
                p.Highest = float.Parse(m.Groups[7].ToString());
                p.Lowest = float.Parse(m.Groups[8].ToString());
                p.Amplitude = float.Parse(m.Groups[9].ToString());
                if (!m.Groups[10].ToString().Equals("--"))
                {
                    p.Buy = float.Parse(m.Groups[10].ToString());
                }
                if (!m.Groups[11].ToString().Equals("--"))
                {
                    p.Sell = float.Parse(m.Groups[11].ToString());
                }
                if (!m.Groups[12].ToString().Equals("0"))
                {
                    p.Time = DateTime.Parse(m.Groups[12].ToString());
                }
                data.Add(p);
            }
            
        }

        private void updateList()
        {
            if (selectedPair == null)
            {
                return;
            }
            
            ListViewItem lv;
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    listView1.Items.Clear();
                    listView1.BeginUpdate();
                }));
            }
            else
            {
                listView1.Items.Clear();
                listView1.BeginUpdate();
            }

            foreach (Pair p in data)
            {
                bool selected = true;
                selectedPair.TryGetValue(p.Symbol, out selected);
                if (!selected)
                {
                    continue;
                }
                lv = new ListViewItem(new string[] { p.Name+"/"+p.Symbol,
                p.Current.ToString(),p.Up.ToString(),p.Opening.ToString(),
                p.Highest.ToString(),p.Lowest.ToString(),p.Amplitude.ToString(),
                p.Buy+"/"+p.Sell,p.Time.ToLongTimeString()});
                /*if (listView1.Items.Count % 2 == 0)
                {
                    lv.BackColor = Color.FromArgb(0xccddff);
                }*/
                //lv.Font=
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        listView1.Items.Add(lv);
                    }));
                }
                else
                {
                    listView1.Items.Add(lv);
                }

            }
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    listView1.EndUpdate();
                }));
            }
            else
            {
                listView1.EndUpdate();
            }

        }

        private String getData()
        {
            String url = @"http://quote.forex.hexun.com/hqzx/restquote.aspx?type=3&time=" +
                DateTime.Now.ToString("HHmmss");
            return Utils.GetHtml(url);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            updateData();
            updateList();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SelectForm form2 = new SelectForm(this);
            //this.AddOwnedForm(form2);  
            form2.ShowDialog();
            updateData();
            updateList();
        }
    }
}
