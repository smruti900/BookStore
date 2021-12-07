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
        public ViewResult Index()
        {
            //var obj = new { Id = 1, name = "smruti" };
            ViewBag.Title = "Smruti";
            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "mansi";

            ViewBag.Data = data;

            ViewBag.Type = new BookModel { Id = 5, Author = "this is Unauthorized" };

           // ViewBag.data = new { Id = 1, name = "smruti" };
            return View();
        }

        public ViewResult Aboutus()
        {
            return View();
        }
        public ViewResult Contactus()
        {
            return View();
        }
    }
}
