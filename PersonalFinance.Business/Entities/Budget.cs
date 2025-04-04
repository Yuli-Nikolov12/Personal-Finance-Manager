using Microsoft.EntityFrameworkCore;

namespace PersonalFinance.Business.Entities
{
    public class Budget
    {
        public int BudgetId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
