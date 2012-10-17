using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forex
{
    public partial class SelectForm : Form
    {
        private Dictionary<String, bool> selectPair = null;
        Form1 form1 = null;
        public SelectForm(Form1 f)
        {
            InitializeComponent();
            form1 = f;
            selectPair = form1.selectedPair;
            updateListBox();
        }

        private void updateListBox()
        {
            foreach (KeyValuePair<String, bool> kv in selectPair)
            {
                if (kv.Value)
                {
                    listBoxSelected.Items.Add(kv.Key);
                }
                else
                {
                    listBoxUnselected.Items.Add(kv.Key);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (String s in listBoxUnselected.SelectedItems)
            {
                //listBoxUnselected.Items.Remove(s);
                listBoxSelected.Items.Add(s);
            }
            while (listBoxUnselected.SelectedItems.Count > 0)
            {
                listBoxUnselected.Items.Remove(listBoxUnselected.SelectedItem);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (String s in listBoxSelected.SelectedItems)
            {
                //listBoxUnselected.Items.Remove(s);
                listBoxUnselected.Items.Add(s);
            }
            while (listBoxSelected.SelectedItems.Count > 0)
            {
                listBoxSelected.Items.Remove(listBoxSelected.SelectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (String s in listBoxUnselected.Items)
            {
                selectPair[s] = false;
            }
            foreach (String s in listBoxSelected.Items)
            {
                selectPair[s] = true;
            }
            this.Close();
        }
    }
}
