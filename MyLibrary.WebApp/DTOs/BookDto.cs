using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.WebApp.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0}  alanı boş olamaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} alanı boş olamaz")]
        public string Author { get; set; }
        public DateTime PublishedYear { get; set; }
        [Required(ErrorMessage = "{0} alanı boş olamaz")]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
        [Required(ErrorMessage = "{0} alanı boş olamaz")]
        public string SummaryAboutBook { get; set; }
        public string BookImage { get; set; }
    }
}
