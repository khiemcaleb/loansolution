using LoanSolution.Core.Entities;

namespace LoanSolution.Core.Repositories
{
    public interface ILoanSettingRepository
    {
        Task<LoanSetting> GetActiveLoanValidationAsync();
    }
}
