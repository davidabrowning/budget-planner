namespace BudgetPlanner.Core.Enums
{
    public static class CategoryLookup
    {
        public static List<Category> All = new()
        {
            (Category)0,
            (Category)1, 
            (Category)2,
            (Category)3,
            (Category)4, 
            (Category)5,
            (Category)6,
            (Category)7,
            (Category)8,
            (Category)9,
            (Category)10,
            (Category)11,
        };

        public static List<Category> AllSorted { get { return All.OrderBy(c => c.ToString()).ToList(); } }
    }
}
