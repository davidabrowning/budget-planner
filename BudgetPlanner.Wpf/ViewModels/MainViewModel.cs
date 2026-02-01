using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Enums;
using BudgetPlanner.Core.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BudgetPlanner.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public TransactionsListViewModel TransactionsListViewModel { get; }
        public AddTransactionViewModel AddTransactionViewModel { get; }
        public EditTransactionViewModel EditTransactionViewModel { get; }
        public MonthlyForecastViewModel MonthlyForecastViewModel { get; }
        private readonly ITransactionService _transactionService;

        public MainViewModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
            TransactionsListViewModel = new(_transactionService);
            AddTransactionViewModel = new(_transactionService);
            EditTransactionViewModel = new(_transactionService);
            MonthlyForecastViewModel = new(_transactionService);
            SeedInitialTransactions();
        }

        private void SeedInitialTransactions()
        {
            _transactionService.Add(new TransactionDto() { Amount = 30000, Category = Category.Salary, Frequency = Frequency.Monthly, Comment = "Monthly salary" });
            _transactionService.Add(new TransactionDto() { Amount = -5000, Category = Category.Housing, Frequency = Frequency.Monthly, Comment = "Monthly rent" });
            _transactionService.Add(new TransactionDto() { Amount = -1000, Category = Category.Food, Frequency = Frequency.OneTime, Comment = "Jan groceries", Month = Month.Jan, Year = 2026 });
            _transactionService.Add(new TransactionDto() { Amount = -2000, Category = Category.Food, Frequency = Frequency.OneTime, Comment = "Feb groceries", Month = Month.Feb, Year = 2026 });
        }

        public void AddTransaction(TransactionDto transaction)
        {
            _transactionService.Add(transaction);
            TransactionsListViewModel.AddTransaction(transaction);
        }

        public void SetSelectedTransaction(TransactionDto newSelectedTransaction)
        {
            TransactionsListViewModel.SelectedTransaction = newSelectedTransaction;
            EditTransactionViewModel.SelectedTransaction = newSelectedTransaction;
        }

        public void UpdateSelectedTransaction()
        {
            if (TransactionsListViewModel.SelectedTransaction == null)
                return;
            _transactionService.Update(TransactionsListViewModel.SelectedTransaction);
            MonthlyForecastViewModel.RefreshTransactionList();
        }

        public void DeleteSelectedTransaction()
        {
            if (TransactionsListViewModel.SelectedTransaction is null)
                return;
            _transactionService.Delete(TransactionsListViewModel.SelectedTransaction);
            TransactionsListViewModel.Transactions.Remove(TransactionsListViewModel.SelectedTransaction);
            TransactionsListViewModel.SelectedTransaction = null;
            MonthlyForecastViewModel.RefreshTransactionList();
        }

        public void RefreshTabData()
        {
            MonthlyForecastViewModel.RefreshTransactionList();
        }

        public async Task LoadAsync()
        {
            await TransactionsListViewModel.LoadAsync();
            await MonthlyForecastViewModel.LoadAsync();
        }
    }
}
