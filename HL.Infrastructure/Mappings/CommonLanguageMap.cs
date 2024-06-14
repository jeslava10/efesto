using Dominus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HL.Infrastructure.Mappings
{
    public class CommonLanguageMap : IEntityTypeConfiguration<CommonLanguage>
    {
        public void Configure(EntityTypeBuilder<CommonLanguage> builder)
        {
            builder.ToTable("CommonLanguages");

            #region Columnas Primary Key)

            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();

            #endregion

            #region Normal Columns)

            builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy").HasColumnType("varchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastUpdate).HasColumnName("LastUpdate").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy").HasColumnType("varchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(p => p.CreationDate).HasColumnName("CreationDate").IsRequired();
            builder.Property(p => p.Code).HasColumnName("Code").HasColumnType("varchar(10)").IsRequired().HasMaxLength(10);
            builder.Property(p => p.Culture).HasColumnName("Culture").HasColumnType("varchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(p => p.Name).HasColumnName("Name").HasColumnType("varchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(p => p.Active).HasColumnName("Active").IsRequired();
            #endregion

            #region Referential Columns)


            #endregion

            #region ForeignKeys)

            #endregion
        }
    }
}
