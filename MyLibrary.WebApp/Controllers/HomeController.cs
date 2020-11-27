using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyLibrary.Business.Abstract;
using MyLibrary.Business.Concrete;
using MyLibrary.WebApp.AppService;
using MyLibrary.WebApp.DTOs;
using MyLibrary.WebApp.Models;

namespace MyLibrary.WebApp.Controllers
{

    public class HomeController : Controller
    {

        private readonly IBookService _bookService; 
        private readonly BookApiService _bookApiService;
        public HomeController(IBookService bookService, BookApiService bookApiService)
        {
            _bookService = bookService;
           _bookApiService = bookApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
