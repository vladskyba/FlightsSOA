using FlightService.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FlightService.ModelsConfigurations
{
    public class BaseEntityConfigurator<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(b => b.Id)
                .HasColumnName($"{typeof(TEntity).Name.ToSnakeCase()}_id")
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}
