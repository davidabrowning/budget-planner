using BudgetPlanner.Core.Enums;

namespace BudgetPlanner.Core.Dtos
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Frequency Frequency { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
    }
}
