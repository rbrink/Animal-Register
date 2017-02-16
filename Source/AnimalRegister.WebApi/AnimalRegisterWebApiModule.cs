using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using AnimalRegister.Application;
using AnimalRegister.Application.Management;

namespace AnimalRegister.WebApi
{
    [DependsOn(
        typeof(AbpWebApiModule),
        typeof(AnimalRegisterApplicationModule))]
    public class AnimalRegisterWebApiModule : AbpModule
    {
        /// <summary>
        /// Initializes this module
        /// </summary>
        public override void Initialize()
        {
            // Loading all classes in this assembly
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // Loading all management services
            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IManagementApplicationService>(typeof(AnimalRegisterApplicationModule).Assembly, "mgmt")
                .Build();
        }
    }
}
