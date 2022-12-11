using BiblioteczkaWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BiblioteczkaWCF
{
    public class KontekstBiblioteczki : IKontekstBiblioteczki
    {
        private List<Ksiazka> kolekcjaKsiazek;
        public KontekstBiblioteczki()
        {
            kolekcjaKsiazek = new List<Ksiazka>();
            ZaladujDane();
        }
        private void ZaladujDane()
        {
            Dodaj("Pan Tadeusz", "Adam Mickiewicz", 800);
            Dodaj("Agile. Programowanie zwinne", "Robert C. Martin", 700);
            Dodaj("Czysty kod", "Robert C. Martin", 400);
        }

        public void Dodaj(string tytul, string autor, int iloscStron)
        {
            int id = kolekcjaKsiazek.Count + 1;
            kolekcjaKsiazek.Add(new Ksiazka(id, tytul, autor, iloscStron));
        }

        public void Edytuj(int id, string tytul, string autor, int iloscStron)
        {
            Ksiazka ks = Pobierz(id);
            ks.Tytul = tytul;
            ks.Autor = autor;
            ks.IloscStron = iloscStron;
        }

        public void Usun(int id)
        {
            Ksiazka ks = Pobierz(id);
            if (ks != null)
                kolekcjaKsiazek.Remove(ks);
        }

        public Ksiazka Pobierz(int id)
        {
            var ksiazka = (from k in kolekcjaKsiazek where k.ID == id select k).FirstOrDefault();
            return ksiazka;
        }

        public List<Ksiazka> PobierzWszystkie()
        {
            return kolekcjaKsiazek;
        }

    }
}
