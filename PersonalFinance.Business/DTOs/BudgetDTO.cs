namespace PersonalFinance.Business.DTOs
{
    public class BudgetDTO
    {
        public int BudgetId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
