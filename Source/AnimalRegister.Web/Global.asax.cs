using System;
using System.Web.Mvc;
using Abp.MultiTenancy;
using Abp.Web;
using AnimalRegister.Tenants;
using AnimalRegister.Users;
using Castle.MicroKernel.Registration;

namespace AnimalRegister.Web
{
    public class Global : AbpWebApplication<AnimalRegisterWebModule>
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        protected override void Application_Start(object sender, EventArgs e)
        {
            // Configurating tenant container
            AbpBootstrapper.IocManager.IocContainer.Register(
                Component
                    .For<ITenantCache, TenantCache<Tenant, User>>()
                    .ImplementedBy<TenantCache<Tenant, User>>()
                    .LifestyleTransient());

            // Removing unneeded MVC headers
            MvcHandler.DisableMvcResponseHeader = true;

            base.Application_Start(sender, e);
        }

        /// <summary>
        /// Remove rudimentary headers
        /// </summary>
        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            try
            {
                Response.Headers.Remove("X-Powered-By");
                Response.Headers.Remove("X-AspNet-Version");
                Response.Headers.Remove("X-AspNetMvc-Version");
                Response.Headers.Remove("Server");
            }
            catch { }
        }
    }
}