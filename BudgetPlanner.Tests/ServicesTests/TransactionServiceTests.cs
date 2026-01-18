using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Services;
using BudgetPlanner.Tests.ServicesTests.Fake;

namespace BudgetPlanner.Tests.ServicesTests
{
    public class TransactionServiceTests
    {
        [Fact]
        public void Add_WhenCalled_AddTransaction()
        {
            // Arrange
            FakeTransactionRepository fakeRepo = new();
            TransactionService transactionService = new(fakeRepo);
            TransactionDto transactionDto = new() { Amount = 42 };

            // Act
            transactionService.Add(transactionDto);

            // Assert
            Assert.Contains(transactionDto, transactionService.GetAll());
        }
    }
}
