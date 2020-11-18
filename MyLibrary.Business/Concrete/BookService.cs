using MyLibrary.Business.Abstract;
using MyLibrary.DataAccess.Abstract;
using MyLibrary.DataAccess.UnitOfWorks;
using MyLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Business.Concrete
{
   public class BookService :Service<Book> ,IBookService
    {
        public BookService(IUnitOfWork unitOfWork, IRepository<Book> repository) : base(unitOfWork, repository)
        {

        }
    }
}
