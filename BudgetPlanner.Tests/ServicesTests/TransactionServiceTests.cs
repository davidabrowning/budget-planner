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
        public void Add_WhenCalled_AddTransaction()
        {
            // Arrange
            TransactionDto transactionDto = new() { Amount = 42 };

            // Act
            _transactionService.Add(transactionDto);

            // Assert
            Assert.Contains(transactionDto, _transactionService.GetAll());
        }

        [Fact]
        public void AddedTransaction_WhenNoFrequncyGiven_ShouldBeOneTime()
        {
            // Arrange
            TransactionDto transactionDto = new();

            // Act
            TransactionDto addedTransactionDto = _transactionService.Add(transactionDto);

            // Assert
            Assert.Equal(Frequency.OneTime, addedTransactionDto.Frequency);
        }
    }
}
