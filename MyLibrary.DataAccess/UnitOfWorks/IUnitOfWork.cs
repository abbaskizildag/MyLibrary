using MyLibrary.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.DataAccess.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }

        IUserRepository Users { get; }


        void Commit();
    }
}
