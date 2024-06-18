using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projekt.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
            


            if (context.Publishers.Any() || context.Authors.Any() || context.Books.Any())
            {
                return;
            }

            context.Publishers.AddRange(
                new Publisher()
                {
                    Name = "Kurier Codzienny"
                },
                new Publisher()
                {
                    Name = "Zysk i S-ka"
                }
            );
            context.SaveChanges();

            context.Authors.AddRange(
                new Author()
                {
                    Name = "Bolesław Prus",
                },
                new Author()
                {
                    Name = "J.R.R. Tolkien",
                }
            );

            context.SaveChanges();

            context.Books.AddRange(
                new Book
                {
                    Title = "Lalka",
                    PublishedDate = new DateTime(1999, 1, 1),
                    AuthorId = context.Authors.FirstOrDefault(x => x.Name == "Bolesław Prus").Id,
                    PublisherId = context.Publishers.FirstOrDefault(x => x.Name == "Kurier Codzienny")?.Id,
                    Publisher = context.Publishers.FirstOrDefault(x => x.Name == "Kurier Codzienny")
                },
                new Book
                {
                    Title = "The Lord of the Rings",
                    PublishedDate = new DateTime(1954, 7, 29),
                    AuthorId = context.Authors.FirstOrDefault(x => x.Name == "J.R.R. Tolkien").Id,
                    PublisherId = context.Publishers.FirstOrDefault(x => x.Name == "Zysk i S-ka")?.Id,
                    Publisher = context.Publishers.FirstOrDefault( x => x.Name == "Zysk i S-ka")
                }
            );

            context.SaveChanges();
            /*
            context.AuthorPublishers.AddRange(
            new AuthorPublisher
            {
                AuthorId = context.Authors.FirstOrDefault(x => x.Name == "Bolesław Prus").Id,
                PublisherId = context.Publishers.FirstOrDefault(x => x.Name == "Kurier Codzienny").Id
            },
            new AuthorPublisher
            {
                AuthorId = context.Authors.FirstOrDefault(x => x.Name == "J.R.R. Tolkien").Id,
                PublisherId = context.Publishers.FirstOrDefault(x => x.Name == "Zysk i S-ka").Id
            }
            );*/

        }
    }
}
