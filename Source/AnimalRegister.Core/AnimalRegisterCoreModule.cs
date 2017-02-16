using System.Reflection;
using Abp.Modules;
using Abp.Zero;
using Abp.Zero.Configuration;
using AnimalRegister.Authorization.Roles;
using AnimalRegister.Configuration;
using AnimalRegister.Tenants;
using AnimalRegister.Users;

namespace AnimalRegister.Core
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AnimalRegisterCoreModule : AbpModule
    {
        /// <summary>
        /// Triggered before initialize
        /// </summary>
        public override void PreInitialize()
        {
            // Setting auditing to all
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Configurating entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            // Enabling multi tenancy
            Configuration.MultiTenancy.IsEnabled = false;

            // Configurating providers
            Configuration.Settings.Providers.Add<AnimalRegisterSettingProvider>();

        }

        /// <summary>
        /// Initializes this module
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
