using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Data_base
{
    public partial class DateChange : Form
    {
        public DateChange()
        {
            InitializeComponent();
        }
  
        private void buttonNext_Click(object sender, EventArgs e)
        {
            var regexDayPattern = new Regex("^(0[1-9]|[1-2][0-9]|3[0-1])$");
            var regexMounthPattern = new Regex("^(0[1-9]|1[0-2])$");
            if (regexDayPattern.IsMatch(textBoxDay.Text))
            {
                if (regexMounthPattern.IsMatch(textBoxMounth.Text))
                {
                    if (textBoxYear.Text.Length == 4)
                    {
                        MainForm.ChangeTextValue = textBoxYear.Text + textBoxMounth.Text + textBoxDay.Text;
                        this.Close();
                    }
                    else MessageBox.Show("Год введён неверно!");
                }
                else MessageBox.Show("Месяц введён неверно");
            }
            else MessageBox.Show("Число введено неверно!");
        }
    }
}