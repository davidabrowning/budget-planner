using BudgetPlanner.Core.Models;

namespace BudgetPlanner.Core.Interfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAll();
        Transaction? GetById(int id);
        Transaction Add(Transaction transaction);
        Transaction? Update(Transaction transaction);
        bool Delete(int id);
    }
}
