using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTest.Data.Models;
using WebAppTest.Data.ViewModels;

namespace WebAppTest.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public List<Publisher> GetAllPublishers()
        {
            var allPublishers = _context.Publishers.ToList();
            return allPublishers;
        }

        public Publisher  AddPublisher(PublisherVM publisherVM)
        {
            var _publisher = new Publisher()
            {
                Name = publisherVM.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
            return _publisher;
        }

        public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                         BookName = n.Title,
                         BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                    }).ToList()

                }).FirstOrDefault();
            return _publisherData;
        }       

        public void DeletePublisher(PublisherVM publisherVM) //by Id
        {
            var _publisher = _context.Publishers.Find(publisherVM);
            if(_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }            
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if(_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"The publisher with id: {id} not found");
            }

        }

        public void EditPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher() // уточнити у Андрія
            {
                Name = publisher.Name
            };
            _context.Publishers.Update(_publisher);
            _context.SaveChanges();
        }            
    }
}
