using LoanSolution.Core.Repositories;
using LoanSolution.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSolution.Persistence.Validators
{
    public class DefaultLoanValidator : ILoanValidator
    {
        private readonly ILoanSettingsRepository _loanRepos;

        public DefaultLoanValidator(ILoanSettingsRepository loanRepos)
        {
            _loanRepos = loanRepos;
        }    
        public async Task<bool> ValidateLoanAmountAsync(decimal amount)
        {
            var loanSetting = await _loanRepos.GetActiveLoanSettingsAsync();

            return loanSetting.MinAmount <= amount && amount <= loanSetting.MaxAmount;
        }

        public async Task<bool> ValidateTimeTradingAsync(int timeTrading)
        {
            var loanSetting = await _loanRepos.GetActiveLoanSettingsAsync();

            return loanSetting.MinTimeTrading <= timeTrading && timeTrading <= loanSetting.MaxTimeTrading;
        }
    }
}
