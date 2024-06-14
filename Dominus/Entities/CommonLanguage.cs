using System.ComponentModel.DataAnnotations.Schema;
using Dominus.Database;
using Dominus.Database.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Dominus.Entities
{
    public class CommonLanguage : BaseEntity
	{
		

        #region Columnas normales

        [Column("Code", TypeName = "varchar(10)")]
        [DmsDisplayName("Language.Code")]
        [DmsRequired("Language.Code")]
        [DmsStringLength("Language.Code", 10)]
        public virtual String Code { get; set; }

        [Column("Culture", TypeName = "varchar(50)")]
        [DmsDisplayName("Language.Culture")]
        [DmsRequired("Language.Culture")]
        [DmsStringLength("Language.Culture", 50)]
        public virtual String Culture { get; set; }

        [Column("Name", TypeName = "varchar(50)")]
        [DmsDisplayName("Language.Name")]
        [DmsRequired("Language.Name")]
        [DmsStringLength("Language.Name", 50)]
        public virtual String Name { get; set; }

        [Column("Active")]
        [DmsDisplayName("Language.Active")]
        [DmsRequired("Language.Active")]
        public virtual Boolean Active { get; set; }

        #endregion
    }
}

