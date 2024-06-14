using Dominus.Database;
using Dominus.Database.Attributes;

namespace HL.Infrastructure.Entities
{
    public partial class CommonParameter : BaseEntity
    {
       [DmsDisplayName("CommonParameter.Code")]
       [DmsRequired("CommonParameter.Code")]
       [DmsStringLength("CommonParameter.Code",10)]
       public virtual String Code { get; set; }

       [DmsDisplayName("CommonParameter.Description")]
       [DmsRequired("CommonParameter.Description")]
       [DmsStringLength("CommonParameter.Description",255)]
       public virtual String Description { get; set; }

       [DmsDisplayName("CommonParameter.Active")]
       [DmsRequired("CommonParameter.Active")]
       public virtual Boolean Active { get; set; }

    }

}
