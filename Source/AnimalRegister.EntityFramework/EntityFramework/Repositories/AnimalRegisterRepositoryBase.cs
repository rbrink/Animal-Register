using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace AnimalRegister.EntityFramework.Repositories
{
    public abstract partial class AnimalRegisterRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<AnimalRegisterDatabaseContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected AnimalRegisterRepositoryBase(IDbContextProvider<AnimalRegisterDatabaseContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }

    public abstract partial class AnimalRegisterRepositoryBase<TEntity> : AnimalRegisterRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected AnimalRegisterRepositoryBase(IDbContextProvider<AnimalRegisterDatabaseContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
