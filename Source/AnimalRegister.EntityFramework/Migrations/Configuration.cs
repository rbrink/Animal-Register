using System.Data.Entity.Migrations;
using AnimalRegister.Migrations.Seeding;

namespace AnimalRegister.EntityFramework.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<AnimalRegisterDatabaseContext>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AnimalRegister";
        }

        /// <summary>
        /// Method responsible for the database seeding
        /// </summary>
        protected override void Seed(AnimalRegisterDatabaseContext context)
        {
            // Host seed
            new InitialHostDbBuilder(context).Create();

            // Default tenant seed (in host database).
            new DefaultTenantCreator(context).Create();
        }
    }
}
