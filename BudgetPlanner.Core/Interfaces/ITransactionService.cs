using BudgetPlanner.Core.Dtos;

namespace BudgetPlanner.Core.Interfaces
{
    public interface ITransactionService
    {
        IEnumerable<TransactionDto> GetAll();
        TransactionDto? GetById(int id);
        TransactionDto Add(TransactionDto dto);
        TransactionDto? Update(TransactionDto dto);
        bool Delete(TransactionDto dto);
    }
}
