using ExpenseManagement.DataLayer;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
			IEnumerable<ExpenseCategory> expenseCategories = db.ExpenseCategory.ToList();

			return View(expenseCategories);
		}
	}
}
