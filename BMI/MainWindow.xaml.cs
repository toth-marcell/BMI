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
                    double bmi = Math.Round(mass / Math.Pow(height, 2), 2);
                    resultLabel.DataContext = bmi;
                    categoryLabel.DataContext = BMICategory(bmi);
                }
                catch (Exception ex)
                {
                    if (ex is FormatException) MessageBox.Show("Számokat kell megadni!");
                    else throw ex;
                }
            }
        }
        string BMICategory(double bmi)
        {
            if (bmi < 18.5) return "sovány";
            if (bmi < 25) return "normál";
            if (bmi < 30) return "kicsit dagadt";
            if (bmi < 35) return "egészen dagadt";
            if (bmi < 35) return "nagyon dagadt";
            return "teljesen dagadt";
        }
    }
}
