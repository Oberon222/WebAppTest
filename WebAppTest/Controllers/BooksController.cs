using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTest.Data.Models;
using WebAppTest.Data.Services;
using WebAppTest.Data.ViewModels;

namespace WebAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookService.AddBookWithAutors(book);
            return Ok();
        }

        [HttpDelete("delete-book")]
        public IActionResult DeleteBook([FromBody] Book book)
        {
            _bookService.DeleteBook(book);
            return Ok();
        }

        [HttpPut("edit-book")]
        public IActionResult EditBook([FromBody] Book book)
        {
            return Ok(book); 
        }

        [HttpGet("get-books")]
        public IActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBookd()
        {
            var _allBooks = _bookService.GetBooks();
            return Ok(_allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var _book = _bookService.GetBookById(id);
            if(_book != null)
            {
                return Ok(_book);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {            
            var _book = _bookService.UpdateBookById(id, book);
            return Ok(_book);           
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            try
            {
                _bookService.DeleteBookById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        
        
        
    }
}
