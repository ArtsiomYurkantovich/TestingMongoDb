using Database.Model;
using Database.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationMongoDb.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
      
        [HttpGet]
        public IActionResult GetBooks()
        {
            return View(_bookRepository.GetBooks());
        }

        
        public IActionResult Create()
        {
            return View(new Book());
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            _bookRepository.AddBook(book);
            return View(book);
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            return View(_bookRepository.GetBook(id));
        }
        
        [HttpPost]
        public IActionResult Update(Book book)
        {
            return View(_bookRepository.UpdateBook(book));
        }

        public IActionResult DeleteBook(string id)
        {
           var book = _bookRepository.GetBook(id);
            return View(book);
        }

        [HttpPost,ActionName("DeleteBook")]
        public IActionResult Delete(string id)
        {
            _bookRepository.RemoveBook(id);
            return RedirectToAction("GetBooks");
        }
    }
}
