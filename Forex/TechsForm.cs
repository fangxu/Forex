using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Forex.Model;

namespace Forex
{
    public partial class TechsForm : Form
    {
        private const String TECHS_URL = @"http://www.dailyfx.com.hk/techs/index.html";
        List<TecItem> data;
        public TechsForm()
        {
            InitializeComponent();
            this.ControlBox = false;
            updateListView();
        }

        void updateListView()
        {
            String dataHtml = Utils.GetHtml(TECHS_URL, Encoding.UTF8);
            //String patten = @"class=""itemTime"">(\s\S*?)</li>\s\S*?;(\s\S*?);\s\S*?href=""(\s\S*?)"">(\s\S*?)</a>";
            String patten = @"class=""itemTime"">(\d\d/\d\d \d\d:\d\d)<[\s\S]*?&nbsp;([\s\S]*?)&" +
                @"[\s\S]*?href=""([\s\S]*?)"">([\s\S]*?)</a>";
            MatchCollection matches = Regex.Matches(dataHtml, patten, RegexOptions.Compiled);
            if (matches.Count < 1)
            {
                return;
            }
            data = new List<TecItem>();
            TecItem item;
            foreach (Match m in matches)
            {
                item = new TecItem();
                item.Time = DateTime.ParseExact(m.Groups[1].Value, "MM/dd HH:mm", null);
                item.Name = m.Groups[2].Value;
                item.Url = m.Groups[3].Value;
                item.Advice = m.Groups[4].Value;
                data.Add(item);
            }
            ListViewItem lv;
            listView1.BeginUpdate();
            foreach (TecItem ti in data)
            {
                lv = new ListViewItem(new string[] {ti.Name,ti.Time.ToShortTimeString(),
                    ti.Advice});
                if (ti.Name.Equals("英镑/美元"))
                {
                    lv.BackColor = Color.LightSkyBlue;
                }
                listView1.Items.Add(lv);
            }
            listView1.EndUpdate();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String selected = listView1.SelectedItems[0].Text;
            TecItem item = data.Find(it =>
            {
                if (it.Name.Equals(selected))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });

            new TechDetail(item.Url,item.Name).Show();
        }
    }
}
