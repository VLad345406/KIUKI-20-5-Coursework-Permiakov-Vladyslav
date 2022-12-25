using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CourseworkWinForms
{
    public partial class Form1 : Form
    {
        List<Applications> apps = new List<Applications>();
        public Form1()
        {
            InitializeComponent();   
            loadApplicationList();
        }

        private void listViewApplications_DoubleClick(object sender, EventArgs e)
        {
            int index = listViewApplications.SelectedIndices[0];
            Process proc = new Process();
            proc.StartInfo.FileName = apps[index].path + "\\" + apps[index].name;
            try
            {
                proc.Start();
            }
            catch
            {
                MessageBox.Show("Помилка при запуску!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reloadListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadApplicationList();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxFindApp_TextChanged(object sender, EventArgs e)
        {
            ListViewItem foutItem = listViewApplications.FindItemWithText(textBoxFindApp.Text, false, 0, true);
            if (foutItem != null)
                listViewApplications.TopItem = foutItem;
        }

    }
}
