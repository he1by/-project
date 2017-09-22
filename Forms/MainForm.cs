using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Text;

namespace Data_base
{
    public partial class MainForm : Form
    {
        public static int Index;
        public static string ChangeTextValue;
        public static string LeftDate;
        public static string RightDate;
        public static bool Flag;
        public Form RefToMainForm { get; set; }
        private static string _searchValue;
        private static string _filePath = Application.StartupPath + "\\DateBase.txt";

        public MainForm()
        {
            InitializeComponent();
            var document = XDocument.Load(_filePath);
            var items = document.Descendants("Childrens")
                                 .Elements("Children"); 
            ShowTable(items);
        }

        #region Functions

        private void GetSelectFormForSearch()
        {
            if (dataGridViewMain.CurrentCell.ColumnIndex == 0 && dataGridViewMain.CurrentCell.ColumnIndex == 4
                && dataGridViewMain.CurrentCell.ColumnIndex == 7)
            {
                var textSearchFrom = new TextSearch();
                textSearchFrom.ShowDialog();
            }
            if (dataGridViewMain.CurrentCell.ColumnIndex == 1 && dataGridViewMain.CurrentCell.ColumnIndex == 5)
            {
                var dateSearchForm = new DateSearchForm();
                dateSearchForm.ShowDialog();
            }
            else MessageBox.Show("Выбирите ячейку для поиска");
        }

        private int GetSelectedCell()
        {
            var currentIndex = -1;
            if (dataGridViewMain.CurrentRow != null)
                return currentIndex = dataGridViewMain.CurrentRow.Index;
            else return -1;
        }

