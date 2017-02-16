using Abp.Dependency;
using Abp.Events.Bus.Exceptions;
using Abp.Events.Bus.Handlers;

namespace AnimalRegister.Web
{
    public class AnimalRegisterExceptionHandler : IEventHandler<AbpHandledExceptionData>, ITransientDependency
    {
        /// <summary>
        /// Handles all abp events
        /// </summary>
        public void HandleEvent(AbpHandledExceptionData eventData)
        {
        }
    }
}