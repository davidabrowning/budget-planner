using BudgetPlanner.Core.Enums;

namespace BudgetPlanner.Core.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Frequency Frequency { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
    }
}
