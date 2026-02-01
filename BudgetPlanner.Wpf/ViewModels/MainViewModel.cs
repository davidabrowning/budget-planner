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
        }

        public async void AddTransaction(TransactionDto transaction)
        {
            await _transactionService.AddAsync(transaction);
            TransactionsListViewModel.AddTransaction(transaction);
            await MonthlyForecastViewModel.RefreshTransactionList();
        }

        public void SetSelectedTransaction(TransactionDto newSelectedTransaction)
        {
            TransactionsListViewModel.SelectedTransaction = newSelectedTransaction;
            EditTransactionViewModel.SelectedTransaction = newSelectedTransaction;
        }

        public async void UpdateSelectedTransaction()
        {
            if (TransactionsListViewModel.SelectedTransaction == null)
                return;
            await _transactionService.UpdateAsync(TransactionsListViewModel.SelectedTransaction);
            await MonthlyForecastViewModel.RefreshTransactionList();
        }

        public async void DeleteSelectedTransaction()
        {
            if (TransactionsListViewModel.SelectedTransaction is null)
                return;
            await _transactionService.DeleteAsync(TransactionsListViewModel.SelectedTransaction);
            TransactionsListViewModel.Transactions.Remove(TransactionsListViewModel.SelectedTransaction);
            TransactionsListViewModel.SelectedTransaction = null;
            await MonthlyForecastViewModel.RefreshTransactionList();
        }

        public async void RefreshTabData()
        {
            await MonthlyForecastViewModel.RefreshTransactionList();
        }

        public async Task LoadAsync()
        {
            await TransactionsListViewModel.LoadAsync();
            await MonthlyForecastViewModel.LoadAsync();
        }
    }
}
