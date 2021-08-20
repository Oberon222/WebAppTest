﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTest.Data.Models;

namespace WebAppTest.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                Author = book.Author,
                ImageURL = book.ImageURL,
                DateAdded = book.DateAdded
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
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
                Author = book.Author,
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
