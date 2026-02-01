using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Enums;
using BudgetPlanner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BudgetPlanner.Wpf.ViewModels
{
    public class TransactionsListViewModel : ViewModelBase
    {
        private readonly ITransactionService _transactionService;
        public ICollectionView TransactionsView { get; }

        public TransactionsListViewModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
            Transactions = new ObservableCollection<TransactionDto>();
            TransactionsView = CollectionViewSource.GetDefaultView(Transactions);
            TransactionsView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(TransactionDto.Month)));
            TransactionsView.SortDescriptions.Clear();
            TransactionsView.SortDescriptions.Add(new SortDescription(nameof(TransactionDto.Month), ListSortDirection.Ascending));
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
                foreach (TransactionDto transactionDto in _transactionService.GetAll())
                    AddTransaction(transactionDto);
                return;
            }
        }

        public void AddTransaction(TransactionDto transactionDto)
        {
            if (transactionDto.Frequency == Frequency.Monthly)
            {
                foreach (Month month in MonthLookup.All)
                {
                    transactionDto.Month = month;
                    Transactions.Add(transactionDto);
                }
            }
            else
                Transactions.Add(transactionDto);
        }
    }
}
