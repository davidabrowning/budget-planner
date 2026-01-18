using BudgetPlanner.Core.Enums;

namespace BudgetPlanner.Core.Dtos
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int Amount { get; set; } = 0;
        public Month Month { get; set; } = (Month)DateTime.Now.Month;
        public int Year { get; set; } = DateTime.Now.Year;
        public Frequency Frequency { get; set; } = Frequency.OneTime;
        public Category Category { get; set; } = Category.Unknown;
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
