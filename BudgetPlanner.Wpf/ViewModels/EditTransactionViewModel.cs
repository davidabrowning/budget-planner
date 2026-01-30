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

        public IEnumerable<Category> AllCategories { get { return MainViewModel.AllCategories; } }
        public IEnumerable<Frequency> AllFrequencies { get {  return MainViewModel.AllFrequencies; } }
        public IEnumerable<Month> AllMonths { get { return MainViewModel.AllMonths; } }
    }
}
