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
    public class PublishersController : ControllerBase
    {
        private PublishersService _publisherService;
        public PublishersController(PublishersService publishersService)
        {
            _publisherService = publishersService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisherVM)
        {
            var newPublisher = _publisherService.AddPublisher(publisherVM);
            return Created(nameof(AddPublisher), newPublisher);
        }
    }
}
