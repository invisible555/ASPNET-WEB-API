using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projekt.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model.Configurations
{
    public class BookConfiguration: IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PublishedDate).HasColumnType("date").IsRequired();

            builder.HasOne(b => b.Author)
             .WithMany(a => a.Books)
             .HasForeignKey(b => b.AuthorId)
             .IsRequired();

            builder.HasOne(b => b.Publisher)
                .WithMany()
                .HasForeignKey(b => b.PublisherId)
                .IsRequired(false);
        }
    }
}
