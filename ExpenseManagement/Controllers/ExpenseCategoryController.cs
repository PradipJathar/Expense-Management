using ExpenseManagement.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
	public class ExpenseCategoryController : Controller
	{
		private readonly ExpenseManagementDBContext db;

		public ExpenseCategoryController(ExpenseManagementDBContext context)
		{
			db = context;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
