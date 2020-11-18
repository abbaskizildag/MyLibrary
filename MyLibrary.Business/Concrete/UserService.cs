using MyLibrary.Business.Abstract;
using MyLibrary.DataAccess.Abstract;
using MyLibrary.DataAccess.UnitOfWorks;
using MyLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Business.Concrete
{
  public  class UserService : Service<User> , IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository) : base(unitOfWork, repository)
        {

        }
    }
}
