using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            var user = await _userService.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(user);

        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var model = _userService.GetByID(id);
            if (model is null) return NotFound();

            return Ok(model);
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
