using Dominus.Database.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominus.Database
{
    [DmsApiEntityAttribute]
    public class BaseEntity : BaseEntityCustom
    {

        [DmsDisplayName("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("UpdatedBy")]
        [DmsRequired("UpdatedBy")]
        [DmsDisplayName("UpdatedBy")]
        public string UpdatedBy { get; set; }

        [Column("LastUpdate")]
        [DmsRequired("LastUpdate")]
        [DmsDisplayName("LastUpdate")]
        public DateTime LastUpdate { get; set; }

        [Column("CreatedBy")]
        [DmsRequired("CreatedBy")]
        [DmsDisplayName("CreatedBy")]
        public string CreatedBy { get; set; }

        [Column("CreationDate")]
        [DmsRequired("CreationDate")]
        [DmsDisplayName("CreationDate")]
        public DateTime CreationDate { get; set; }

        #region Compare methods

        public override bool Equals(object obj)
        {
            return Equals(obj as BaseEntity);
        }

        public virtual bool Equals(BaseEntity other)
        {
            if (other == null)
                return false;
            if (other.Id == this.Id)
                return true;
            if (ReferenceEquals(this, other))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(BaseEntity x, BaseEntity y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(BaseEntity x, BaseEntity y)
        {
            return !(x == y);
        }

        #endregion


    }


}