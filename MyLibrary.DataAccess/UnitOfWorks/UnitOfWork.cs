using MyLibrary.DataAccess.Abstract;
using MyLibrary.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyLibraryDbContext _context;

        private BookRepository _bookRepository;
        private UserRepository _userRepository;
        public IBookRepository Books => _bookRepository = _bookRepository ?? new BookRepository(_context);
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);
        public UnitOfWork(MyLibraryDbContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

    }
}
