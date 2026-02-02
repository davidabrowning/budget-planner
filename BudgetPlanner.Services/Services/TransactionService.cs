using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Interfaces;
using BudgetPlanner.Core.Models;
using BudgetPlanner.Services.Mappers;

namespace BudgetPlanner.Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<TransactionDto> AddAsync(TransactionDto dto)
        {
            BudgetTransaction model = TransactionMapper.ToModel(dto);
            BudgetTransaction createdTransaction = await _transactionRepository.AddAsync(model);
            return TransactionMapper.ToDto(createdTransaction);
        }

        public async Task<bool> DeleteAsync(TransactionDto dto)
        {
            return await _transactionRepository.DeleteAsync(dto.Id);
        }

        public async Task<IEnumerable<TransactionDto>> GetAllAsync()
        {
            List<TransactionDto> dtos = new();
            foreach (BudgetTransaction model in await _transactionRepository.GetAllAsync())
            {
                dtos.Add(TransactionMapper.ToDto(model));
            }
            return dtos;
        }

        public async Task<TransactionDto?> GetByIdAsync(int id)
        {
            BudgetTransaction? model = await _transactionRepository.GetByIdAsync(id);
            if (model == null)
                return null;
            return TransactionMapper.ToDto(model);
        }

        public async Task<TransactionDto?> UpdateAsync(TransactionDto dto)
        {
            BudgetTransaction model = TransactionMapper.ToModel(dto);
            BudgetTransaction? updatedTransaction = await _transactionRepository.UpdateAsync(model);
            if (updatedTransaction == null)
                return null;
            return TransactionMapper.ToDto(updatedTransaction);
        }
    }
}
