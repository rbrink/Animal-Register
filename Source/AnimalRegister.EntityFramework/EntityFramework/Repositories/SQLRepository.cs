using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.EntityFramework;
using AnimalRegister.Domain.Repositories;

namespace AnimalRegister.EntityFramework.Repositories
{
    public class SqlRepository<TEntity, TPrimaryKey> : AnimalRegisterRepositoryBase<TEntity, TPrimaryKey>, ISqlRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SqlRepository(IDbContextProvider<AnimalRegisterDatabaseContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        /// <summary>
        /// Executes an SQL query
        /// </summary>
        /// /// <param name="query">SQL query to be executed on the database</param>
        public async Task<SqlDataReader> ExecuteSqlAsync(string query)
        {
            using (var command = new SqlCommand())
            {
                var connection = (SqlConnection)GetDbContext().Database.Connection;
                if (connection.State == ConnectionState.Closed) await connection.OpenAsync();

                command.CommandText = query;
                command.Connection = connection;

                return await command.ExecuteReaderAsync();
            }
        }
    }
}
