using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using cw1_lists.Models;

namespace cw1_lists
{
    /// <summary>
    /// Interaction logic for AddNewWindow.xaml
    /// </summary>
    public partial class AddNewWindow : Window
    {
        MainWindow mainWindow;
        public AddNewWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Title = titleTextBox.Text;
            string Content = contentTextBox.Text;
            DateTime Date = dateDatePicker.SelectedDate ?? DateTime.Now;
            Note noteToAdd = new Note
            {
                Title = Title,
                Content = Content,
                DateOf = DateOnly.FromDateTime(Date),
                Id = mainWindow.notesRepo.GetLastId()+1
            };
            // Add the new note to the main window's notes collection
            // (Assuming you have a reference to the main window)   
            mainWindow.Notes.Add(noteToAdd);
            this.Close();
        }
    }
}
