using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Core.ReadModels
{
    public class MonthlySummary
    {
        public required int Year { get; set; }
        public required Month Month { get; set; }
        public List<TransactionDto> Transactions { get; set; } = new();
        public int Incomes { get {  return Transactions.Where(t => t.Amount > 0).Sum(t => t.Amount); } }
        public int Expenses { get { return Transactions.Where(t => t.Amount < 0).Sum(t => t.Amount); } }
        public int Net { get { return Transactions.Sum(t => t.Amount); } }
    }
}
