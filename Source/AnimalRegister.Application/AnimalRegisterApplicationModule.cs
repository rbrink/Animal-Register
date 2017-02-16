using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using AnimalRegister.Core;

namespace AnimalRegister.Application
{
    [DependsOn(typeof(AnimalRegisterCoreModule), typeof(AbpAutoMapperModule))]
    public class AnimalRegisterApplicationModule : AbpModule
    {
        /// <summary>
        /// Initializes this module
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
