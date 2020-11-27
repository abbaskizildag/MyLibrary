using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.WebApp.AppService;
using MyLibrary.WebApp.DTOs;

namespace MyLibrary.WebApp.Controllers
{

    public class BookController : Controller
    {
        private readonly BookApiService _bookApiService;
        public BookController(BookApiService bookApiService)
        {
            _bookApiService = bookApiService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _bookApiService.GetAll();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                _bookApiService.Add(bookDto);
            }
            else
            {
                return View("Create",bookDto);
            }

            return RedirectToAction("Index");
        }

     
        public IActionResult Update(int id)
        {
            var book = _bookApiService.GetByAsync(id);

            return View(book);
        }
        [HttpPost]
        public IActionResult Update(BookDto bookDto)
        {
            _bookApiService.Update(bookDto);

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _bookApiService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
