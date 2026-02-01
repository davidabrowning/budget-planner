using BudgetPlanner.Core.Models;

namespace BudgetPlanner.Core.Interfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<BudgetTransaction> GetAll();
        BudgetTransaction? GetById(int id);
        BudgetTransaction Add(BudgetTransaction transaction);
        BudgetTransaction? Update(BudgetTransaction transaction);
        bool Delete(int id);
    }
}
