using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projekt.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model.Configurations
{
    public  class AuthorConfiguration:IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();


            builder.HasOne(a => a.Publisher)
            .WithMany(p => p.Authors)
            .HasForeignKey(a => a.PublisherId)
            .IsRequired(false);

            builder.HasMany(a => a.Books)
               .WithOne(b => b.Author)
               .HasForeignKey(b => b.AuthorId)
               .IsRequired();
        }
    }
}
