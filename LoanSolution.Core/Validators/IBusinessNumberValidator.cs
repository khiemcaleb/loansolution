namespace LoanSolution.Core.Validators
{
    public interface IBusinessNumberValidator
    {
        Task<bool> CheckAustralianBusinessNumber(string businessNumber);
    }
}
