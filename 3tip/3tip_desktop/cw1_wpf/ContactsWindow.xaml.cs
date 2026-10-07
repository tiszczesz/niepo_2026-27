using cw1_wpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace cw1_wpf
{
    /// <summary>
    /// Interaction logic for ContactsWindow.xaml
    /// </summary>
    public partial class ContactsWindow : Window
    {
        private ObservableCollection<Contact> contacts;
        private List<Contact> contactList;
        public ContactsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contacts = ContactRepo.GetContacts();
            LbContacts.ItemsSource = contacts;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Contact c1 = new Contact()
            {
                Firstname = "Nowy",
                Lastname = "Kontakt",
                Phone = "123456789"
            };
            contacts.Add(c1);
            //Console.WriteLine("Dodano nowy kontakt.");
            //Console.WriteLine(contactList);
        }
    }
}
