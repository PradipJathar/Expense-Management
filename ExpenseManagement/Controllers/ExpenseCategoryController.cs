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


        public IActionResult Create(ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseCategory.Add(expenseCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult GetExpenseCategoryDetailsForUpdate(int? id)
        {
            var expenseCategory = db.ExpenseCategory.Find(id);

            if (expenseCategory == null)
            {
                return NotFound();
            }

            return View(expenseCategory);
        }


        [HttpPost]
        public IActionResult Update(ExpenseCategory expenseCategory)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseCategory.Update(expenseCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult GetExpenseCategoryDetailsForDelete(int? id)
        {
            var expenseCategory = db.ExpenseCategory.Find(id);

            if (expenseCategory == null)
            {
                return NotFound();
            }

            return View(expenseCategory);
        }


        [HttpPost]
        public IActionResult Delete(int? ExpenseCategoryId)
        {
            var expenseCategory = db.ExpenseCategory.Find(ExpenseCategoryId);

            if (expenseCategory == null)
            {
                return NotFound();
            }

            db.ExpenseCategory.Remove(expenseCategory);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
