using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace AnimalRegister.Entries
{
    [Table("Entries")]
    public class Entry : FullAuditedEntity<long>
    {
        /// <summary>
        /// Date animal was found
        /// </summary>
        public virtual DateTime? DateIn { get; set; }

        /// <summary>
        /// Specy
        /// </summary>
        public virtual string Specy { get; set; }

        /// <summary>
        /// Location where the animal was found
        /// </summary>
        public virtual string Location { get; set; }

        /// <summary>
        /// Who made the alert
        /// </summary>
        public virtual string Via { get; set; }

        /// <summary>
        /// Ingury diagnose
        /// </summary>
        public virtual string Diagnose { get; set; }

        /// <summary>
        /// When the animal was returned back
        /// </summary>
        public virtual DateTime? DateOut { get; set; }

        /// <summary>
        /// Final result
        /// </summary>
        public virtual string Result { get; set; }
    }
}
