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

        public override bool Equals(object? obj)
        {
            return obj is TransactionDto dto &&
                Amount == dto.Amount &&
                Frequency == dto.Frequency &&
                Category == dto.Category &&
                Comment == dto.Comment;
        }
    }
}
