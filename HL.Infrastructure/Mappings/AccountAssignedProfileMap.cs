using HL.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HL.Infrastructure.Mappings
{
    public class AccountAssignedProfileMap : IEntityTypeConfiguration<AccountAssignedProfile>
    {
        public void Configure(EntityTypeBuilder<AccountAssignedProfile> builder)
        {
            builder.ToTable("AccountAssignedProfiles");

            #region Columnas Primary Key)

            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd().IsRequired();

            #endregion

            #region Normal Columns)

            builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy").HasColumnType("varchar(255)").IsRequired().HasMaxLength(255);
            builder.Property(p => p.CreationDate).HasColumnName("CreationDate").IsRequired();
            builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy").HasColumnType("varchar(255)").IsRequired().HasMaxLength(255);
            builder.Property(p => p.LastUpdate).HasColumnName("LastUpdate").IsRequired();

            #endregion

            #region Referential Columns)

            builder.Property(p => p.AccountProfileId).HasColumnName("AccountProfileId").IsRequired();
            builder.Property(p => p.AccountId).HasColumnName("AccountId").IsRequired();

            #endregion

            #region ForeignKeys)

            builder.HasOne(e => e.AccountProfile).WithMany().HasForeignKey(e => e.AccountProfileId);
            builder.HasOne(e => e.Account).WithMany().HasForeignKey(e => e.AccountId);
            #endregion
        }
    }
}
