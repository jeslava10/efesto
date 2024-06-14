using Dominus.Database;
using Dominus.Database.Attributes;

namespace HL.Infrastructure.Entities
{

    public partial class AccountProfileNavigation : BaseEntity
    {
       [DmsDisplayName("AccountProfileNavigation.MenuId")]
       [DmsRequired("AccountProfileNavigation.MenuId")]
       [DmsStringLength("AccountProfileNavigation.MenuId",255)]
       public virtual String MenuId { get; set; }

       [DmsDisplayName("AccountProfileNavigation.MenuActionId")]
       [DmsRequired("AccountProfileNavigation.MenuActionId")]
       [DmsStringLength("AccountProfileNavigation.MenuActionId",255)]
       public virtual String MenuActionId { get; set; }

       [DmsDisplayName("AccountProfileNavigation.AccountProfileId")]
       [DmsRequired("AccountProfileNavigation.AccountProfileId")]
       public virtual Int32 AccountProfileId { get; set; }

       #region Propiedades referencias de entrada)

       public virtual AccountProfile AccountProfile { get; set; }

       #endregion

    }

}
