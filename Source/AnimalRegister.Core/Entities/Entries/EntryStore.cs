using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Uow;
using AnimalRegister.Domain.Bases;
using AnimalRegister.Domain.Repositories;

namespace AnimalRegister.Entries
{
    public class EntryStore : AnimalRegisterStoreBase
    {
        /// <summary>
        /// Repository used to read-out entries
        /// </summary>
        private readonly ISqlRepository<Entry, long> _entryRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public EntryStore(ISqlRepository<Entry, long> entryRepository)
        {
            _entryRepository = entryRepository;
        }

        /// <summary>
        /// Inserts given entity
        /// </summary>
        [UnitOfWork]
        public async Task<Entry> CreateAndInsertEntryAsync(
            DateTime? dateIn,
            string specy,
            string location,
            string via,
            string diagnose,
            DateTime? dateOut,
            string result)
        {
            var entry = new Entry
            {
                DateIn = dateIn,
                Specy = specy,
                Location = location,
                Via = via,
                Diagnose = diagnose,
                DateOut = dateOut,
                Result = result
            };

            return await InsertAsync(entry);
        }

        /// <summary>
        /// Inserts given entity
        /// </summary>
        [UnitOfWork]
        public async Task<Entry> InsertAsync(Entry entry)
        {
            return await _entryRepository.InsertAsync(entry);
        }

        /// <summary>
        /// Deletes given entity
        /// </summary>
        [UnitOfWork]
        public async Task DeleteAsync(long entryId)
        {
            using (UnitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                var entry = await _entryRepository.FirstOrDefaultAsync(entryId);
                if (entry != null) await DeleteAsync(entry);
            }
        }

        /// <summary>
        /// Deletes given entity
        /// </summary>
        [UnitOfWork]
        public async Task DeleteAsync(Entry entry)
        {
            if (!entry.IsDeleted)
            {
                await _entryRepository.DeleteAsync(entry);
            }
            else
            {
                var reader = await _entryRepository.ExecuteSqlAsync(
                    $"DELETE FROM [Entries] where [Id] = {entry.Id} AND [IsDeleted] = 1"
                );

                if (!reader.IsClosed) reader.Close();
            }
        }

        /// <summary>
        /// Restores given entity
        /// </summary>
        [UnitOfWork]
        public async Task RestoreAsync(long entryId)
        {
            using (UnitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                var entry = await _entryRepository.FirstOrDefaultAsync(entryId);
                if (entry != null && entry.IsDeleted) Restore(entry);
            }
        }

        /// <summary>
        /// Restores given entity
        /// </summary>
        [UnitOfWork]
        public void Restore(Entry entry)
        {
            if (entry.IsDeleted) entry.IsDeleted = false;
        }

        /// <summary>
        /// Returns a list of all trashed entries
        /// </summary>
        [UnitOfWork]
        public async Task<List<Entry>> GetTrashedEntriesAsync()
        {
            var entries = new List<Entry>();
            using (UnitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                entries = await _entryRepository.GetAllListAsync(x =>
                    x.IsDeleted
                );
            }
            return entries;
        }

        /// <summary>
        /// Deletes all 'soft' deleted entries
        /// </summary>
        [UnitOfWork]
        public async Task DeleteAllTrashedEntriesAsync()
        {
            var trashedEntries = await GetTrashedEntriesAsync();
            foreach (var entry in trashedEntries) await DeleteAsync(entry);
        }
    }
}
