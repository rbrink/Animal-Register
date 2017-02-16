using System.Linq;
using AnimalRegister.EntityFramework;
using AnimalRegister.Tenants;

namespace AnimalRegister.Migrations.Seeding
{
    public class DefaultTenantCreator
    {
        /// <summary>
        /// References the database context
        /// </summary>
        private readonly AnimalRegisterDatabaseContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        public DefaultTenantCreator(AnimalRegisterDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates default tenants
        /// </summary>
        public void Create()
        {
            CreateTenants();
        }

        /// <summary>
        /// Creates default tenants
        /// </summary>
        private void CreateTenants()
        {
            // Default tenant
            var defaultTenant = _context.Tenants.FirstOrDefault(t =>
                t.TenancyName == Tenant.DefaultTenantName
            );

            if (defaultTenant == null)
            {
                _context.Tenants.Add(
                    new Tenant
                    {
                        TenancyName = Tenant.DefaultTenantName,
                        Name = Tenant.DefaultTenantName
                    }
                );
                _context.SaveChanges();
            }
        }
    }
}
