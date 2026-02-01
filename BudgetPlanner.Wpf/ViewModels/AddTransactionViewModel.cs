using BudgetPlanner.Core.Enums;
using BudgetPlanner.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Wpf.ViewModels
{
    public class AddTransactionViewModel : ViewModelBase
    {
        private readonly ITransactionService _transactionService;

        public AddTransactionViewModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public static IEnumerable<Category> AllCategories { get { return CategoryLookup.AllSorted; } }
        public static Category DefaultCategory { get { return Category.Unknown; } }
        public static IEnumerable<Frequency> AllFrequencies { get { return FrequencyLookup.All; } }
        public static Frequency DefaultFrequency { get { return Frequency.OneTime; } }
        public static IEnumerable<Month> AllMonths { get { return MonthLookup.All; } }
        public static Month DefaultMonth { get { return (Month)DateTime.Now.Month; } }
        public static int DefaultYear { get { return DateTime.Now.Year; } }
    }
}
