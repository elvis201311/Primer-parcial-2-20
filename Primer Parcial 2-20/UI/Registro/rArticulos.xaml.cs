using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Primer_Parcial_2_20.BLL;
using Primer_Parcial_2_20.Entidades;

namespace Primer_Parcial_2_20.UI.Registro
{
    /// <summary>
    /// Interaction logic for rArticulos.xaml
    /// </summary>
    public partial class rArticulos : Window
    {
        private Articulos Articulos = new Articulos();
        public rArticulos()
        {
            InitializeComponent();
            this.DataContext = Articulos;
        }
        
        private void Limpiar()
        {
            this.Articulos = new Articulos();
            this.DataContext = Articulos;
        }
        
        private bool Validar()
        {
            bool Validado = true;
            if (IdArticuloTextbox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return Validado;
        }
       
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

        }
       
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

        }
      
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

        }
       
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}