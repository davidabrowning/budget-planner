using BudgetPlanner.Core.Interfaces;
using BudgetPlanner.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Tests.ServicesTests.Fake
{
    public class FakeTransactionRepository : ITransactionRepository
    {
        private List<BudgetTransaction> _transactions = new();

        public async Task<BudgetTransaction> AddAsync(BudgetTransaction transaction)
        {
            _transactions.Add(transaction);
            return transaction;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            BudgetTransaction? transaction = await GetByIdAsync(id);
            if (transaction == null)
                return false;
            _transactions.Remove(transaction);
            return true;
        }

        public async Task<IEnumerable<BudgetTransaction>> GetAllAsync()
        {
            return _transactions.ToList();
        }

        public async Task<BudgetTransaction?> GetByIdAsync(int id)
        {
            return _transactions.FirstOrDefault(t => t.Id == id);
        }

        public async Task<BudgetTransaction?> UpdateAsync(BudgetTransaction transaction)
        {
            BudgetTransaction? existingTransaction = await GetByIdAsync(transaction.Id);
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
