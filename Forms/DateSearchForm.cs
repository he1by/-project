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
    public partial class DateSearchForm : Form
    {
        public DateSearchForm()
        {
            InitializeComponent();
        }

        #region OnClickFunctions
        private void buttonNext_Click(object sender, EventArgs e)
        {
            var regexDayPattern = new Regex("^(0[1-9]|[1-2][0-9]|3[0-1])$");
            var regexMounthPattern = new Regex("^(0[1-9]|1[0-2])$");
            if (regexDayPattern.IsMatch(tBoxLNumber.Text)
                && regexDayPattern.IsMatch(tBoxRNumber.Text))
            {
                if (regexMounthPattern.IsMatch(tBoxLMounth.Text)
                    && regexMounthPattern.IsMatch(tBoxRMounth.Text))
                {
                    MainForm.LeftDate = tBoxLYear.Text + tBoxLMounth.Text + tBoxLNumber.Text;
                    MainForm.RightDate = tBoxRYear.Text + tBoxRMounth.Text + tBoxRNumber.Text;
                    this.Close();
                }
                else MessageBox.Show("Месяц введён неверно");
            }
            else MessageBox.Show("Число введено неверно!");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainForm.Flag = false;
            this.Close();
        } 
        #endregion
    }
}
