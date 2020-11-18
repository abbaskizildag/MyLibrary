using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.WebApp.AppService;
using MyLibrary.WebApp.DTOs;

namespace MyLibrary.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserApiService _userApiService;
        public UserController(UserApiService userApiService)
        {
            _userApiService = userApiService;
        }
        // GET: UserController
        public async Task<ActionResult> Index()
        {
            var model = await _userApiService.GetAll();
            
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserDto userDto)
        {
            _userApiService.Add(userDto);

            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            var user = _userApiService.GetByAsync(id);

            return View(user);
        }
        [HttpPost]
        public IActionResult Update(UserDto userDto)
        {
            _userApiService.Update(userDto);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _userApiService.Remove(id);
            return RedirectToAction("Index");
        }

    }
}
