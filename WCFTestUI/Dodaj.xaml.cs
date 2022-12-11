using BiblioteczkaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Dodaj.xaml
    /// </summary>
    public partial class Dodaj : Window
    {
        public KontekstBiblioteczkiClient Klient { get; set; }
        public Dodaj()
        {
            InitializeComponent();
            // Przykład wykozystania metody anonimowej
            AnulujButton.Click += delegate (object sender, RoutedEventArgs e)
            {
                Close();
            };
            Klient = new();
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            var task = Klient.DodajAsync(TytulTextBox.Text, AutorTextBox.Text, int.Parse(IloscStronTextBox.Text));
            task.Wait();
            OdswiezAsync();
            Close();
        }

        private async Task OdswiezAsync()
        {
            await (Owner as Biblioteczka)!.OdswiezAsync();
        }

        //private void AnulujButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Close();
        //}

    }
}
