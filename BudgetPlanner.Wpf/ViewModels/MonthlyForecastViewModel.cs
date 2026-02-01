using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Enums;
using BudgetPlanner.Core.Interfaces;
using BudgetPlanner.Core.ReadModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Wpf.ViewModels
{
    public class MonthlyForecastViewModel : ViewModelBase
    {
        private readonly ITransactionService _transactionService;
        public MonthlyForecastViewModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        private ObservableCollection<MonthlySummary> monthlySummaryList = new();
        public ObservableCollection<MonthlySummary> MonthlySummaryList
        {
            get { return monthlySummaryList; }
            set
            {
                monthlySummaryList = value;
                RaisePropertyChanged();
            }
        }

        public async Task LoadAsync()
        {
            MonthlySummaryList.Clear();
            foreach (Month month in MonthLookup.All)
                MonthlySummaryList.Add(new MonthlySummary { Month = month, Year = DateTime.Now.Year });
            if ((await _transactionService.GetAllAsync()).Any())
            {
                foreach (TransactionDto transactionDto in await _transactionService.GetAllAsync())
                    AddTransaction(transactionDto);
                return;
            }
        }

        public void AddTransaction(TransactionDto transactionDto)
        {
            List<MonthlySummary> relevantMonthlySummaries = new();

            if (transactionDto.Frequency == Frequency.OneTime)
            {
                MonthlySummary? monthlySummary = MonthlySummaryList.FirstOrDefault(ms => ms.Year == transactionDto.Year && ms.Month == transactionDto.Month);
                if (monthlySummary == null)
                    return;
                relevantMonthlySummaries.Add(monthlySummary);
            }

            if (transactionDto.Frequency == Frequency.Yearly)
            {
                List<MonthlySummary> monthlySummaries = MonthlySummaryList.Where(ms => ms.Month == transactionDto.Month).ToList();
                relevantMonthlySummaries.AddRange(monthlySummaries);
            }

            if (transactionDto.Frequency == Frequency.Monthly)
            {
                relevantMonthlySummaries.AddRange(monthlySummaryList);
            }

            foreach (MonthlySummary relevantMonthlySummary in relevantMonthlySummaries)
                relevantMonthlySummary.Transactions.Add(transactionDto);
        }

        public async Task RefreshTransactionList()
        {
            await LoadAsync();
        }
    }
}
