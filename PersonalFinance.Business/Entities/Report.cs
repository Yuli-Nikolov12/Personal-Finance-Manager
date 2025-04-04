namespace PersonalFinance.Business.Entities
{
    public class Report
    {
        public int ReportId { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal NetSavings { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
