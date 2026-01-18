using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Enums;
using BudgetPlanner.Core.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BudgetPlanner.Wpf.ViewModels
{
    public class TransactionsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly ITransactionService _transactionService;

        public IEnumerable<TransactionDto> Transactions
        {
            get { return _transactionService.GetAll(); }
        }

        private TransactionDto? selectedTransaction;
        public TransactionDto? SelectedTransaction
        {
            get { return selectedTransaction; }
            set
            {
                selectedTransaction = value;
                RaisePropertyChanged(nameof(SelectedTransaction));
            }
        }

        public TransactionsViewModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
            _transactionService.Add(new TransactionDto() { Amount = 30000, Category = Category.Salary, Frequency = Frequency.Monthly, Comment = "Monthly salary" });
            _transactionService.Add(new TransactionDto() { Amount = -5000, Category = Category.Housing, Frequency = Frequency.Monthly, Comment = "Monthly rent" });
        }

        public void AddTransaction(TransactionDto transaction)
        {
            _transactionService.Add(transaction);
            RaisePropertyChanged(nameof(Transactions));
        }

        public void DeleteSelectedTransaction()
        {
            if (SelectedTransaction is null)
                return;
            _transactionService.Delete(SelectedTransaction);
            RaisePropertyChanged(nameof(Transactions));
            SelectedTransaction = null;
        }

        public async Task LoadAsync()
        {
            if (_transactionService.GetAll().Any())
            {
                return;
            }

            // Otherwise, load transactions from database
        }

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
