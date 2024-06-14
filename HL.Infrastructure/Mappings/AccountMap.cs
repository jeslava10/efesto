using HL.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HL.Infrastructure.Mappings
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            #region Columnas Primary Key)

            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();

            #endregion

            #region Normal Columns)

            builder.Property(p => p.Email).HasColumnName("Email").HasColumnType("varchar(255)").IsRequired().HasMaxLength(255);
            builder.Property(p => p.Password).HasColumnName("Password").HasColumnType("varchar(255)").IsRequired().HasMaxLength(255);
            builder.Property(p => p.Active).HasColumnName("Active").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy").HasColumnType("varchar(255)").IsRequired().HasMaxLength(255);
            builder.Property(p => p.CreationDate).HasColumnName("CreationDate").IsRequired();
            builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy").HasColumnType("varchar(255)").IsRequired().HasMaxLength(255);
            builder.Property(p => p.LastUpdate).HasColumnName("LastUpdate").IsRequired();

            #endregion

            #region Referential Columns)


            #endregion

            #region ForeignKeys)

            #endregion
        }
    }
}
