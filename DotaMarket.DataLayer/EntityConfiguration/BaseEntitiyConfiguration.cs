using DotaMarket.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotaMarket.DataLayer.EntityConfiguration
{
    internal class BaseEntitiyConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id);

            builder.Property(p => p.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(p => p.isDeleted)
                .HasColumnName("isDeleted")
                .IsRequired();
        }
    }    
}
