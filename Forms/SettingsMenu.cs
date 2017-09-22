using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_base.Forms
{
    public partial class SettingsMenu : Form
    {
        public SettingsMenu()
        {
            InitializeComponent();
        }

        #region OnClickFunctions
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var addEducationForm = new AddEducationForm();
            addEducationForm.ShowDialog();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var deleteEducationForm = new DeleteEducationForm();
            deleteEducationForm.ShowDialog();
        }
    } 
    #endregion
}
