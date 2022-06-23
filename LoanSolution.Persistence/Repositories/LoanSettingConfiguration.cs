using LoanSolution.Core.Entities;
using LoanSolution.Core.Repositories;
using Microsoft.Extensions.Configuration;

namespace LoanSolution.Persistence.Repositories
{
    public class LoanSettingConfiguration : ILoanSettingRepository
    {
        private readonly IConfiguration _config;

        public LoanSettingConfiguration(IConfiguration config)
        {
            _config = config;
        }

        public async Task<LoanSetting> GetActiveLoanValidationAsync()
        {

            await Task.Delay(50);
            return new LoanSetting { LoanAmountMaximum = 100000, LoanAmountMinimum = 10000, TimeTrading = 10 };
        }
    }
}
