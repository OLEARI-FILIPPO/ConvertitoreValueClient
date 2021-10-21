using ServiceReference1;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConvertitoreValueClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServiceClient serviceClient = new ServiceClient();
            string da = ((Valuta)(DaValuta.SelectedItem)).Sigla;
            string a = ((Valuta)(AValuta.SelectedItem)).Sigla;

            double valore = serviceClient.Converti(double.Parse(Importo.Text), da, a);
            Conversione.Content = valore;

            List<Valuta> Valute = new List<Valuta>();
            Valute.AddRange(serviceClient.getValute());

            ValoreTasso.Content = "1 " + da + " = " + 
                                    Math.Round((double.Parse(Importo.Text) / valore), 1, MidpointRounding.ToEven) + " " + a;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ServiceClient serviceClient = new ServiceClient();

            List<Valuta> Valute = new List<Valuta>();
            Valute.AddRange(serviceClient.getValute());

            AValuta.ItemsSource = Valute;
            AValuta.DisplayMemberPath = "Nome";

            DaValuta.ItemsSource = Valute;
            DaValuta.DisplayMemberPath = "Nome";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
