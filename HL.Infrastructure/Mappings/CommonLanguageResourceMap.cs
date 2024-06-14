using Dominus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HL.Infrastructure.Mappings
{
    public class CommonLanguageResourceMap : IEntityTypeConfiguration<CommonLanguageResource>
    {
        public void Configure(EntityTypeBuilder<CommonLanguageResource> builder)
        {
            builder.ToTable("CommonLanguageResources");

            #region Columnas Primary Key)

            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();

            #endregion

            #region Normal Columns)

            builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy").HasColumnType("varchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastUpdate).HasColumnName("LastUpdate").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy").HasColumnType("varchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(p => p.CreationDate).HasColumnName("CreationDate").IsRequired();
            builder.Property(p => p.ResourceKey).HasColumnName("ResourceKey").HasColumnType("varchar(255)").IsRequired().HasMaxLength(255);
            builder.Property(p => p.ResourceValue).HasColumnName("ResourceValue").HasColumnType("varchar(1024)").IsRequired().HasMaxLength(1024);
            builder.Property(p => p.Active).HasColumnName("Active").IsRequired();

            #endregion

            #region Referential Columns)

            builder.Property(p => p.LanguageId).HasColumnName("LanguageId").IsRequired();

            #endregion

            #region ForeignKeys)

            builder.HasOne(e => e.Language).WithMany().HasForeignKey(e => e.LanguageId);
            #endregion
        }
    }
}
