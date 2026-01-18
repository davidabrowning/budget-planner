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
