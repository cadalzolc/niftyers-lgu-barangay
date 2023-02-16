using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Niftyers;

public abstract class EntityConfigurationBase<TEntity>: IEntityTypeConfiguration<TEntity> where TEntity : class 
{
   public virtual void Configure(EntityTypeBuilder<TEntity> builder) { }
}