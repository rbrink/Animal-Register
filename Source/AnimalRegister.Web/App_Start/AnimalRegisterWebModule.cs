using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Configuration.Startup;
using Abp.Hangfire;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.SignalR;
using Abp.Zero.Configuration;
using AnimalRegister.Application;
using AnimalRegister.EntityFramework;
using AnimalRegister.WebApi;

namespace AnimalRegister.Web
{
    [DependsOn(
        typeof(AnimalRegisterDataModule),
        typeof(AnimalRegisterApplicationModule),
        typeof(AnimalRegisterWebApiModule),
        typeof(AbpWebSignalRModule),
        typeof(AbpHangfireModule),
        typeof(AbpWebMvcModule))]
    public class AnimalRegisterWebModule : AbpModule
    {
        /// <summary>
        /// Called before initialization
        /// </summary>
        public override void PreInitialize()
        {
            // Enable CSRF/XSRF
            Configuration.Modules.AbpWeb().AntiForgery.IsEnabled = true;

            // Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            // Configure navigation/menu
            Configuration.Navigation.Providers.Add<AnimalRegisterNavigationProvider>();

            // Configurating localization
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    AnimalRegisterConstants.LocalizationSourceName,
                    new XmlFileLocalizationDictionaryProvider(
                        HttpContext.Current.Server.MapPath("~/Localization/Source")
                        )
                    )
                );
        }

        /// <summary>
        /// Initializes this module
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}