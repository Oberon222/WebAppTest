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

        [HttpGet("get-publishers")]
        public IActionResult GetPublishers()
        {
            var _allPublishers = _publisherService.GetAllPublishers();
            return Created(nameof(GetPublishers), _allPublishers);
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _publisher = _publisherService.GetPublisherById(id);
            if (_publisher != null)
            {
                return Ok(_publisher);
            }
            else
                return NotFound();
        }

        [HttpGet("get-publisher-data/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _publisherData = _publisherService.GetPublisherData(id);
            if (_publisherData != null)
            {
                return Ok(_publisherData);
            }
            else
                return NotFound();
        }

        [HttpDelete("delete-publisher")]
        public IActionResult DeletePublisher([FromBody] PublisherVM publisherVM)
        {
            _publisherService.DeletePublisher(publisherVM);
            return Created(nameof(DeletePublisher), publisherVM);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publisherService.DeletePublisherById(id);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-publisher")]
        public IActionResult UpdatePublisher([FromBody] PublisherVM publisher)
        {
            _publisherService.EditPublisher(publisher);
            return Created(nameof(UpdatePublisher), publisher);
        }
    }
}
 