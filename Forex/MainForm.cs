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
using System.Xml;
using System.Threading;

namespace Forex
{
    public partial class MainForm : Form
    {
        private const String SOURCE_URL = @"http://www.dailyfx.com.hk/xml/us_price.xml";
        private List<Pair> data = null;
        private TechsForm techsForm = null;
        private System.Timers.Timer aTimer;
        public MainForm()
        {
            InitializeComponent();
            techsForm = new TechsForm();
            techsForm.Owner = this;
            techsForm.Show();
            techsForm.SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);

            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000 * 60;
            aTimer.Enabled = true;
            Thread t = new Thread(() =>
            {
                updateData();
                updateList();
            });
            t.IsBackground = true;
            t.Start();
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
            String dataString = Utils.GetHtml(SOURCE_URL, Encoding.UTF8);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(dataString);
            XmlNode root = doc.SelectSingleNode("Rates");
            XmlNodeList nodes = root.ChildNodes;
            foreach (XmlNode node in nodes)
            {
                p = new Pair();
                p.Symbol = node.Attributes[0].InnerText;
                foreach (XmlElement n in node.ChildNodes)
                {
                    switch (n.Name)
                    {
                        case "Bid":
                            p.Bid = float.Parse(n.InnerText);
                            break;
                        case "Ask":
                            p.Ask = float.Parse(n.InnerText);
                            break;
                        case "High":
                            p.High = float.Parse(n.InnerText);
                            break;
                        case "Low":
                            p.Low = float.Parse(n.InnerText);
                            break;
                        case "Direction":
                            p.Direction = int.Parse(n.InnerText);
                            break;
                        case "Last":
                            p.Last = DateTime.Parse(n.InnerText);
                            break;
                    }
                }
                data.Add(p);
            }
        }

        private void updateList()
        {
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
                lv = new ListViewItem(new string[] { p.Symbol,
                p.Bid.ToString(),p.Ask.ToString(),p.High.ToString(),
                p.Low.ToString(),p.Last.ToLongTimeString()});
                if (p.Direction == 1)
                {
                    lv.BackColor = Color.IndianRed;
                }
                else if (p.Direction == -1)
                {
                    lv.BackColor = Color.SpringGreen;
                }

                if ("GBPUSD".Equals(p.Symbol))
                {
                    lv.BackColor = Color.LightSteelBlue;
                }
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

        private void Form1_Move(object sender, EventArgs e)
        {
            if (techsForm.Visible)
            {
                techsForm.SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);
            }
        }

        private void ToolStripMenuItemUpdate_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                updateData();
                updateList();
            });
            t.IsBackground = true;
            t.Start();
        }

        private void ToolStripMenuItemChart_Click(object sender, EventArgs e)
        {
            String selected = listView1.SelectedItems[0].Text;
            new ChartForm(selected).Show();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ToolStripMenuItemChart_Click(sender, e);
        }
    }
}
