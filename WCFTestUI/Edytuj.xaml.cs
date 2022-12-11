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
    /// Interaction logic for Edytuj.xaml
    /// </summary>
    public partial class Edytuj : Window
    {
        public KontekstBiblioteczkiClient Klient { get; set; }
        public Ksiazka Ksiazka { get; set; }
        private readonly int _id;
        public Edytuj(int id)
        {
            InitializeComponent();
            Klient = new();
            _id = id;
            Init();
        }

        private async Task Init()
        {
            var task = Klient.PobierzAsync(_id);
            task.Wait();
            Ksiazka = task.Result;
            IDTextBlock.Text = Ksiazka.ID.ToString();
            TytulTextBox.Text = Ksiazka.Tytul;
            AutorTextBox.Text = Ksiazka.Autor;
            IloscStronTextBox.Text = Ksiazka.IloscStron.ToString();
        }

        private void EdytujButton_Click(object sender, RoutedEventArgs e)
        {
            var task = Klient.EdytujAsync(_id, TytulTextBox.Text, AutorTextBox.Text, int.Parse(IloscStronTextBox.Text));
            task.Wait();
            OdswiezAsync();
            Close();
        }

        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async Task OdswiezAsync()
        {
            await (Owner as Biblioteczka)!.OdswiezAsync();
        }
    }
}
