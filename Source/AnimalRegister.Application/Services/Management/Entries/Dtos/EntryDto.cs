using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AnimalRegister.Entries;

namespace AnimalRegister.Application.Management.Entries.Dtos
{
    /// <summary>
    /// Class used as information hiding instance of <see cref="Entry"/>
    /// </summary>
    [AutoMapFrom(typeof(Entry))]
    public class EntryDto : FullAuditedEntityDto<long>
    {
        /// <summary>
        /// Date animal was found
        /// </summary>
        public DateTime? DateIn { get; set; }

        /// <summary>
        /// Specy
        /// </summary>
        public string Specy { get; set; }

        /// <summary>
        /// Location where the animal was found
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Who made the alert
        /// </summary>
        public string Via { get; set; }

        /// <summary>
        /// Ingury diagnose
        /// </summary>
        public string Diagnose { get; set; }

        /// <summary>
        /// When the animal was returned back
        /// </summary>
        public DateTime? DateOut { get; set; }

        /// <summary>
        /// Final result
        /// </summary>
        public string Result { get; set; }
    }
}
