using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.DataLayer
{
	public class ExpenseManagementDBContext : DbContext
	{
		public ExpenseManagementDBContext(DbContextOptions options) : base(options)
		{
		}
	}
}
