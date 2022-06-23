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
        private readonly ILoanSettingRepository _loanRepos;

        public DefaultLoanValidator(ILoanSettingRepository loanRepos)
        {
            _loanRepos = loanRepos;
        }    
        public async Task<bool> ValidateLoanAmountAsync(decimal amount)
        {
            var loanSetting = await _loanRepos.GetActiveLoanValidationAsync();

            return loanSetting.LoanAmountMinimum <= amount && amount <= loanSetting.LoanAmountMaximum;
        }
    }
}
