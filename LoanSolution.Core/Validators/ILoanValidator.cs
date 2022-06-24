namespace LoanSolution.Core.Validators
{
    public interface ILoanValidator
    {
        Task<bool> ValidateLoanAmountAsync(decimal amount);
        Task<bool> ValidateTimeTradingAsync(int timeTrading);
    }
}
