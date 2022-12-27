using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationService.Models;

namespace ReservationService.ModelsConfigurations
{
    public class ReplicationBaseConfigurator<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(b => b.Id)
                .HasColumnName($"{typeof(TEntity).Name.ToSnakeCase()}_id")
                .ValueGeneratedNever()
                .IsRequired();
        }
    }
}
