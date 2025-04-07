using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

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
                    double mass = double.Parse(massField.Text.Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);
                    double height = double.Parse(heightField.Text.Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);
                    resultLabel.DataContext = Math.Round(mass / Math.Pow(height, 2), 2);
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
