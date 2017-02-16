using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using AnimalRegister.Authorization.Roles;

namespace AnimalRegister.Users
{
    public class UserManager : AbpUserManager<Role, User>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserManager(
            UserStore store,
            RoleManager roleManager,
            IPermissionManager permissionManager,
            IUnitOfWorkManager unitOfWorkManager,
            ICacheManager cacheManager,
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IOrganizationUnitSettings organizationUnitSettings,
            ILocalizationManager localizationManager,
            IdentityEmailMessageService emailService,
            ISettingManager settingManager,
            IUserTokenProviderAccessor userTokenProviderAccessor
            )
            : base(
                  store,
                  roleManager,
                  permissionManager,
                  unitOfWorkManager,
                  cacheManager,
                  organizationUnitRepository,
                  userOrganizationUnitRepository,
                  organizationUnitSettings,
                  localizationManager,
                  emailService,
                  settingManager,
                  userTokenProviderAccessor
            )
        {
        }
    }
}
