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

namespace cw6_wpf
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
            //MessageBox.Show("Ala ma kota");
            showLabel.Content = DateTime.Now.ToShortDateString();
        }

        private void ShowTime(object sender, RoutedEventArgs e)
        {
            showTime.Content = DateTime.Now.ToLongTimeString();
        }

        //private Color generColor()
        //{
        //    //string aa = "FF";
        //    string rr = Convert.ToString(new Random().Next(0, 256), 16)
        //            .PadLeft(2, '0');

        //    string gg = Convert.ToString(new Random().Next(0, 256), 16)
        //            .PadLeft(2, '0');
        //    string bb = Convert.ToString(new Random().Next(0, 256), 16)
        //            .PadLeft(2, '0');
        //    return Color.FromArgb(255, 
        //        Convert.ToByte(rr, 16),
        //        Convert.ToByte(gg, 16),
        //        Convert.ToByte(bb, 16)
        //        );
        //}

        private void ShowColor(object sender, RoutedEventArgs e)
        {
            Random _random = new Random();
            rec1.Fill = new SolidColorBrush(
                Color.FromRgb(
                    (byte)_random.Next(256),
                    (byte)_random.Next(256),
                    (byte)_random.Next(256)));
        }
    }
}