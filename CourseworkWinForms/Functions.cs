using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseworkWinForms
{
    public partial class Form1
    {
        public void loadApplicationList()
        {
            apps = GetApplications();
            listViewApplications.Items.Clear();
            List<ListViewItem> newListItem = new List<ListViewItem>();
            for (int i = 0; i < apps.Count; i++)
            {
                string row = "";
                for (int j = 0; j < apps[i].name.Length; j++)
                {
                    if (apps[i].name[j] == '.' && apps[i].name[j + 1] == 'l' && apps[i].name[j + 2] == 'n' && apps[i].name[j + 3] == 'k')
                        break;
                    row += apps[i].name[j];
                }
                listViewApplications.Items.Add(new ListViewItem(row));
            }
        }
    }
}
