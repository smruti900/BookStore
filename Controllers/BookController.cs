﻿using BookStore.Model;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly BookRepository _bookrepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookrepository = bookRepository;

        }
        
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookrepository.GetAllBooks();
            return View(data);
        }
        [Route("book-details/{id}",Name ="bookdetailsroute")]
        public async Task<ViewResult> GetBook(int id)
        {
            //return _bookrepository.GetBookById(id);
            var data = await _bookrepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SearchBook(string BookName,string AutherName)
        {
            return _bookrepository.SearchBook(BookName,AutherName);
        }
        public ViewResult AddNewBook(bool issuccess=false,int bookId=0)
        {
            var model = new BookModel()
            {
                Language = "2"
            };

            ViewBag.Language =new SelectList(GetLanguage(),"Id","Text");
            ViewBag.IsSuccess = issuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookmodel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookrepository.AddNewBook(bookmodel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { issuccess = true, bookId = id });
                }
            }
            //ViewBag.IsSuccess = false;
            //ViewBag.BookId = 0;
            //ViewBag.Language = new SelectList(new List<string>() { "English", "Hindi", "French" });
            ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            //ModelState.AddModelError("", "This is my custom error message");
            return View();
        }

        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){Id=1,Text="English"},
                new LanguageModel(){Id=2,Text="Hindi"},
                new LanguageModel(){Id=3,Text="French"}
            };
        }
    }
}
