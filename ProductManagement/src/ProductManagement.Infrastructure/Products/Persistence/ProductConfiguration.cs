using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Products.Persistence
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            //builder.Property(p => p.Id)
            //    .ValueGeneratedNever();

            builder.ToTable("Products");


            builder.HasKey(p => p.Id);


            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.ProduceDate)
                .IsRequired();

            builder.Property(p => p.ManufacturePhone)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();

            builder.Property(p => p.ManufactureEmail)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(p => p.IsAvailable)
                .IsRequired();

            // Relationships
            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique Index on ManufactureEmail and ProduceDate
            builder.HasIndex(p => new { p.ManufactureEmail, p.ProduceDate })
                .IsUnique()
                .HasDatabaseName("IX_Product_ManufactureEmail_ProduceDate");
        }
    }
}
