using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Models;

namespace BudgetPlanner.Services.Mappers
{
    public static class TransactionMapper
    {
        public static BudgetTransaction ToModel(TransactionDto dto)
        {
            BudgetTransaction model = new()
            {
                Id = dto.Id,
                Amount = dto.Amount,
                Month = dto.Month,
                Year = dto.Year,
                Frequency = dto.Frequency,
                Category = dto.Category,
                Comment = dto.Comment
            };
            return model;
        }

        public static TransactionDto ToDto(BudgetTransaction model)
        {
            TransactionDto dto = new()
            {
                Id = model.Id,
                Amount = model.Amount,
                Month = model.Month,
                Year = model.Year,
                Frequency = model.Frequency,
                Category = model.Category,
                Comment = model.Comment ?? string.Empty
            };
            return dto;
        }
    }
}
