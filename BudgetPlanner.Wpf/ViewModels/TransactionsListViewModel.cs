using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Wpf.ViewModels
{
    public class TransactionsListViewModel : ViewModelBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsListViewModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

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
