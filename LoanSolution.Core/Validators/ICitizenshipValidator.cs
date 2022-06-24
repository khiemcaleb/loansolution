namespace LoanSolution.Core.Validators
{
    public interface ICitizenshipValidator
    {
        Task<bool> ValidateCitizenshipStatusAsync(string status);
    }
}
