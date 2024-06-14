using Dominus.Database;
using Dominus.Database.Attributes;

namespace HL.Infrastructure.Entities
{

    public partial class AccountAssignedProfile : BaseEntity
    {
       [DmsDisplayName("AccountAssignedProfile.AccountProfileId")]
       [DmsRequired("AccountAssignedProfile.AccountProfileId")]
       public virtual Int32 AccountProfileId { get; set; }

       [DmsDisplayName("AccountAssignedProfile.AccountId")]
       [DmsRequired("AccountAssignedProfile.AccountId")]
       public virtual Int32 AccountId { get; set; }

       #region Propiedades referencias de entrada)

       public virtual AccountProfile AccountProfile { get; set; }

       public virtual Account Account { get; set; }

       #endregion

    }

}
