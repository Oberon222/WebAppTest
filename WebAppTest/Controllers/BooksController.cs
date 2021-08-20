﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTest.Data.Models;
using WebAppTest.Data.Services;

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
        public IActionResult AddBook([FromBody] Book book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        [HttpDelete("delete-book")]
        public IActionResult DeleteBook([FromBody] Book book)
        {
            _bookService.DeleteBook(book);
            return Ok();
        }

        [HttpPut("edit-book")]
        public IActionResult EditBook(Book book)
        {
            return Ok(book); 
        }

        [HttpGet("get-books")]
        public IActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks());
        }
    }
}
