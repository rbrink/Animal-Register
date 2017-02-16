using Abp.Authorization;
using AnimalRegister.Authorization.Roles;
using AnimalRegister.Tenants;
using AnimalRegister.Users;

namespace AnimalRegister.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
