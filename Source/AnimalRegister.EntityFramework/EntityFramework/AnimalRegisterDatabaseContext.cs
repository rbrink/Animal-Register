using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using AnimalRegister.Authorization.Roles;
using AnimalRegister.Entries;
using AnimalRegister.Tenants;
using AnimalRegister.Users;

namespace AnimalRegister.EntityFramework
{
    public class AnimalRegisterDatabaseContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /// <summary>
        /// Entrie collection
        /// </summary>
        public virtual IDbSet<Entry> Entries { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public AnimalRegisterDatabaseContext() : base("Default") { }

        /// <summary>
        /// Constructor
        /// </summary>
        public AnimalRegisterDatabaseContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        /// <summary>
        /// Constructor
        /// </summary>
        public AnimalRegisterDatabaseContext(DbConnection connection) : base(connection, true) { }

        /// <summary>
        /// On model override in order to rename framework tables
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("");
        }
    }
}
