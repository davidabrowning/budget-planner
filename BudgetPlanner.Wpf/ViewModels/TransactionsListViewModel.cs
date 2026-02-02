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
            TransactionsView.SortDescriptions.Add(new SortDescription(nameof(TransactionDto.Month), ListSortDirection.Ascending));
        }

        public ObservableCollection<TransactionDto> Transactions { get; set; }

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
            if ((await _transactionService.GetAllAsync()).Any())
            {
                Transactions.Clear();
                foreach (TransactionDto transactionDto in await _transactionService.GetAllAsync())
                    AddTransactionToCurrentYearList(transactionDto);
                return;
            }
        }

        public void AddTransactionToCurrentYearList(TransactionDto transactionDto)
        {
            if (transactionDto.Frequency == Frequency.Yearly)
            {
                AddOneInstanceOfYearlyTransaction(transactionDto);
            }
            if (transactionDto.Frequency == Frequency.Monthly)
            {
                AddTwelveInstancesOfMonthlyTransaction(transactionDto);
            }
            if (transactionDto.Frequency == Frequency.OneTime && transactionDto.Year == DateTime.Now.Year)
            {
                AddOneInstanceOfThisYearsOneTimeTransaction(transactionDto);
            }
        }

        private void AddOneInstanceOfYearlyTransaction(TransactionDto transactionDto)
        {
            transactionDto.Year = DateTime.Now.Year;
            Transactions.Add(transactionDto);
        }

        private void AddTwelveInstancesOfMonthlyTransaction(TransactionDto transactionDto)
        {
            foreach (Month month in MonthLookup.All)
            {
                transactionDto.Year = DateTime.Now.Year;
                transactionDto.Month = month;
                Transactions.Add(transactionDto);
            }
        }

        private void AddOneInstanceOfThisYearsOneTimeTransaction(TransactionDto transactionDto)
        {
            Transactions.Add(transactionDto);
        }
    }
}
