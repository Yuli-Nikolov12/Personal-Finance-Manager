namespace PersonalFinance.Business.DTOs
{
    public class CurrencyDTO
    {
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }  // Code like USD, EUR, etc.
        public string CurrencyName { get; set; }  // Name of the currency (Dollar, Euro, etc.)
    }
}
