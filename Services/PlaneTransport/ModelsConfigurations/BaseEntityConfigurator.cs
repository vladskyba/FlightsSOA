using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlaneTransport.Models;

namespace PlaneTransport.ModelsConfigurations
{
    internal class BaseEntityConfigurator<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(b => b.Id)
                .HasColumnName($"{typeof(TEntity)}_id")
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}
