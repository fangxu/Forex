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

namespace Forex
{
    public partial class Form1 : Form
    {
        private const String SOURCE_URL = @"http://www.dailyfx.com.hk/xml/us_price.xml";
        private List<Pair> data = null;
        private TechsForm techsForm = null;
        //private List<String> selected = null;  
        private System.Timers.Timer aTimer;
        public Dictionary<String, bool> selectedPair = null;
        public Form1()
        {
            selectedPair = new Dictionary<string, bool>();
            InitializeComponent();
            techsForm = new TechsForm();
            techsForm.Owner = this;
            techsForm.Show();
            techsForm.SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);
            updateData();
            foreach (Pair p in data)
            {
                selectedPair.Add(p.Symbol, false);
            }
            //selectedPair["GBPUSD"] = true;
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000 * 30;
            aTimer.Enabled = true;
            updateList();
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
            XmlNodeList nodes = root.ChildNodes; //取得row下的子节点集合 
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
                //                 bool selected = true;
                //                 selectedPair.TryGetValue(p.Symbol, out selected);
                //                 if (!selected)
                //                 {
                //                     continue;
                //                 }
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

        //         private String getData()
        //         {
        //             String url = @"http://www.dailyfx.com.hk/xml/us_price.xml";
        //             return Utils.GetHtml(url);
        //         }

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

        private void Form1_Move(object sender, EventArgs e)
        {
            if (techsForm.Visible)
            {
                techsForm.SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);
            }
        }
    }
}
