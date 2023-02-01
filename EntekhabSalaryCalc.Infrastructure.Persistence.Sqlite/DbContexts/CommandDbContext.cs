using EntekhabSalaryCalc.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EntekhabSalaryCalc.Infrastructure.Persistence.Sqlite.DbContexts
{
    public class SqliteCommandDbContext : CommandDbContext
    {
        #region constractor
        public SqliteCommandDbContext(DbContextOptions<SqliteCommandDbContext> options) : base(options)
        {
        }
        #endregion
    }
}
