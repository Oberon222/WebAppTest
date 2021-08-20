using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTest.Data.Models;

namespace WebAppTest.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var seviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = seviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                     new Book()
                     { 
                         Title = "My Book",
                         Description = "іжмо длІОВ ПДЛОРчСМИ ",
                         Author = "Mike",
                         IsRead = true,
                         DateRead = DateTime.Now.AddDays(-12),
                         Rate = 4,
                         Genre = "Programming",
                         ImageURL = "https://www.britishbook.ua/upload/resize_cache/iblock/5d9/369_450_174b5ed2089e1946312e2a80dcd26f146/kniga_c_programming_in_easy_steps.jpeg",
                         DateAdded = DateTime.Now.AddDays(-42)

                     },
                    new Book()
                    {
                        Title = "My Book2",
                        Description = "] oJKdfk kjalkjfg PEPOT][SOKB",
                        Author = "John",
                        IsRead = false,
                        Genre = "Programming",
                        ImageURL = "https://balka-book.com/files/2021/07_16/17_05/u_files_store_25_1759.jpg",
                        DateAdded = DateTime.Now.AddDays(-22)
                    });

                    context.SaveChanges();

                }
            }
        }
    }
}
