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
    /// Interaction logic for TextBoxWithPlaceholder.xaml
    /// </summary>
    public partial class TextBoxWithPlaceholder : TextBox
    {
        public string Placeholder
        {
            get => _placeholder;
            set
            {
                _placeholder = value;
                TextBox_LostFocus(null, null);
            }
        }
        string _placeholder;
        public bool PlaceholderVisible { get; set; }
        public TextBoxWithPlaceholder()
        {
            InitializeComponent();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PlaceholderVisible)
            {
                Text = "";
                PlaceholderVisible = false;
            }
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Text == "")
            {
                Text = Placeholder;
                PlaceholderVisible = true;
            }
        }
    }
}
