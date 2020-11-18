using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyLibrary.Entities
{
    public class Role:BaseModel
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}