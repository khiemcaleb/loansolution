using LoanSolution.Core.Entities;

namespace LoanSolution.Core.Repositories
{
    public interface ILoanSettingsRepository
    {
        Task<LoanSettings> GetActiveLoanSettingsAsync();
    }
}
