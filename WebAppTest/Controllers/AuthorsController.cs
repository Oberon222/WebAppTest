using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTest.Data.Services;
using WebAppTest.Data.ViewModels;

namespace WebAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
           var newAuthor = _authorsService.AddAuthor(author);
            return Created(nameof(AddAuthor), newAuthor);
        }

        [HttpGet("get-author-with-books/{id}")]
        public IActionResult GetAuthorsWithBooks(int id)
        {
            var _author = _authorsService.GetAuthorWithBooks(id);
            if(_author != null)
            {
                return Ok(_author);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
