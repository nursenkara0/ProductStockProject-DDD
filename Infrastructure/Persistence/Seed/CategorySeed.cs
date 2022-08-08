using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Seed
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = Guid.NewGuid(), Name = "Electronic", Description = "Electronic" },
                new Category { Id = Guid.NewGuid(), Name = "Shoes", Description = "Shoes" },
                new Category { Id = Guid.NewGuid(), Name = "Cosmetic", Description = "Cosmetic" },
                new Category { Id = Guid.NewGuid(), Name = "Dress", Description = "Dress"},
                new Category { Id = Guid.NewGuid(), Name = "Accessories", Description = "Accessories"}
            );
        }
    }
}
