using Dominus.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HL.Infrastructure.Mappings
{
    public class CommonAuditMap : IEntityTypeConfiguration<CommonAudit>
    {
        public void Configure(EntityTypeBuilder<CommonAudit> builder)
        {
            builder.ToTable("CommonAudits");

            #region Columnas Primary Key)

            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();

            #endregion

            #region Normal Columns)

            builder.Property(p => p.TableName).HasColumnName("TableName").HasColumnType("varchar(255)").IsRequired().HasMaxLength(255);
            builder.Property(p => p.Action).HasColumnName("Action").HasColumnType("varchar(50)").IsRequired().HasMaxLength(50);
            builder.Property(p => p.TransactionDate).HasColumnName("TransactionDate").IsRequired();
            builder.Property(p => p.KeyValues).HasColumnName("KeyValues").HasColumnType("varchar(255)").IsRequired().HasMaxLength(255);
            builder.Property(p => p.OldValues).HasColumnName("OldValues").HasColumnType("varchar(2147483647)").IsRequired(false).HasMaxLength(2147483647);
            builder.Property(p => p.NewValues).HasColumnName("NewValues").HasColumnType("varchar(2147483647)").IsRequired(false).HasMaxLength(2147483647);
            builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy").HasColumnType("varchar(255)").IsRequired().HasMaxLength(255);
            builder.Property(p => p.LastUpdate).HasColumnName("LastUpdate").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy").HasColumnType("varchar(255)").IsRequired().HasMaxLength(255);
            builder.Property(p => p.CreationDate).HasColumnName("CreationDate").IsRequired();

            #endregion

            #region Referential Columns)


            #endregion

            #region ForeignKeys)

            #endregion
        }
    }
}
