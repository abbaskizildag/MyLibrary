using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyLibrary.Entities
{
   public class User:BaseModel
    {
        public User()
        {
            Books = new List<Book>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortDescription { get; set; }
        public List<Book> Books { get; set; }
        public List<Role> Roles { get; set; }

    }
}
