using BudgetPlanner.Core.Interfaces;
using BudgetPlanner.Core.Models;

namespace BudgetPlanner.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private List<BudgetTransaction> _transactions = new();
        private static int nextId = 0;
        private readonly ApplicationDbContext _dbContext;

        public TransactionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BudgetTransaction Add(BudgetTransaction transaction)
        {
            transaction.Id = nextId++;
            _transactions.Add(transaction);
            return transaction;
        }

        public bool Delete(int id)
        {
            BudgetTransaction? transaction = GetById(id);
            if (transaction == null)
                return false;
            _transactions.Remove(transaction);
            return true;
        }

        public IEnumerable<BudgetTransaction> GetAll()
        {
            return _transactions.ToList();
        }

        public BudgetTransaction? GetById(int id)
        {
            return _transactions.FirstOrDefault(t => t.Id == id);
        }

        public BudgetTransaction? Update(BudgetTransaction transaction)
        {
            BudgetTransaction? existingTransaction = GetById(transaction.Id);
            if (existingTransaction == null)
                return null;

            existingTransaction.Amount = transaction.Amount;
            existingTransaction.Frequency = transaction.Frequency;
            existingTransaction.Category = transaction.Category;
            existingTransaction.Comment = transaction.Comment;
            return existingTransaction;
        }
    }
}
