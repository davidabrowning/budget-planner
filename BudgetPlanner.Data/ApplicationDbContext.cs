using BudgetPlanner.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BudgetPlanner;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public DbSet<BudgetTransaction> BudgetTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
