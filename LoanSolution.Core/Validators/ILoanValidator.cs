namespace LoanSolution.Core.Validators
{
    public interface ILoanValidator
    {
        Task<bool> ValidateLoanAmountAsync(decimal amount);
    }
}
