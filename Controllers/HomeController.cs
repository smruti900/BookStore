using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using BookStore.Model;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string CustomProperty { get; set; }
        [ViewData]
        public string Title { get; set; }
        [ViewData]
        public BookModel book { get; set; }
        public ViewResult Index()
        {
            Title = "This the home title";
            CustomProperty = "Custom Value";

            book = new BookModel() { Id = 1, Author = "abhisheka" };
            //ViewData["property1"] = "smruti";

            //ViewData["book"] = new BookModel { Author = "mansi", Id = 3 };
            //var obj = new { Id = 1, name = "smruti" };
            //ViewBag.Title = "Smruti";
            //dynamic data = new ExpandoObject();
            //data.Id = 1;
            //data.Name = "mansi";

            //ViewBag.Data = data;

            //ViewBag.Type = new BookModel { Id = 5, Author = "this is Unauthorized" };

            // ViewBag.data = new { Id = 1, name = "smruti" };
            return View();
        }

        public ViewResult Aboutus()
        {
            Title = "This the aboutus title";
            return View();
        }
        public ViewResult Contactus()
        {
            return View();
        }
    }
}
