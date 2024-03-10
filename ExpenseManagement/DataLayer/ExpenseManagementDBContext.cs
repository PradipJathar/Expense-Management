using ExpenseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.DataLayer
{
	public class ExpenseManagementDBContext : DbContext
	{
		public ExpenseManagementDBContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Expenses> Expenses { get; set; }

		public DbSet<ExpenseCategory> ExpenseCategory { get; set; }
	}
}
