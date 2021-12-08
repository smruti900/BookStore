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
        public BookController()
        {
            _bookrepository = new BookRepository();

        }
        
        public ViewResult GetAllBooks()
        {
            var data = _bookrepository.GetAllBooks();
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
    }
}
