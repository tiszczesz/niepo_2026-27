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

namespace cw7_wpf
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

        private void GenerNumbers(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = Convert.ToInt32(Count.Text);
                if(count<=0)
                {
                    MessageBox.Show("Liczba musi być większa od zera");
                    return;
                }

                List<int> numbersInts = new List<int>();
                //wypełnianie listy liczbami losowymi
                //Obiekt klasy Random służy do generowania liczb losowych
                Random rnd = new Random();
                for (int i = 0; i < count; i++)
                {
                    numbersInts.Add(rnd.Next(100));
                }
                //czyszczenie listy i przypisanie jej nowej zawartości
                List.ItemsSource = null;
                List.ItemsSource = numbersInts;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Błedna liczba: ");
            }
            
        }
    }
}