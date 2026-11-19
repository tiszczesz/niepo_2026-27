using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zad2
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

        private void btn_Run(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstname = this.firstname.Text.Trim();
                string lastname = this.lastname.Text.Trim();
                int age = Convert.ToInt32(this.age.Text);
                string ageResult = age >= 18 ? "jest pełnoletni" : "nie jest pełnoletni";
                Result.Content = $"Imię: {firstname} nazwisko: {lastname} {ageResult}";
                if(firstname.Length==0 || lastname.Length==0 || age <= 0)
                {
                    MessageBox.Show(
                        "Wszystkie pola muszą być wypełnione i wiek musi być liczbą dodatnią.");
                }
            }
            catch (FormatException exception)
            {
                MessageBox.Show($"Błąd formatu danych: {exception.Message}");
            }
           
        }
    }
}