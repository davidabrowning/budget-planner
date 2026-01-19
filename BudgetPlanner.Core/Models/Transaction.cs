using BudgetPlanner.Core.Enums;

namespace BudgetPlanner.Core.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Month Month { get; set; }
        public int Year { get; set; }
        public Frequency Frequency { get; set; }
        public Category Category { get; set; }
        public string? Comment { get; set; }
    }
}
