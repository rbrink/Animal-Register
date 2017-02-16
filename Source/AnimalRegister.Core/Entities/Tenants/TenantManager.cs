using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using AnimalRegister.Editions;
using AnimalRegister.Users;

namespace AnimalRegister.Tenants
{
    public partial class TenantManager : AbpTenantManager<Tenant, User>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TenantManager(
            IRepository<Tenant> tenantRepository,
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository,
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore
            ) : base(
            tenantRepository,
            tenantFeatureRepository,
            editionManager,
            featureValueStore
            )
        {
        }
    }
}