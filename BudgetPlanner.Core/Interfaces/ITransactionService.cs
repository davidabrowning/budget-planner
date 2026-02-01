using BudgetPlanner.Core.Dtos;

namespace BudgetPlanner.Core.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllAsync();
        Task<TransactionDto?> GetByIdAsync(int id);
        Task<TransactionDto> AddAsync(TransactionDto dto);
        Task<TransactionDto?> UpdateAsync(TransactionDto dto);
        Task<bool> DeleteAsync(TransactionDto dto);
    }
}
