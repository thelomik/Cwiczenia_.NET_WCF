using BiblioteczkaWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BiblioteczkaWCF
{
    [ServiceContract]
    public interface IKontekstBiblioteczki // wcześniej IService
    {
        [OperationContract]
        void Dodaj(string tytul, string autor, int iloscStron);
        [OperationContract]
        void Edytuj(int id, string tytul, string autor, int iloscStron);
        [OperationContract]
        void Usun(int id);
        [OperationContract]
        Ksiazka Pobierz(int id);
        [OperationContract]
        List<Ksiazka> PobierzWszystkie();
    }

}
