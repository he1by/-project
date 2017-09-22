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
    public partial class FormChange : Form
    {
        public FormChange()
        {
            InitializeComponent();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            MainForm.ChangeTextValue = richTextBoxValue.Text;
            this.Close();
        }
    }
}
