using EntekhabSalaryCalc.Application.Contracts.ViewModels.EmployeeManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Infrastructure.ReadModules.DbContexts
{
    public class QueryDbContext : DbContext
    {
        #region constractors
        public QueryDbContext(DbContextOptions<QueryDbContext> options) : base(options)
        {

        }
        #endregion

        #region properties
        public DbSet<EmployeeVM> Employees { get; set; } = default!;

        #endregion

        #region protected methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QueryDbContext).Assembly);
        }
        #endregion
    }
}
