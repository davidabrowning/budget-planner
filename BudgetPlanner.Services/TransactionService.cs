using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Interfaces;
using BudgetPlanner.Core.Models;
using BudgetPlanner.Services.Mappers;

namespace BudgetPlanner.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public TransactionDto Add(TransactionDto dto)
        {
            Transaction model = TransactionMapper.ToModel(dto);
            Transaction createdTransaction = _transactionRepository.Add(model);
            return TransactionMapper.ToDto(createdTransaction);
        }

        public bool Delete(TransactionDto dto)
        {
            return _transactionRepository.Delete(dto.Id);
        }

        public IEnumerable<TransactionDto> GetAll()
        {
            List<TransactionDto> dtos = new();
            foreach (Transaction model in _transactionRepository.GetAll())
            {
                dtos.Add(TransactionMapper.ToDto(model));
            }
            return dtos;
        }

        public TransactionDto? GetById(int id)
        {
            Transaction? model = _transactionRepository.GetById(id);
            if (model == null)
                return null;
            return TransactionMapper.ToDto(model);
        }

        public TransactionDto? Update(TransactionDto dto)
        {
            Transaction model = TransactionMapper.ToModel(dto);
            Transaction? updatedTransaction = _transactionRepository.Update(model);
            if (updatedTransaction == null)
                return null;
            return TransactionMapper.ToDto(updatedTransaction);
        }
    }
}
