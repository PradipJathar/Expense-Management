using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManagement.Models
{
	public class Expenses
	{
        [Key]
        public int ExpenseId { get; set; }


        [Required(ErrorMessage = "Please select expense date.")]
        [DataType(DataType.Date)]
        [Display(Name = "Expense Date")]
        public DateTime ExpenseDate { get; set; }


        [Required(ErrorMessage = "Please enter expense given to details.")]
        [MinLength(3, ErrorMessage = "The name of expense given to is too short.")]
        [Display(Name = "Paid To")]
        public string ExpenseGivenTo { get; set; }


        [Required(ErrorMessage = "Please enter expense amount.")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid expense amount." )]
        [Display(Name = "Expense Amount")]
        public double ExpenseAmount { get; set; }


        [Display(Name = "Expense Category")]
        public int ExpenseCategoryId { get; set; }


        [ForeignKey("ExpenseCategoryId")]
        public virtual ExpenseCategory? ExpenseCategory { get; set; }
    }
}
