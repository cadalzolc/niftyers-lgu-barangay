
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Niftyers;

public class Resident : Person
{
    [ DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
    public string No { get; set; } = "";
    
    public class Configuration : EntityConfigurationBase<Resident> {
        public override void Configure(EntityTypeBuilder<Resident> entity)
        {
            entity.HasKey(p => p.ID).HasName("IX_ResidentID");
            entity.HasIndex(p => p.No).IsUnique();
            entity.Property(p => p.No).HasDefaultValue("").HasMaxLength(30);
            entity.Property(p => p.LastName).HasDefaultValue("").HasMaxLength(30);
            entity.Property(p => p.FirstName).HasDefaultValue("").HasMaxLength(30);
            entity.Property(p => p.MidleName).HasDefaultValue("").HasMaxLength(30);
            entity.Property(p => p.Gender).HasDefaultValue("").HasMaxLength(10);
            entity.Property(p => p.BirthDate).HasDefaultValue("").HasMaxLength(10);
            entity.Property(p => p.Age).HasDefaultValue(0);
            entity.Property(p => p.CivilStatus).HasDefaultValue("").HasMaxLength(15);
            entity.Property(p => p.Address).HasDefaultValue("").HasMaxLength(160);
            entity.Property(p => p.Occupation).HasDefaultValue("").HasMaxLength(60);
            entity.Property(p => p.ContactNumber).HasDefaultValue("").HasMaxLength(20);
            entity.ToTable("Residents");
        }
    }

}