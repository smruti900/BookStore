using BookStore.Model;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
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
        public ViewResult GetBook(int id)
        {
            //return _bookrepository.GetBookById(id);
            var data = _bookrepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SearchBook(string BookName,string AutherName)
        {
            return _bookrepository.SearchBook(BookName,AutherName);
        }
        public ViewResult AddNewBook(bool issuccess=false,int bookId=0)
        {
            ViewBag.IsSuccess = issuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookmodel)
        {
            int id= await _bookrepository.AddNewBook(bookmodel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewBook),new { issuccess=true , bookId=id});
            }
            return View();
        }
    }
}
