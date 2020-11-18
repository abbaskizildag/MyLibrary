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
    [Route("api/v1/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> Get()
        {
            return (await _bookService.GetAllAsync(w => true, x => x.Category)).Select(s => new BookDto
            {
                Id = s.Id,
                Author = s.Author,
                Name = s.Name,
                PublishedYear = s.PublishedYear,
                BookImage = s.BookImage,
                SummaryAboutBook = s.SummaryAboutBook,
                CategoryName = s.Category.CategoryName
            });
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var model = _bookService.GetByID(id);
            if (model is null) return NotFound();
            
            return Ok(model);
        }
        [HttpPost]
        public ActionResult Post(BookDto bookDto)
        {
            var newbook = new Book { Name = bookDto.Name, Author = bookDto.Author, PublishedYear = bookDto.PublishedYear, CategoryID = bookDto.CategoryID, SummaryAboutBook = bookDto.SummaryAboutBook, BookImage = bookDto.BookImage };
            _bookService.Create(newbook);
            return Created(string.Empty, newbook);
        }

        [HttpPut]
        public ActionResult Update( BookDto bookDto)
        {
            var book = _bookService.GetByID(bookDto.Id);

            book.Name = bookDto.Name;
            book.Author = bookDto.Author;
            book.PublishedYear = bookDto.PublishedYear;
            book.CategoryID = bookDto.CategoryID;
            book.SummaryAboutBook = bookDto.SummaryAboutBook;
            book.BookImage = bookDto.BookImage;

            _bookService.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var book = _bookService.GetByID(id);
            if (book is null) return NotFound();

            _bookService.Delete(book.Id);
            return NoContent();
        }

    }
}
