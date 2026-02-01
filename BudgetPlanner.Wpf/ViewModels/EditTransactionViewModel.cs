using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Enums;
using BudgetPlanner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Wpf.ViewModels
{
    public class EditTransactionViewModel : ViewModelBase
    {
        private ITransactionService _transactionService;

        public EditTransactionViewModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
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

        public static IEnumerable<Category> AllCategories { get { return CategoryLookup.AllSorted; } }
        public static IEnumerable<Frequency> AllFrequencies { get { return FrequencyLookup.All; } }
        public static IEnumerable<Month> AllMonths { get { return MonthLookup.All; } }
    }
}
