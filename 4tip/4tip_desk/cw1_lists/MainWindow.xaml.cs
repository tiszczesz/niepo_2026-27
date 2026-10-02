using System.Collections.ObjectModel;
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
using cw1_lists.Models;

namespace cw1_lists
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotesRepo notesRepo;
        public ObservableCollection<Note> Notes { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            notesRepo = new NotesRepo();
            Notes = new ObservableCollection<Note>(notesRepo.GetAllNotes());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Set the data context for the notes list
            notesList.ItemsSource = Notes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddNewWindow().ShowDialog();
        }
    }
}