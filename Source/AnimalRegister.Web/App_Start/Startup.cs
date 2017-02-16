using System;
using System.Configuration;
using Abp.Owin;
using AnimalRegister.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace AnimalRegister.Web
{
    public class Startup
    {
        /// <summary>
        /// Configurates Owin
        /// </summary>
        public void Configuration(IAppBuilder app)
        {
            app.UseAbp();
        }

        /// <summary>
        /// Returns a boolean from the app settings
        /// </summary>
        private static bool IsTrue(string appSettingName)
        {
            return string.Equals(
                ConfigurationManager.AppSettings[appSettingName],
                "true",
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}