using BudgetPlanner.Core.Models;

namespace BudgetPlanner.Core.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<BudgetTransaction>> GetAllAsync();
        Task<BudgetTransaction?> GetByIdAsync(int id);
        Task<BudgetTransaction> AddAsync(BudgetTransaction transaction);
        Task<BudgetTransaction?> UpdateAsync(BudgetTransaction transaction);
        Task<bool> DeleteAsync(int id);
    }
}
