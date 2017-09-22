using Data_base;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Data_base
{
    /// <summary>
    /// Work with XML 
    /// </summary>
    internal static class Cxml
    {
        /// <summary>
        /// Create XML file if file not exists
        /// </summary>
        /// <param name="path">Path to file</param>
        public static void CreateXmlFile(string path)
        {
            if (!File.Exists(path))
            {
                var textWritter = new XmlTextWriter(path, Encoding.UTF8);
                textWritter.WriteStartDocument();
                textWritter.WriteStartElement("Childrens");
                textWritter.WriteEndElement();
                textWritter.Close();
            }
        }

        /// <summary>
        /// Write Children object to XML 
        /// </summary>
        /// <param name="path">Path to xml</param>
        /// <param name="childrenObject">Children object </param>
        public static void WriteXmlFile(string path, Children childrenObject)
        {
            var document = new XmlDocument();
            document.Load(path);
            var element = document.CreateElement("Children");
            document.DocumentElement?.AppendChild(element);
            var attribute = document.CreateAttribute("ID");
            attribute.Value = (childrenObject._ID.ToString());
            element.Attributes.Append(attribute);
            var subElement = new XmlNode[10];
            subElement[0] = document.CreateElement("FIO");
            subElement[0].InnerText = childrenObject.FIO; 
            subElement[1] = document.CreateElement("Birthday");
            subElement[1].InnerText = childrenObject.Birthday;
            subElement[2] = document.CreateElement("Adress");
            subElement[2].InnerText = childrenObject.Adress;
            subElement[3] = document.CreateElement("Conclusion");
            subElement[3].InnerText = childrenObject.Conclusion;
            subElement[4] = document.CreateElement("Protocol_number");
            subElement[4].InnerText = childrenObject.Protocol_Number;
            subElement[5] = document.CreateElement("Transmission_date");
            subElement[5].InnerText = childrenObject.Transmission_date;
            subElement[6] = document.CreateElement("Recomendations");
            subElement[6].InnerText = childrenObject.Recomendations;
            subElement[7] = document.CreateElement("Aducation");
            subElement[7].InnerText = childrenObject.Aducation;
            subElement[8] = document.CreateElement("AducationIn");
            subElement[8].InnerText = childrenObject.AducationIn;
            subElement[9] = document.CreateElement("Note");
            subElement[9].InnerText = childrenObject.Note;
            for (int i = 0; i <= 9; i++)
            {
                element.AppendChild(subElement[i]);
            }
            document.Save(path);
        }
    }
}
