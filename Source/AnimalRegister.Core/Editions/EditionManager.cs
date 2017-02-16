using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Domain.Repositories;

namespace AnimalRegister.Editions
{
    public partial class EditionManager : AbpEditionManager
    {
        /// <summary>
        /// Name of the default edition scheme
        /// </summary>
        public const string DefaultEditionName = "Standard";

        /// <summary>
        /// Constructor
        /// </summary>
        public EditionManager(
            IRepository<Edition> editionRepository,
            IAbpZeroFeatureValueStore featureValueStore)
            : base(
            editionRepository,
            featureValueStore
            )
        {
        }
    }
}
