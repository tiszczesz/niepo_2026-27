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

namespace cw1_wpf
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

        private void ShowDate(object sender, RoutedEventArgs e)
        {
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            Info.Content = date.ToString("yyyy-MM-dd");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}