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

        public BudgetTransaction Add(BudgetTransaction transaction)
        {
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
