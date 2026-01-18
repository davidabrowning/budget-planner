using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Core.Enums
{
    public static class FrequencyLookup
    {
        public static List<Frequency> All = new() { 
            Frequency.OneTime, 
            Frequency.Monthly, 
            Frequency.Yearly 
        };
    }
}
