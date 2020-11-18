using MyLibrary.DataAccess.Abstract;
using MyLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.DataAccess.Concrete
{
   public class UserRepository : Repository<User>, IUserRepository
    {
        private MyLibraryDbContext _myLibraryDbContext { get => _context as MyLibraryDbContext; }
        public UserRepository(MyLibraryDbContext context) : base(context)
        {

        }
    }
}
