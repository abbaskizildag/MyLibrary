using MyLibrary.DataAccess.Abstract;
using MyLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.DataAccess.Concrete
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private MyLibraryDbContext _myLibraryDbContext { get => _context as MyLibraryDbContext; }
        public BookRepository(MyLibraryDbContext context ):base(context)
        {

        }
    }
}
