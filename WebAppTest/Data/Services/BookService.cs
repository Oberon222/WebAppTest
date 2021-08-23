using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTest.Data.Models;
using WebAppTest.Data.ViewModels;

namespace WebAppTest.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookWithAutors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,                 
                ImageURL = book.ImageURL,
                DateAdded = book.DateAdded,
                PublisherId = book.PublisherId,

            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach(var id in book.AuthorsId)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();

            }
        }

        public void DeleteBook(Book book)
        {
            var _book = _context.Books.Find(book);
            if(_book != null)
            {
                _context.Books.Remove(_book);
            }

            _context.SaveChanges();
        }

        //public void DeleteBookById(int bookId)
        //{
        //    var _book = _context.Books.FirstOrDefault(b => b.Id = bookId);

        //}

        
        public void EditBook(Book book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,                
                ImageURL = book.ImageURL,
                DateAdded = book.DateAdded
            };
             _context.Books.Update(_book);
            _context.SaveChanges();
        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
    }
}
