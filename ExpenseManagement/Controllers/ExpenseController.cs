using ExpenseManagement.DataLayer;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
			IEnumerable<Expenses> expensesList = db.Expenses.Include(e => e.ExpenseCategory).ToList();

			return View(expensesList);
		}

		public IActionResult Create(Expenses expenses)
		{
			IEnumerable<SelectListItem> getExpenseCategoryList = db.ExpenseCategory.Select(ec => new SelectListItem
			{
				Text = ec.ExpenseCategoryName,
				Value = ec.ExpenseCategoryId.ToString()
			});

			ViewBag.PopulateExpenseCategory = getExpenseCategoryList;

			if (ModelState.IsValid)
			{
				db.Expenses.Add(expenses);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View();
		}

		public IActionResult GetExpenseDetailsForUpdate(int? id)
		{
            IEnumerable<SelectListItem> getExpenseCategoryList = db.ExpenseCategory.Select(ec => new SelectListItem
            {
                Text = ec.ExpenseCategoryName,
                Value = ec.ExpenseCategoryId.ToString()
            });

            ViewBag.PopulateExpenseCategory = getExpenseCategoryList;

            var expense = db.Expenses.Find(id);

			if (expense == null)
			{
				return NotFound();
			}

			return View(expense);
		}

		[HttpPost]
        public IActionResult Update(Expenses expenses)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Update(expenses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

		public IActionResult GetExpenseDetailsForDelete(int? id)
		{
            IEnumerable<SelectListItem> getExpenseCategoryList = db.ExpenseCategory.Select(ec => new SelectListItem
            {
                Text = ec.ExpenseCategoryName,
                Value = ec.ExpenseCategoryId.ToString()
            });

            ViewBag.PopulateExpenseCategory = getExpenseCategoryList;

            var expense = db.Expenses.Find(id);

			if (expense == null)
			{
				return NotFound();
			}

			return View(expense);
		}

		[HttpPost]
        public IActionResult Delete(int? ExpenseId)
        {
            var expense = db.Expenses.Find(ExpenseId);

            if (expense == null)
            {
                return NotFound();
            }

			db.Expenses.Remove(expense);
			db.SaveChanges();

			return RedirectToAction("Index");            
        }

    }
}
