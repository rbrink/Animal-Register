using System.Collections.Generic;
using Abp.Configuration;

namespace AnimalRegister.Configuration
{
    public class AnimalRegisterSettingProvider : SettingProvider
    {
        /// <summary>
        /// Default value used to initialize settings
        /// </summary>
        public const string DefaultValue = "";

        /// <summary>
        /// Returns a list of all static settings
        /// </summary>
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(
                    AnimalRegisterSettingNames.ApplicationName,
                    "Register"
                )
            };
        }
    }
}
