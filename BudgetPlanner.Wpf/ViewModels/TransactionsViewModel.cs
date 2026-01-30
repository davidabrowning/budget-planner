using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Enums;
using BudgetPlanner.Core.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BudgetPlanner.Wpf.ViewModels
{
    public class TransactionsViewModel : ViewModelBase
    {
        private readonly ITransactionService _transactionService;

        private ObservableCollection<TransactionDto> transactions = new();
        public ObservableCollection<TransactionDto> Transactions
        {
            get { return transactions; }
            set
            {
                transactions = value;
                RaisePropertyChanged();
            }
        }

        private TransactionDto? selectedTransaction;
        public TransactionDto? SelectedTransaction
        {
            get { return selectedTransaction; }
            set
            {
                selectedTransaction = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<Category> AllCategories { get { return CategoryLookup.All; } }
        public Category DefaultCategory { get { return Category.Unknown; } }
        public IEnumerable<Frequency> AllFrequencies { get { return FrequencyLookup.All; } }
        public Frequency DefaultFrequency { get { return Frequency.OneTime; } }
        public IEnumerable<Month> AllMonths { get { return MonthLookup.All; } }
        public Month DefaultMonth { get { return (Month)DateTime.Now.Month; } }

        public TransactionsViewModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
            _transactionService.Add(new TransactionDto() { Amount = 30000, Category = Category.Salary, Frequency = Frequency.Monthly, Comment = "Monthly salary" });
            _transactionService.Add(new TransactionDto() { Amount = -5000, Category = Category.Housing, Frequency = Frequency.Monthly, Comment = "Monthly rent" });
        }

        public void AddTransaction(TransactionDto transaction)
        {
            _transactionService.Add(transaction);
            Transactions.Add(transaction);
        }

        public void UpdateSelectedTransaction()
        {
            if (SelectedTransaction == null)
                return;
            _transactionService.Update(SelectedTransaction);
        }

        public void DeleteSelectedTransaction()
        {
            if (SelectedTransaction is null)
                return;
            _transactionService.Delete(SelectedTransaction);
            Transactions.Remove(SelectedTransaction);
            SelectedTransaction = null;
        }

        public async Task LoadAsync()
        {
            if (_transactionService.GetAll().Any())
            {
                Transactions = new ObservableCollection<TransactionDto>(_transactionService.GetAll());
                return;
            }

            // Otherwise, load transactions from database
        }
    }
}
