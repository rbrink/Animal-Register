using System.Data.SqlClient;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace AnimalRegister.Domain.Repositories
{
    /// <summary>
    /// This interface is implemented by all repositories which are required to allow custom SQL queries
    /// </summary>
    public interface ISqlRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Executes an SQL query
        /// </summary>
        Task<SqlDataReader> ExecuteSqlAsync(string query);
    }
}
