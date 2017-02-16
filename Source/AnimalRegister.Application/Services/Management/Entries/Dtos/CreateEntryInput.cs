using System.ComponentModel.DataAnnotations;

namespace AnimalRegister.Application.Management.Entries.Dtos
{
    public class CreateEntryInput
    {
        /// <summary>
        /// Date animal was found
        /// </summary>
        public string DateIn { get; set; }

        /// <summary>
        /// Specy
        /// </summary>
        [Required]
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
        public string DateOut { get; set; }

        /// <summary>
        /// Final result
        /// </summary>
        public string Result { get; set; }
    }
}
