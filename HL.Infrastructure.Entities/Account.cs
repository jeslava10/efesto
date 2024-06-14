using Dominus.Database;
using Dominus.Database.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace HL.Infrastructure.Entities
{

    public partial class Account : BaseEntity
    {
       [DmsDisplayName("Account.Email")]
       [DmsRequired("Account.Email")]
       [DmsStringLength("Account.Email",255)]
       public virtual String Email { get; set; }

       [DmsDisplayName("Account.Password")]
       [DmsRequired("Account.Password")]
       [DmsStringLength("Account.Password",255)]
       public virtual String Password { get; set; }

       [DmsDisplayName("Account.Active")]
       [DmsRequired("Account.Active")]
       public virtual Boolean Active { get; set; }

        [NotMapped]
       public virtual List<AccountAssignedProfile> AccountAssignedProfiles { get; set; }


    }

}
