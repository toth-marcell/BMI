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
                    string name = nameField.Text;
                    int age = int.Parse(ageField.Text.Trim());
                    double mass = double.Parse(massField.Text.Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);
                    double height = double.Parse(heightField.Text.Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture);
                    resultsTable.Items.Add(new Result(mass, height, name, age));
                }
                catch (Exception ex)
                {
                    if (ex is FormatException) MessageBox.Show("Számokat kell megadni a tömeg, magasság és kor mezőkbe!");
                    else throw ex;
                }
            }
        }
    }
    struct Result
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Mass { get; set; }
        public double Height { get; set; }
        public double BMI => Math.Round(Mass / Math.Pow(Height, 2), 2);
        public string Category
        {
            get
            {
                if (BMI < 18.5) return "sovány";
                if (BMI < 25) return "normál";
                if (BMI < 30) return "kicsit dagadt";
                if (BMI < 35) return "egészen dagadt";
                if (BMI < 35) return "nagyon dagadt";
                return "teljesen dagadt";
            }
        }
        public Result(double mass, double height, string name, int age)
        {
            Mass = mass;
            Height = height;
            Name = name;
            Age = age;
        }
    }
}
