using BudgetPlanner.Core.Interfaces;
using BudgetPlanner.Core.Models;

namespace BudgetPlanner.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> _transactions = new();

        public Transaction Add(Transaction transaction)
        {
            _transactions.Add(transaction);
            return transaction;
        }

        public bool Delete(int id)
        {
            Transaction? transaction = GetById(id);
            if (transaction == null)
                return false;
            _transactions.Remove(transaction);
            return true;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _transactions.ToList();
        }

        public Transaction? GetById(int id)
        {
            return _transactions.FirstOrDefault(t => t.Id == id);
        }

        public bool Update(Transaction transaction)
        {
            Transaction? existingTransaction = GetById(transaction.Id);
            if (existingTransaction == null)
                return false;

            existingTransaction.Amount = transaction.Amount;
            existingTransaction.Frequency = transaction.Frequency;
            existingTransaction.Category = transaction.Category;
            existingTransaction.Comment = transaction.Comment;
            return true;
        }
    }
}
