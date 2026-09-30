using System;
using System.Collections.Generic;
using System.Text;

namespace cw1_wpf.Models
{
    public class Contact
    {
        
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public override string ToString()
        {
            return $"{Firstname} {Lastname} tel: {Phone}";
        }
    }
}
