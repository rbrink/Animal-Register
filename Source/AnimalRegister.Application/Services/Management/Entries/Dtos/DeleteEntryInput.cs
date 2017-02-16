using System.ComponentModel.DataAnnotations;

namespace AnimalRegister.Application.Management.Entries.Dtos
{
    public class DeleteEntryInput
    {
        /// <summary>
        /// Id of requested entry
        /// </summary>
        [Required]
        public long Id { get; set; }
    }
}
