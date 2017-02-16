using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using AnimalRegister.EntityFramework;

namespace AnimalRegister.Migrations.Seeding
{
    public class DefaultLanguagesCreator
    {
        /// <summary>
        /// List of all initial seeded languages
        /// </summary>
        public static List<ApplicationLanguage> InitialLanguages { get; private set; }

        /// <summary>
        /// References the database context
        /// </summary>
        private readonly AnimalRegisterDatabaseContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        static DefaultLanguagesCreator()
        {
            InitialLanguages = new List<ApplicationLanguage>
            {
                new ApplicationLanguage(null, "nl", "Dutch"),
            };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public DefaultLanguagesCreator(AnimalRegisterDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates all default languages
        /// </summary>
        public void Create()
        {
            CreateLanguages();
        }

        /// <summary>
        /// Creates all default languages
        /// </summary>
        private void CreateLanguages()
        {
            foreach (var language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }

        /// <summary>
        /// Inserts an language depending if it already exists
        /// </summary>
        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            if (_context.Languages.Any(l =>
                l.TenantId == language.TenantId && l.Name == language.Name)
            ) return;

            _context.Languages.Add(language);
            _context.SaveChanges();
        }
    }
}
