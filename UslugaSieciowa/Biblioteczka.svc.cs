using BiblioteczkaWCF;
using BiblioteczkaWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UslugaSieciowa
{
    public class Biblioteczka : IKontekstBiblioteczki
    {
        private static KontekstBiblioteczki kontekst;
        public Biblioteczka()
        {
            if (kontekst == null)
                kontekst = new KontekstBiblioteczki();
        }
        public void Dodaj(string tytul, string autor, int iloscStron)
        {
            kontekst.Dodaj(tytul, autor, iloscStron);
        }

        public void Edytuj(int id, string tytul, string autor, int iloscStron)
        {
            kontekst.Edytuj(id, tytul, autor, iloscStron);
        }

        public Ksiazka Pobierz(int id)
        {
            return kontekst.Pobierz(id);
        }

        public List<Ksiazka> PobierzWszystkie()
        {
            return kontekst.PobierzWszystkie();
        }

        public void Usun(int id)
        {
            kontekst.Usun(id);
        }
    }
}
