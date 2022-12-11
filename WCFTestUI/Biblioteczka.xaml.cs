using BiblioteczkaService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WCFTestUI
{
    /// <summary>
    /// Interaction logic for Biblioteczka.xaml
    /// </summary>
    public partial class Biblioteczka : Window
    {
        public ObservableCollection<Ksiazka> Ksiazki { get; set; }
        public KontekstBiblioteczkiClient Klient { get; set; }
        public Biblioteczka()
        {
            InitializeComponent();
            Init();
        }

        public async void Init()
        {
            Klient = new();
            Ksiazki = new(await Klient.PobierzWszystkieAsync());
            KsiazkiDataGrid.DataContext = Ksiazki;
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            Dodaj dodaj = new();
            dodaj.Owner = GetWindow(this);
            dodaj.Show();
        }

        private void EdutujButton_Click(object sender, RoutedEventArgs e)
        {
            if (KsiazkiDataGrid.SelectedItem != null)
            {
                Ksiazka ksiazka = KsiazkiDataGrid.SelectedItem as Ksiazka;
                Edytuj edytuj = new(ksiazka.ID);
                edytuj.Owner = GetWindow(this);
                edytuj.Show();
            }
        }

        private async void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            if (KsiazkiDataGrid.SelectedItem != null)
            {
                Ksiazka ksiazka = KsiazkiDataGrid.SelectedItem as Ksiazka;
                var task = Klient.UsunAsync(ksiazka.ID);
                task.Wait();
                await OdswiezAsync();
            }
        }

        private async void PokazButton_Click(object sender, RoutedEventArgs e)
        {
            var list = await Klient.PobierzWszystkieAsync();
            Ksiazki = new(list.Where(x => x.IloscStron < 500));
            KsiazkiDataGrid.DataContext = Ksiazki;
        }

        private async void PokazWszystkieButton_Click(object sender, RoutedEventArgs e)
        {
            await OdswiezAsync();
        }

        public async Task OdswiezAsync()
        {
            Ksiazki = new(await Klient.PobierzWszystkieAsync());
            KsiazkiDataGrid.DataContext = Ksiazki;
        }
    }
}
