using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AnimalRegister.Application.Management.Entries.Dtos;
using AnimalRegister.Domain.Results;

namespace AnimalRegister.Application.Management.Entries
{
    public interface IEntryAppService : IManagementApplicationService
    {
        /// <summary>
        /// API-endpoint to create a new entry
        /// </summary>
        Task<LongResult> CreateEntry(CreateEntryInput input);

        /// <summary>
        /// API-endpoint to update an existing entry
        /// </summary>
        Task UpdateEntry(UpdateEntryInput input);

        /// <summary>
        /// API-endpoint to delete an exiting entry
        /// </summary>
        Task DeleteEntry(DeleteEntryInput input);

        /// <summary>
        /// API-endpoint to restore a deleted entry
        /// </summary>
        Task RestoreEntry(RestoreEntryInput input);

        /// <summary>
        /// API-endpoint to retrieve a single entry
        /// </summary>
        Task<EntryDto> GetEntry(GetEntryInput input);

        /// <summary>
        /// API-endpoint to retrieve all entries
        /// </summary>
        Task<ListResultDto<EntrySlimmedDto>> GetAllEntries();

        /// <summary>
        /// API-endpoint to retrieve all trashes entries
        /// </summary>
        Task<ListResultDto<EntrySlimmedDto>> GetAllTrashedEntries();

        /// <summary>
        /// API-endpoint to delete all 'soft' deleted entries
        /// </summary>
        Task DeleteAllTrashedEntries();
    }
}
