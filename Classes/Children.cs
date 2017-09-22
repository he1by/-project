using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Data_base
{
    /// <summary>
    /// Represents Children element from XML database
    /// </summary>
    class Children
    {
        public string FIO;
        public string Birthday;
        public string Adress;
        public string Conclusion="NONE";
        public string Protocol_Number="NONE";
        public string Transmission_date="NONE";
        public string Recomendations="NONE";
        public string Aducation="NONE";
        public string AducationIn="NONE";
        public string Note="NONE";
        public int _ID;

        public Children (string FIO, string Birthday, string Adress, string Conclusion, string Protocol_Number,
            string Transmission_date, string Recomendations, string Aducation, string AducationIn, string Note)
            {
            this.FIO = FIO;
            this.Birthday = Birthday;
            this.Adress = Adress;
            this.Conclusion = Conclusion;
            this.Protocol_Number = Protocol_Number;
            this.Transmission_date = Transmission_date;
            this.Recomendations = Recomendations;
            this.Aducation = Aducation;
            this.AducationIn = AducationIn;
            this.Note = Note;
            this._ID = FIO.GetHashCode() + Birthday.GetHashCode() + Protocol_Number.GetHashCode() + Adress.GetHashCode();
            }
    }
}
