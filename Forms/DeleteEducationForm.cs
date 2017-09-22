using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Data_base.Forms
{
    public partial class DeleteEducationForm : Form
    {
        private  string _filePath = Application.StartupPath + "\\School.txt";

        public DeleteEducationForm()
        {
            InitializeComponent();
            ShowSchools();
        }


        private void ShowSchools()
        {
            var document = XDocument.Load(_filePath);
            var items = document.Descendants("Aducation")
                                 .Elements("School");
            checkedListBox.Items.Clear();
            foreach (var obj in items)
            {
                checkedListBox.Items.Add(obj.LastAttribute.Value.ToString());
            }
        }

        //TODO: rework this bad method
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var document = XDocument.Load(_filePath);
                foreach (object itemChecked in checkedListBox.CheckedItems)
                {
                    document.Descendants("Aducation")
                            .Elements("School")
                            .Where(xe => xe.LastAttribute.Value == itemChecked.ToString())
                            .Remove();
                }
                document.Save(_filePath);
                ShowSchools();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
