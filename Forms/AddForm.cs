using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Data_base
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            ShowAducation();
        }

        #region Functions

        /// <summary>
        /// This method saved changes to xml file
        /// </summary>
        private void SaveChanges()
        {
            var stringIn = new StringBuilder();
            var stringFrom = new StringBuilder();
            foreach (object itemChecked in checkedListBoxAducationFrom.CheckedItems)
            {
                stringIn.Append(itemChecked.ToString());
                stringIn.Append("; ");
            }
            foreach (object itemChecked in checkedListBoxAducationIn.CheckedItems)
            {
                stringFrom.Append(itemChecked.ToString());
                stringFrom.Append("; ");
            }
            var childrenObject = new Children(textBoxFio.Text, textBoxLYear.Text + textBoxLMounth.Text + textBoxLNumber.Text,
                textBoxAdress.Text, textBoxConclusion.Text, textBoxProtocolNumber.Text, textBoxRYear.Text + textBoxRMount.Text +
                textBoxRNumber.Text, richTextBoxRek.Text, stringFrom.ToString(), stringIn.ToString(),
                richTextBoxPrim.Text);
            Cxml.WriteXmlFile(Application.StartupPath + "\\DateBase.txt", childrenObject);
        }

        /// <summary>
        /// This method validate fields
        /// </summary>
        /// <returns>int number with code of bad field</returns>
        private int Validate()
        {
            if (textBoxLYear.Text.Length != 4 || textBoxRYear.Text.Length != 4)
            {
                return 3;
            }
            if (textBoxFio.Text.Length == 0)
            {
                return 1;
            }
            if (textBoxAdress.Text.Length == 0)
            {
                return 2;
            }
            return 0;
        }

        /// <summary>
        /// This method show's in checkedlistbox value from xml 
        /// </summary>
        private void ShowAducation()
        {
            checkedListBoxAducationFrom.Items.Clear();
            checkedListBoxAducationIn.Items.Clear();
            XDocument doc = XDocument.Load(Application.StartupPath + "\\School.txt");
            if (doc != null)
            {
                var result = doc.Descendants("Aducation")
                        .Elements("School");
                foreach (var str in result)
                {
                    checkedListBoxAducationFrom.Items.Add(str.LastAttribute.Value.ToString());
                    checkedListBoxAducationIn.Items.Add(str.LastAttribute.Value.ToString());
                }
            }
        }
        #endregion



        #region OnClickFunctions

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var regexDayPattern = new Regex("^(0[1-9]|[1-2][0-9]|3[0-1])$");
            var regexMounthPattern = new Regex("^(0[1-9]|1[0-2])$");
            if (regexDayPattern.IsMatch(textBoxLNumber.Text)
                && regexDayPattern.IsMatch(textBoxRNumber.Text))
            {
                if (regexMounthPattern.IsMatch(textBoxLMounth.Text) && regexMounthPattern.IsMatch(textBoxRMount.Text))
                {
                    switch (Validate())
                    {
                        case 1:
                            MessageBox.Show("Заполните поле ФИО");
                            break;
                        case 2:
                            MessageBox.Show("Заполните поле адрес");
                            break;
                        case 3:
                            MessageBox.Show("Год должен содержать 4 знака");
                            break;
                        case 0:
                            SaveChanges();
                            this.Close();
                            break;
                    }
                }
                else MessageBox.Show("Месяц введён неверно");
            }
            else MessageBox.Show("Число введено неверно!");
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            var settingsMenu = new Forms.SettingsMenu();
            settingsMenu.ShowDialog();
            ShowAducation();
        }
    } 
    #endregion
}
