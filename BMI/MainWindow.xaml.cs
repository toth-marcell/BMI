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

namespace BMI
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
        private void calculate(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    double mass = double.Parse(massField.Text);
                    double height = double.Parse(heightField.Text);
                    resultLabel.DataContext = mass / Math.Pow(height, 2);
                }
                catch (Exception ex)
                {
                    if (ex is FormatException) MessageBox.Show("Számokat kell megadni!");
                    else throw ex;
                }
            }
        }
    }
}
