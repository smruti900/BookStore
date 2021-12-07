using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title,string authorname)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorname)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1,Title="MVC",Author="smruti",Description="This is a description book for MVC",Category="Programming",Language="English",TotalPages=300},
                new BookModel(){Id=2,Title="java",Author="mansi",Description="This is a description book for java",Category="Programming",Language="Chinese",TotalPages=279},
                new BookModel(){Id=3,Title="spring",Author="saumya",Description="This is a description book for spring",Category="Framework",Language="Hindi",TotalPages=500},
                new BookModel(){Id=4,Title="asp",Author="abhisheka",Description="This is a description book for asp",Category="database",Language="Urdu",TotalPages=347}
            };
        }
    }
}
