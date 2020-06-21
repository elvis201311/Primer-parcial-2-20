using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Primer_Parcial_2_20.BLL;
using Primer_Parcial_2_20.DAL;
using Primer_Parcial_2_20.Entidades;
using PrimerParcial_E.BLL;

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
            var Articulos = ArticuloBLL.Buscar(Utilidades.ToInt(IdArticuloTextbox.Text));
            if (Articulos != null)
                this.Articulos =Articulos;
            else
                this.Articulos = new Articulos();

            this.DataContext = this.Articulos;
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = ArticuloBLL.Guardar(Articulos);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (ArticuloBLL.Eliminar(Utilidades.ToInt(IdArticuloTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

   
        public double add(double a, double b)
        {
            double c = a * b;
            return c;
        }
    
        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int a = int.Parse(ExistenciaTextBox.Text);
                int b = int.Parse(CostoTextBox.Text);
                int v = a * b;
                ValorInventarioTextBox.Text = Convert.ToString(v);
            }
            catch
            {

            }
        }
        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int a = int.Parse(ExistenciaTextBox.Text);
                int b = int.Parse(CostoTextBox.Text);
                int v = a * b;
                ValorInventarioTextBox.Text = Convert.ToString(v);
            }
            catch
            {

            }
        }

        private void ValorInventarioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int a = int.Parse(ExistenciaTextBox.Text);
                int b = int.Parse(CostoTextBox.Text);
                int v = a * b;
                ValorInventarioTextBox.Text = Convert.ToString(v);
            }
            catch
            {

            }
        }
    }
}