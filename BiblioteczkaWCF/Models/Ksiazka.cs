using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BiblioteczkaWCF.Models
{
    [DataContract]
    public class Ksiazka
    {
        private int id;
        [DataMember]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string tytul;

        [DataMember]
        public string Tytul
        {
            get { return tytul; }
            set { tytul = value; }
        }

        private string autor;
        [DataMember]
        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        private int iloscStron;

        [DataMember]
        public int IloscStron
        {
            get { return iloscStron; }
            set { iloscStron = value; }
        }

        public Ksiazka(int id, string tytul, string autor, int iloscStron)
        {
            this.id = id;
            this.tytul = tytul;
            this.autor = autor;
            this.iloscStron = iloscStron;
        }

        public override string ToString()
        {
            return string.Format("{0} - \"{1}\"", Autor, Tytul);
        }
    }

}
