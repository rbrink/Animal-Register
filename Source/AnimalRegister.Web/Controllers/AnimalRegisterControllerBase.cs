using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using Microsoft.AspNet.Identity;

namespace AnimalRegister.Web.Controllers
{
    public class AnimalRegisterControllerBase : AbpController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected AnimalRegisterControllerBase()
        {
            LocalizationSourceName = AnimalRegisterConstants.LocalizationSourceName;
        }

        /// <summary>
        /// Validates the model
        /// </summary>
        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        /// <summary>
        /// Validates the identity
        /// </summary>
        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}