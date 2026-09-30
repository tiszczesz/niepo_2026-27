using System;
using System.Collections.Generic;
using System.Text;

namespace cw1_wpf.Models
{
    public class ContactRepo
    {
        public static List<Contact> GetContacts()
        {
            return new List<Contact>
            {
                new Contact {  Firstname = "Jan", Lastname = "Kowalski", Phone = "123-456-789" },
                new Contact {  Firstname = "Anna", Lastname = "Nowak", Phone = "987-654-321" },
                new Contact {  Firstname = "Piotr", Lastname = "Wiśniewski", Phone = "555-555-555" }
            };
        }
    }
}
