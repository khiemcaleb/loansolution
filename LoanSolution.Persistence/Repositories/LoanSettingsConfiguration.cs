using LoanSolution.Core.Entities;
using LoanSolution.Core.Repositories;
using Microsoft.Extensions.Configuration;

namespace LoanSolution.Persistence.Repositories
{
    public class LoanSettingsConfiguration : ILoanSettingsRepository
    {
        private readonly IConfiguration _config;

        public LoanSettingsConfiguration(IConfiguration config)
        {
            _config = config;
        }

        public async Task<LoanSettings> GetActiveLoanSettingsAsync()
        {
            var loanSettings = new LoanSettings();
            _config.GetRequiredSection("LoanSettings").Bind(loanSettings);

            await Task.Delay(50);
            return loanSettings;
        }
    }
}
