using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Enums;
using System.Collections.ObjectModel;

namespace BudgetPlanner.Wpf.ViewModels
{
    public class TransactionsViewModel
    {
        private ObservableCollection<TransactionDto> transactions = new();
        public ObservableCollection<TransactionDto> Transactions
        {
            get { return transactions; }
            set { transactions = value; }
        }

        private TransactionDto? selectedTransaction;
        public TransactionDto? SelectedTransaction
        {
            get { return selectedTransaction; }
            set { selectedTransaction = value;  }
        }

        public TransactionsViewModel()
        {
            transactions.Add(new TransactionDto() { Amount = 30000, Category = "Lön", Frequency = Frequency.Monthly, Comment = "Monthly salary" });
            transactions.Add(new TransactionDto() { Amount = -5000, Category = "Hyra", Frequency = Frequency.Monthly, Comment = "Monthly rent" });
        }

        public async Task LoadAsync()
        {
            if (transactions.Any())
            {
                return;
            }

            // Otherwise, load transactions from database
        }
    }
}
