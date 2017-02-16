using System.ComponentModel.DataAnnotations.Schema;
using Abp.MultiTenancy;
using AnimalRegister.Users;

namespace AnimalRegister.Tenants
{
    [Table("Tenamts")]
    public class Tenant : AbpTenant<User>
    {
    }
}
