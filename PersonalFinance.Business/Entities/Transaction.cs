using Microsoft.EntityFrameworkCore;

namespace PersonalFinance.Business.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }      // Primary Key
        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public TransactionType TransactionType { get; set; }
        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