        private void ShowTable(IEnumerable<XElement> items)
        {
            try
            {
                if (items != null)
                {
                    dataGridViewMain.DataSource = null;
                    dataGridViewMain.Rows.Clear();
                    dataGridViewMain.Refresh();
                    dataGridViewMain.ColumnCount = 11;
                    dataGridViewMain.Columns[0].Name = "ФИО";
                    dataGridViewMain.Columns[1].Name = "Дата рождения";
                    dataGridViewMain.Columns[2].Name = "Адресс";
                    dataGridViewMain.Columns[3].Name = "Заключение";
                    dataGridViewMain.Columns[4].Name = "Номер протокола";
                    dataGridViewMain.Columns[5].Name = "Дата ";
                    dataGridViewMain.Columns[6].Name = "Рекомендации";
                    dataGridViewMain.Columns[7].Name = "Из какого УО прибыл";
                    dataGridViewMain.Columns[8].Name = "В какое УО направлен";
                    dataGridViewMain.Columns[9].Name = "Примечание";
                    dataGridViewMain.Columns[10].Name = "ID";
                    foreach (var rootElement in items)
                    {
                        string[] row = new string[] { rootElement.Element("FIO").Value,rootElement.Element("Birthday").Value.Substring(6,2)+"."+
                            rootElement.Element("Birthday").Value.Substring(4,2)+"."+rootElement.Element("Birthday").Value.Substring(0,4),
                            rootElement.Element("Adress").Value,rootElement.Element("Conclusion").Value,rootElement.Element("Protocol_number").Value,rootElement.Element("Transmission_date").Value.Substring(6,2)+"."+
                            rootElement.Element("Transmission_date").Value.Substring(4,2)+"."+rootElement.Element("Transmission_date").Value.Substring(0,4)
                          , rootElement.Element("Recomendations").Value, rootElement.Element("Aducation").Value,
                            rootElement.Element("AducationIn").Value, rootElement.Element("Note").Value,rootElement.LastAttribute.Value };
                        dataGridViewMain.Rows.Add(row);
                    }
                    dataGridViewMain.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else MessageBox.Show("Данные не найдены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static IEnumerable<XElement> DateSearch()
        {
            string name;
            if (_searchValue.Contains("Дата рождения"))
            {
                name = "Birthday";
            }
            else name = "Transmission_date";
            var doc = XDocument.Load(_filePath);
            var result = doc.Descendants("Childrens")
                    .Elements("Children")
                    .Where((n => Convert.ToInt32(n.Element(name).Value) >= Convert.ToInt32(LeftDate) &&
                    Convert.ToInt32(n.Element(name).Value) <= Convert.ToInt32(RightDate))
                     );
            return result;
        }

        private string GetSelectedColumnName(string headerTextValue)
        {
            switch (headerTextValue)
            {
                case "ФИО": return "FIO";
                case "Дата рождения": return "Birthday";
                case "Адресс": return "Adress";
                case "Заключение": return "Conclusion";
                case "Номер протокола": return "Protocol_number";
                case "Дата": return "Transmission_date";
                case "Рекомендации": return "Recomendations";
                case "Из какого УО прибыл": return "Aducation";
                case "В какое УО направлен": return "AducationIn";
                case "Примечание": return "Note";
            }
            return "";
        }

        private void SearchByTextAndColumn()
        {
            if (dataGridViewMain.CurrentCell != null && ChangeTextValue != null)
            {
                var columnName = GetSelectedColumnName(dataGridViewMain.Columns[Index].HeaderText.ToString());
                if (!columnName.Equals(""))
                {
                    var document = XDocument.Load(_filePath);
                    var elements = document.Descendants("Childrens")
                            .Elements("Children")
                            .Where(n => n.Element(columnName).Value.Contains(ChangeTextValue)
                             );
                    if (elements != null)
                    {
                        ShowTable(elements);
                    }
                    else MessageBox.Show("Ничего не найдено :(");
                    dataGridViewMain.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
        #endregion

        #region OnClickFuntions
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForm addFrom = new AddForm();
            addFrom.Show();
            var document = XDocument.Load(_filePath);
            var result = document.Descendants("Childrens")
                                 .Elements("Children");
            ShowTable(result);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridViewMain.CurrentCell != null)
                {
                    Index = dataGridViewMain.CurrentCell.ColumnIndex;
                    var name = GetSelectedColumnName(dataGridViewMain.Columns[Index].HeaderText.ToString());
                    var document = XDocument.Load(_filePath);
                    var elements = ((document.Element("Childrens")?.Elements("Children")).Where(
                        xe => xe.LastAttribute.Value.Equals(dataGridViewMain.Rows[GetSelectedCell()].Cells[10].Value))
                        );
                    foreach (var obj in elements)
                    {
                        obj.Remove();
                    }
                    document.Save(_filePath);
                    ShowTable(elements);
                }
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain.CurrentCell != null)
            {
                Index = dataGridViewMain.CurrentCell.ColumnIndex;
                var name = GetSelectedColumnName(dataGridViewMain.Columns[Index].HeaderText.ToString());
                if (name.Equals("Birthday") || name.Equals("Transmission_date"))
                {
                    DateChange obj = new DateChange();
                    obj.ShowDialog();
                }
                else
                {
                    var formChange = new FormChange();
                    formChange.ShowDialog();
                }
                name = GetSelectedColumnName(dataGridViewMain.Columns[Index].HeaderText.ToString());
                if (ChangeTextValue != null)
                {
                    var document = XDocument.Load(_filePath);
                    var elements = (from xe in document.Element("Childrens")?.Elements("Children")
                                    where xe.LastAttribute.Value.Equals(dataGridViewMain.Rows[GetSelectedCell()].Cells[10].Value)
                                    select xe);
                    foreach (var obj in elements)
                    {
                        obj.Element(name).SetValue(ChangeTextValue);
                    }
                    document.Save(_filePath);
                    var result = document.Descendants("Childrens")
                                         .Elements("Children");
                    ShowTable(result);
                    ChangeTextValue = null;
                }

            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //TODO: rework switch case coz it is terrable
            if (dataGridViewMain.CurrentCell != null)
            {
                Index = dataGridViewMain.CurrentCell.ColumnIndex;
                if (Index != -1)
                {
                    switch (Index)
                    {
                        case 0: { TextSearch form = new TextSearch(); form.ShowDialog(); SearchByTextAndColumn(); }; break;
                        case 1:
                            {
                                DateSearchForm form = new DateSearchForm(); _searchValue = dataGridViewMain.Columns[Index].HeaderText.ToString();
                                form.ShowDialog(); ShowTable(DateSearch());
                            }; break;
                        case 2: { TextSearch form = new TextSearch(); form.ShowDialog(); SearchByTextAndColumn(); }; break;
                        case 3: { TextSearch form = new TextSearch(); form.ShowDialog(); SearchByTextAndColumn(); }; break;
                        case 4: { TextSearch form = new TextSearch(); form.ShowDialog(); SearchByTextAndColumn(); }; break;
                        case 5:
                            {
                                DateSearchForm form = new DateSearchForm(); _searchValue = dataGridViewMain.Columns[Index].HeaderText.ToString();
                                form.ShowDialog(); ShowTable(DateSearch());
                            }; break;
                        case 6: { TextSearch form = new TextSearch(); form.ShowDialog(); SearchByTextAndColumn(); }; break;
                        case 7: { TextSearch form = new TextSearch(); form.ShowDialog(); SearchByTextAndColumn(); }; break;
                        case 8: { TextSearch form = new TextSearch(); form.ShowDialog(); SearchByTextAndColumn(); }; break;
                        case 9: { TextSearch form = new TextSearch(); form.ShowDialog(); SearchByTextAndColumn(); }; break;
                        case 10: MessageBox.Show("Рано или поздно скрою это поле, оно для того , что бы дети были уникальными"); break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Выделите ячейку для поиска!");
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            var document = XDocument.Load(_filePath);
            var elements = document.Descendants("Childrens")
                                 .Elements("Children");
            ShowTable(elements);
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dataGridViewMain.CurrentCell.Value.ToString());
        }
    } 
    #endregion

}

