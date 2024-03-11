using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
	public class ExpenseCategory
	{
		[Key]
        public int ExpenseCategoryId { get; set; }


        [Display(Name = "Expense Category Name")]
        public string ExpenseCategoryName { get; set; }		
    }
}
