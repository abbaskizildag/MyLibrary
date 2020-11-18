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

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        public ActionResult Create(UserDto userDto)
        {
            _userApiService.Add(userDto);
            //if (ModelState.IsValid)
            //{

            //}
            //else
            //{
            //    return View("Create", userDto);
            //}

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
            //  var category = await _categoryApiService.GetByAsync(id);

            _userApiService.Remove(id);

            return RedirectToAction("Index");
        }

    }
}
