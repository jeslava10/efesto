using Dominus.Database;
using Dominus.Database.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace HL.Infrastructure.Entities
{

    public partial class AccountProfile : BaseEntity
    {
       [DmsDisplayName("AccountProfile.Description")]
       [DmsRequired("AccountProfile.Description")]
       [DmsStringLength("AccountProfile.Description",255)]
       public virtual String Description { get; set; }

       [DmsDisplayName("AccountProfile.SecurityPolicy")]
       [DmsRequired("AccountProfile.SecurityPolicy")]
       public virtual Boolean SecurityPolicy { get; set; }

       [DmsDisplayName("AccountProfile.Active")]
       [DmsRequired("AccountProfile.Active")]
       public virtual Boolean Active { get; set; }


       [NotMapped]
       public virtual List<AccountAssignedProfile> AccountAssignedProfiles { get; set; }

       [NotMapped]
       public virtual List<AccountProfileNavigation> AccountProfileNavigations { get; set; }


    }

}
