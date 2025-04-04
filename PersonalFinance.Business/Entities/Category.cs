namespace PersonalFinance.Business.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }         // Primary Key
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Budget> Budgets { get; set; }
    }
}
