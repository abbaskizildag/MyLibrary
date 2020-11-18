using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyLibrary.Entities
{
    public class Book:BaseModel
    {
     //   [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime PublishedYear { get; set; }
        public int CategoryID { get; set; }
        public string SummaryAboutBook { get; set; }
        public string BookImage { get; set; }

        public virtual Category Category { get; set; }
        public List<User> Users { get; set; }

    }
  
}
