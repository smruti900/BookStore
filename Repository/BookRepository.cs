using BookStore.Data;
using BookStore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                Language = model.Language,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value :0,
                UpdateOn = DateTime.UtcNow
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
       
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Title = book.Title,
                        TotalPages = book.TotalPages,
                        Language = book.Language
                    }); ;
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    Language = book.Language
                };
                return bookDetails;
            }
            return null;
            //return _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
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
                new BookModel(){Id=4,Title="asp",Author="abhisheka",Description="This is a description book for asp",Category="database",Language="Urdu",TotalPages=347},
                new BookModel(){Id=5,Title="aws",Author="Ramesh",Description="This is a description book for aws",Category="database",Language="Urdu",TotalPages=357},
                new BookModel(){Id=6,Title="azure",Author="abhisheka",Description="This is a description book for azure",Category="database",Language="Urdu",TotalPages=327}
            };
        }
    }
}
