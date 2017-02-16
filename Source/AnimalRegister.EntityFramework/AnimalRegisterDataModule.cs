using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using AnimalRegister.Core;

namespace AnimalRegister.EntityFramework
{
    [DependsOn(
        typeof(AbpZeroEntityFrameworkModule),
        typeof(AnimalRegisterCoreModule))]
    public class AnimalRegisterDataModule : AbpModule
    {
        /// <summary>
        /// Triggered before initialize
        /// </summary>
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AnimalRegisterDatabaseContext>());
            Configuration.DefaultNameOrConnectionString = "Default";
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
