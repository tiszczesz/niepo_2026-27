using System;
using System.Collections.Generic;
using System.Text;

namespace cw1_lists.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }
        public DateOnly DateOf { get; set; }
        public override string ToString()
        {
            return $"{Id}: {Title} - {Content} ({DateOf})";
        }
    }
}
