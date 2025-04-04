namespace PersonalFinance.Business.Entities
{
    public class Budget
    {
        public int BudgetId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
