using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_base
{
    public partial class TextSearch : Form
    {
        public TextSearch()
        {
            InitializeComponent();
        }

        #region OnClickFunctions
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (textBox.Text != null)
            {
                MainForm.ChangeTextValue = textBox.Text;
                this.Close();
            }
            else MessageBox.Show("Заполните строку поиска.");
        } 
        #endregion
    }
}
