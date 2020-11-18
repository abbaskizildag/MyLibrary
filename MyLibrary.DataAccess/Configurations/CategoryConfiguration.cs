using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(50);

            builder.ToTable("Categories");
        }
    }
}
