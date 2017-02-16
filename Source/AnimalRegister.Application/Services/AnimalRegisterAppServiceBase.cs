using Abp.Application.Services;

namespace AnimalRegister.Application
{
    public abstract class AnimalRegisterAppServiceBase : ApplicationService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AnimalRegisterAppServiceBase()
        {
            LocalizationSourceName = AnimalRegisterConstants.LocalizationSourceName;
        }
    }
}
