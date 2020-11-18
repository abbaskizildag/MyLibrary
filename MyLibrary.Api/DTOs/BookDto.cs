using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Api.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime PublishedYear { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string SummaryAboutBook { get; set; }
        public string BookImage { get; set; }

    }
}
