using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Data_base.Forms
{
    public partial class AddEducationForm : Form
    {
        public AddEducationForm()
        {
            InitializeComponent();
        }

        public static void CreateXmlFile(string pathToXml)
        {
            if (!File.Exists(pathToXml))
            {
                XmlTextWriter textWritter = new XmlTextWriter(pathToXml, Encoding.UTF8);
                textWritter.WriteStartDocument();
                textWritter.WriteStartElement("Aducation");
                textWritter.WriteEndElement();
                textWritter.Close();
            }
        }

        public static void writeToDocument(string pathToXml,string value) {
            XmlDocument document = new XmlDocument();
            document.Load(pathToXml);
            XmlNode element = document.CreateElement("School");
            document.DocumentElement?.AppendChild(element); 
            XmlAttribute atr = document.CreateAttribute("Number");
            atr.Value = (value);
            element.Attributes.Append(atr);
            document.Save(pathToXml);
        }


        #region OnClickFunctions
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Length != 0)
            {
                writeToDocument((Application.StartupPath + "\\School.txt"), textBox.Text);
                this.Close();
            }
            else MessageBox.Show("Введите значение!");
        } 
        #endregion
    }
}
