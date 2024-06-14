using Dominus.Database;
using Dominus.Database.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominus.Entities
{
    public class CommonLanguageResource : BaseEntity
    {

        #region Columnas normales

        [Column("ResourceKey", TypeName = "varchar(255)")]
        [DmsDisplayName("LanguageResource.ResourceKey")]
        [DmsRequired("LanguageResource.ResourceKey")]
        [DmsStringLength("LanguageResource.ResourceKey", 255)]
        public virtual String ResourceKey { get; set; }

        [Column("ResourceValue", TypeName = "varchar(1024)")]
        [DmsDisplayName("LanguageResource.ResourceValue")]
        [DmsRequired("LanguageResource.ResourceValue")]
        [DmsStringLength("LanguageResource.ResourceValue", 1024)]
        public virtual String ResourceValue { get; set; }

        [Column("Active")]
        [DmsDisplayName("LanguageResource.Active")]
        [DmsRequired("LanguageResource.Active")]
        public virtual Boolean Active { get; set; }

        #endregion

        #region Columnas referenciales)

        [Column("LanguageId")]
        [DmsDisplayName("LanguageResource.LanguageId")]
        [DmsRequired("LanguageResource.LanguageId")]
        public virtual int LanguageId { get; set; }

        #endregion

        #region Propiedades referencias de entrada)

        [ForeignKey("LanguageId")]
        public virtual CommonLanguage Language { get; set; }

        #endregion
    }
}

