using Dominus.Database;
using Dominus.Database.Attributes;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Dominus.Entities
{
    /// <summary>
    /// Audit object for mapped table Audits.
    /// </summary>
    [Table("Audits")]
    public partial class CommonAudit : BaseEntity
    {

        #region Columnas normales)

        [Column("TableName", TypeName = "varchar(255)")]
        [DmsDisplayName("Audit.TableName")]
        [DmsRequired("Audit.TableName")]
        [DmsStringLength("Audit.TableName", 255)]
        public virtual String TableName { get; set; }

        [Column("Action", TypeName = "varchar(50)")]
        [DmsDisplayName("Audit.Action")]
        [DmsRequired("Audit.Action")]
        [DmsStringLength("Audit.Action", 50)]
        public virtual String Action { get; set; }

        [Column("TransactionDate", TypeName = "datetime")]
        [DmsDisplayName("Audit.TransactionDate")]
        [DmsRequired("Audit.TransactionDate")]
        public virtual DateTime TransactionDate { get; set; }

        [Column("KeyValues", TypeName = "varchar(255)")]
        [DmsDisplayName("Audit.KeyValues")]
        [DmsRequired("Audit.KeyValues")]
        [DmsStringLength("Audit.KeyValues", 255)]
        public virtual String KeyValues { get; set; }

        [Column("OldValues", TypeName = "varchar(max)")]
        [DmsDisplayName("Audit.OldValues")]
        [DmsStringLength("Audit.OldValues", 2147483647)]
        public virtual String OldValues { get; set; }

        [Column("NewValues", TypeName = "varchar(max)")]
        [DmsDisplayName("Audit.NewValues")]
        [DmsStringLength("Audit.NewValues", 2147483647)]
        public virtual String NewValues { get; set; }

        #endregion


    }

    public partial class AuditEntry : BaseEntity
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        #region Columnas normales)

        public virtual String TableName { get; set; }

        public virtual String Action { get; set; }

        public virtual DateTime TransactionDate { get; set; }

        public Dictionary<string, object> KeyValues { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; set; } = new Dictionary<string, object>();

        public EntityEntry Entry { get; }

        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        #endregion

        public CommonAudit ToAudit()
        {
            var audit = new CommonAudit();
            audit.TableName = TableName;
            audit.TransactionDate = DateTime.UtcNow;
            audit.Action = Action;
            audit.KeyValues = JsonSerializer.Serialize(KeyValues);
            audit.OldValues = OldValues.Count == 0 ? null : JsonSerializer.Serialize(OldValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonSerializer.Serialize(NewValues);
            audit.CreatedBy = CreatedBy;
            audit.CreationDate = CreationDate;
            audit.UpdatedBy = UpdatedBy;
            audit.LastUpdate = LastUpdate;
            return audit;
        }
    }

}

