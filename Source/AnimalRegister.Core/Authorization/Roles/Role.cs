using System.ComponentModel.DataAnnotations.Schema;
using Abp.Authorization.Roles;
using AnimalRegister.Users;

namespace AnimalRegister.Authorization.Roles
{
    [Table("Roles")]
    public class Role : AbpRole<User>
    {
    }
}
