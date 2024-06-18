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
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();

            builder.HasMany(p => p.Books)
               .WithOne(b => b.Publisher)
               .HasForeignKey(b => b.PublisherId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Cascade); 


            builder.HasMany(p => p.Authors)
               .WithOne(a => a.Publisher)
               .HasForeignKey(a => a.PublisherId)
               .IsRequired(false); 

        }
    }
}
