using Abp.Threading;
using Abp.Web.Mvc.Views;

namespace AnimalRegister.Web.Views
{
    public abstract class AnimalRegisterWebViewPageBase : AnimalRegisterWebViewPageBase<dynamic>
    {
    }

    public abstract class AnimalRegisterWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AnimalRegisterWebViewPageBase()
        {
            LocalizationSourceName = AnimalRegisterConstants.LocalizationSourceName;
        }

        /// <summary>
        /// Gets current value of a application setting
        /// </summary>
        public string GetApplicationSettingValue(string name)
        {
            return AsyncHelper.RunSync(() =>
                SettingManager.GetSettingValueForApplicationAsync(name)
            );
        }
    }
}