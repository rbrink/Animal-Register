using System.ComponentModel.DataAnnotations.Schema;
using Abp.Authorization.Users;

namespace AnimalRegister.Users
{
    [Table("Users")]
    public class User : AbpUser<User>
    {
    }
}
