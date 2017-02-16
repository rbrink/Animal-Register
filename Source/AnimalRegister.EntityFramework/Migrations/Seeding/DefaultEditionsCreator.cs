using System.Linq;
using Abp.Application.Editions;
using AnimalRegister.Editions;
using AnimalRegister.EntityFramework;

namespace AnimalRegister.Migrations.Seeding
{
    public class DefaultEditionsCreator
    {
        /// <summary>
        /// References the database context
        /// </summary>
        private readonly AnimalRegisterDatabaseContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        public DefaultEditionsCreator(AnimalRegisterDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates default editions
        /// </summary>
        public void Create()
        {
            CreateEditions();
        }

        /// <summary>
        /// Creates default editions
        /// </summary>
        private void CreateEditions()
        {
            var defaultEdition = _context.Editions.FirstOrDefault(e =>
                e.Name == EditionManager.DefaultEditionName
            );

            if (defaultEdition == null)
            {
                defaultEdition = new Edition
                {
                    Name = EditionManager.DefaultEditionName,
                    DisplayName = EditionManager.DefaultEditionName
                };

                _context.Editions.Add(defaultEdition);
                _context.SaveChanges();
            }
        }
    }
}
