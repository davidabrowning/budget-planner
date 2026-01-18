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

        public Transaction? Update(Transaction transaction)
        {
            Transaction? existingTransaction = GetById(transaction.Id);
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
