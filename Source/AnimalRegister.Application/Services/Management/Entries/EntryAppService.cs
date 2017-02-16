using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AnimalRegister.Application.Management.Entries.Dtos;
using AnimalRegister.Domain.Results;
using AnimalRegister.Entries;

namespace AnimalRegister.Application.Management.Entries
{
    public class EntryAppService : AnimalRegisterAppServiceBase, IEntryAppService
    {
        /// <summary>
        /// Repository used to read-out entries
        /// </summary>
        private readonly IRepository<Entry, long> _entryRepository;

        /// <summary>
        /// References the entry store
        /// </summary>
        public EntryStore EntryStore { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public EntryAppService(IRepository<Entry, long> entryRepository)
        {
            _entryRepository = entryRepository;
        }

        /// <summary>
        /// See <see cref="IEntryAppService.CreateEntry(CreateEntryInput)"/>
        /// </summary>
        public async Task<LongResult> CreateEntry(CreateEntryInput input)
        {
            var entry = await EntryStore.CreateAndInsertEntryAsync(
                ParseDateString(input.DateIn),
                input.Specy,
                input.Location,
                input.Via,
                input.Diagnose,
                ParseDateString(input.DateOut),
                input.Result
            );

            return new LongResult(entry.Id);
        }

        /// <summary>
        /// See <see cref="IEntryAppService.UpdateEntry(UpdateEntryInput)"/>
        /// </summary>
        public async Task UpdateEntry(UpdateEntryInput input)
        {
            var entry = await _entryRepository.GetAsync(input.Id);
            entry.DateIn = ParseDateString(input.DateIn);
            entry.Specy = input.Specy;
            entry.Location = input.Location;
            entry.Via = input.Via;
            entry.Diagnose = input.Diagnose;
            entry.DateOut = ParseDateString(input.DateOut);
            entry.Result = input.Result;
        }

        /// <summary>
        /// See <see cref="IEntryAppService.DeleteEntry(DeleteEntryInput)"/>
        /// </summary>
        public async Task DeleteEntry(DeleteEntryInput input)
        {
            await EntryStore.DeleteAsync(input.Id);
        }

        /// <summary>
        /// See <see cref="IEntryAppService.RestoreEntry(RestoreEntryInput)"/>
        /// </summary>
        public async Task RestoreEntry(RestoreEntryInput input)
        {
            await EntryStore.RestoreAsync(input.Id);
        }

        /// <summary>
        /// See <see cref="IEntryAppService.GetEntry(GetEntryInput)"/>
        /// </summary>
        public async Task<EntryDto> GetEntry(GetEntryInput input)
        {
            var entry = await _entryRepository.GetAsync(input.Id);
            return entry.MapTo<EntryDto>();
        }

        /// <summary>
        /// See <see cref="IEntryAppService.GetAllEntries"/>
        /// </summary>
        public async Task<ListResultDto<EntrySlimmedDto>> GetAllEntries()
        {
            var entries = await _entryRepository.GetAllListAsync();
            return new ListResultDto<EntrySlimmedDto>
            (
                entries.MapTo<List<EntrySlimmedDto>>()
            );
        }

        /// <summary>
        /// See <see cref="IEntryAppService.GetAllTrashedEntries"/>
        /// </summary>
        public async Task<ListResultDto<EntrySlimmedDto>> GetAllTrashedEntries()
        {
            var trashedEntries = await EntryStore.GetTrashedEntriesAsync();
            return new ListResultDto<EntrySlimmedDto>
            (
                trashedEntries.MapTo<List<EntrySlimmedDto>>()
            );
        }

        /// <summary>
        /// See <see cref="IEntryAppService.DeleteAllTrashedEntries"/>
        /// </summary>
        public async Task DeleteAllTrashedEntries()
        {
            await EntryStore.DeleteAllTrashedEntriesAsync();
        }

        /// <summary>
        /// Parses DD/MM/YYYY to associated date time object
        /// </summary>
        private DateTime? ParseDateString(string date)
        {
            DateTime parsedDate;
            if (DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate;
            }

            return null;
        }
    }
}
