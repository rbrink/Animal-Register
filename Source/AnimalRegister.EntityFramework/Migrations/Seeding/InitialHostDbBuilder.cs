using AnimalRegister.EntityFramework;
using EntityFramework.DynamicFilters;

namespace AnimalRegister.Migrations.Seeding
{
    public class InitialHostDbBuilder
    {
        /// <summary>
        /// References the database context
        /// </summary>
        private readonly AnimalRegisterDatabaseContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        public InitialHostDbBuilder(AnimalRegisterDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates everything a host needs
        /// </summary>
        public void Create()
        {
            _context.DisableAllFilters();
            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
        }
    }
}
