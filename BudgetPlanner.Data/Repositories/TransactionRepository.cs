using BudgetPlanner.Core.Interfaces;
using BudgetPlanner.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.Data.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        //private readonly ApplicationDbContext context;
        public TransactionRepository()
        {
            //context = new();
        }
        public async Task<BudgetTransaction> AddAsync(BudgetTransaction transaction)
        {
            ApplicationDbContext context = new();
            await context.AddAsync(transaction);
            await context.SaveChangesAsync();
            return transaction;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            ApplicationDbContext context = new();
            BudgetTransaction? transaction = await GetByIdAsync(id);
            if (transaction == null)
                return false;

            context.Remove(transaction);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<BudgetTransaction>> GetAllAsync()
        {
            ApplicationDbContext context = new();
            return await context.BudgetTransactions.ToListAsync();
        }

        public async Task<BudgetTransaction?> GetByIdAsync(int id)
        {
            ApplicationDbContext context = new();
            return await context.BudgetTransactions.FirstOrDefaultAsync(bt => bt.Id == id);
        }

        public async Task<BudgetTransaction?> UpdateAsync(BudgetTransaction transaction)
        {
            ApplicationDbContext context = new();
            BudgetTransaction? existingTransaction = await GetByIdAsync(transaction.Id);
            if (existingTransaction == null)
                return null;

            existingTransaction.Amount = transaction.Amount;
            existingTransaction.Frequency = transaction.Frequency;
            existingTransaction.Category = transaction.Category;
            existingTransaction.Comment = transaction.Comment;
            context.Update(existingTransaction);
            await context.SaveChangesAsync();

            return existingTransaction;
        }
    }
}
