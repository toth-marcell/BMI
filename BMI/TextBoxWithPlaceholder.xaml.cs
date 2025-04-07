using System.Windows;
using System.Windows.Controls;

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
