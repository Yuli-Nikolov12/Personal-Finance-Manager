using Microsoft.EntityFrameworkCore;

namespace PersonalFinance.Business.Entities
{
    public class Report
    {
        public int ReportId { get; set; }
        [Precision(18, 2)]
        public decimal TotalIncome { get; set; }
        [Precision(18, 2)]
        public decimal TotalExpenses { get; set; }
        [Precision(18, 2)]
        public decimal NetSavings { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
