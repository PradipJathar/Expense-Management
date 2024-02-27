using ExpenseManagement.DataLayer;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
	public class ExpenseController : Controller
	{
		public readonly ExpenseManagementDBContext db;

        public ExpenseController(ExpenseManagementDBContext context)
        {
			db = context;
        }

        public IActionResult Index()
		{
			IEnumerable<Expenses> expensesList = db.Expenses.ToList();

			return View(expensesList);
		}
	}
}
