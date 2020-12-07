using Superheroes;
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

namespace Superheroes_Triggers
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Superheroe> listaSuperheroes;

        public MainWindow()
        {
            InitializeComponent();

            listaSuperheroes = Superheroe.GetSamples();
            superheroeDockPanel.DataContext = listaSuperheroes.FirstOrDefault();
            actualTextBlock.Text = "1";
            totalTextBlock.Text = listaSuperheroes.Count.ToString();
        }

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            listaSuperheroes.Add((Superheroe)this.Resources["nuevo"]);
            MessageBox.Show("Superhéroe insertado con exito", "Superhéroes", MessageBoxButton.OK, MessageBoxImage.Information);
            totalTextBlock.Text = listaSuperheroes.Count.ToString();

            ReiniciarSuperHeroe();
        }

        private void leftImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int actual = Int32.Parse(actualTextBlock.Text);

            if (actual > 1)
            {
                superheroeDockPanel.DataContext = listaSuperheroes[actual - 2];
                actualTextBlock.Text = (actual - 1).ToString();
            }
        }

        private void rightImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int actual = Int32.Parse(actualTextBlock.Text);

            if (actual < listaSuperheroes.Count)
            {
                superheroeDockPanel.DataContext = listaSuperheroes[actual];
                actualTextBlock.Text = (actual + 1).ToString();
            }
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            ReiniciarSuperHeroe();
        }

        private void ReiniciarSuperHeroe()
        {
            this.Resources.Remove("nuevo");
            this.Resources.Add("nuevo", new Superheroe() { Heroe = true });
        }
    }

}
