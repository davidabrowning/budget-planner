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
        private readonly ITransactionService _transactionService;

        public MainViewModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
            TransactionsListViewModel = new(_transactionService);
            AddTransactionViewModel = new(_transactionService);
            EditTransactionViewModel = new(_transactionService);
            _transactionService.Add(new TransactionDto() { Amount = 30000, Category = Category.Salary, Frequency = Frequency.Monthly, Comment = "Monthly salary" });
            _transactionService.Add(new TransactionDto() { Amount = -5000, Category = Category.Housing, Frequency = Frequency.Monthly, Comment = "Monthly rent" });
        }

        public void AddTransaction(TransactionDto transaction)
        {
            _transactionService.Add(transaction);
            TransactionsListViewModel.Transactions.Add(transaction);
        }

        public void UpdateSelectedTransaction()
        {
            if (TransactionsListViewModel.SelectedTransaction == null)
                return;
            _transactionService.Update(TransactionsListViewModel.SelectedTransaction);
        }

        public void DeleteSelectedTransaction()
        {
            if (TransactionsListViewModel.SelectedTransaction is null)
                return;
            _transactionService.Delete(TransactionsListViewModel.SelectedTransaction);
            TransactionsListViewModel.Transactions.Remove(TransactionsListViewModel.SelectedTransaction);
            TransactionsListViewModel.SelectedTransaction = null;
        }

        public async Task LoadAsync()
        {
            if (_transactionService.GetAll().Any())
            {
                TransactionsListViewModel.Transactions = new ObservableCollection<TransactionDto>(_transactionService.GetAll());
                return;
            }

            // Otherwise, load transactions from database
        }
    }
}
