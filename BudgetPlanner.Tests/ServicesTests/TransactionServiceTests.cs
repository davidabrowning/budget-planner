using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Enums;
using BudgetPlanner.Services;
using BudgetPlanner.Tests.ServicesTests.Fake;

namespace BudgetPlanner.Tests.ServicesTests
{
    public class TransactionServiceTests
    {
        private TransactionService _transactionService;

        public TransactionServiceTests()
        {
            FakeTransactionRepository fakeRepo = new();
            _transactionService = new(fakeRepo);
        }

        [Fact]
        public async Task Add_WhenCalled_AddTransaction()
        {
            // Arrange
            TransactionDto transactionDto = new() { Amount = 42 };

            // Act
            await _transactionService.AddAsync(transactionDto);

            // Assert
            Assert.Contains(transactionDto, await _transactionService.GetAllAsync());
        }

        [Fact]
        public async Task AddedTransaction_WhenNoFrequncyGiven_ShouldBeOneTime()
        {
            // Arrange
            TransactionDto transactionDto = new();

            // Act
            TransactionDto addedTransactionDto = await _transactionService.AddAsync(transactionDto);

            // Assert
            Assert.Equal(Frequency.OneTime, addedTransactionDto.Frequency);
        }
    }
}
