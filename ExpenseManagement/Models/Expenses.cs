using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
	public class Expenses
	{
        [Key]
        public int ExpenseId { get; set; }

        [Required]
        public DateTime ExpenseDate { get; set; }

        [Required]
        public string ExpenseGivenTo { get; set; }

        [Required]
        public double ExpenseAmount { get; set; }         
    }
}
