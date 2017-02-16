using Abp.Dependency;

namespace AnimalRegister.Application.Management
{
    /// <summary>
    /// This interface must be implemented by all 'management' application 
    /// services to identify them by convention
    /// </summary>
    public interface IManagementApplicationService : ITransientDependency
    {
    }
}
