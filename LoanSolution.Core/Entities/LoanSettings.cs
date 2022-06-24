namespace LoanSolution.Core.Entities
{
    public class LoanSettings
    {
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int MinTimeTrading { get; set; }
        public int MaxTimeTrading { get; set; }
        public string CountryCode { get; set; }
    }
}
