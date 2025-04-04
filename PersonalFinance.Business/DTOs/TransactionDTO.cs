using PersonalFinance.Business.Entities;

namespace PersonalFinance.Business.DTOs
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public CategoryDTO Category { get; set; }
        public TransactionType TransactionType { get; set; }
        public CurrencyDTO Currency { get; set; }
    }
}
