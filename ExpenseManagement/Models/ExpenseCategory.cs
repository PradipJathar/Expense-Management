using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
	public class ExpenseCategory
	{
		[Key]
        public int ExpenseCategoryId { get; set; }

        public string ExpenseCategoryName { get; set; }		
    }
}
