using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyLibrary.Entities
{
    public class Category:BaseModel
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public string CategoryName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
 
}
