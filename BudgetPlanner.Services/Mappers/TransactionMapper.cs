using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Models;

namespace BudgetPlanner.Services.Mappers
{
    public static class TransactionMapper
    {
        public static Transaction ToModel(TransactionDto dto)
        {
            Transaction model = new()
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

        public static TransactionDto ToDto(Transaction model)
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
