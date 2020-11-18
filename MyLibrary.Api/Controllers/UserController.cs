using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.Api.DTOs;
using MyLibrary.Business.Abstract;
using MyLibrary.Entities;

namespace MyLibrary.Api.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.GetAll();
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var model = _userService.GetByID(id);
            if (model is null) return NotFound();

            return model;
        }
        [HttpPost]
        public ActionResult Post(UserDto userDto)
        {
            var newuser = new User { UserName  = userDto.UserName, Password = userDto.Password, FirstName = userDto.FirstName, LastName = userDto.LastName, ShortDescription = userDto.ShortDescription};
            _userService.Create(newuser);
            return Created(string.Empty, newuser);
        }
        [HttpPut]
        public ActionResult Put( UserDto userDto)
        {
            var user = _userService.GetByID(userDto.Id);
            //if (user is null)
            //{
            //    user = new User { UserName = userDto.UserName, Password = userDto.Password, FirstName = userDto.FirstName, LastName = userDto.LastName, ShortDescription = userDto.ShortDescription };
            //    _userService.Create(user);
            //    return CreatedAtAction("Get", new { id = id }, user);
            //}
            user.UserName = userDto.UserName;
            user.Password = userDto.Password;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.ShortDescription = userDto.ShortDescription;

            _userService.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _userService.GetByID(id);
            if (user is null) return NotFound();

            _userService.Delete(user.Id);
            return NoContent();
        }
    }
}
