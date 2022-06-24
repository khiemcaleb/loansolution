using LoanSolution.Core.Repositories;
using LoanSolution.Core.Validators;

namespace LoanSolution.Persistence.Validators
{
    public class DefaultCitizenshipValidator : ICitizenshipValidator
    {
        private readonly ICitizenshipRepository _citizenshipRepos;

        public DefaultCitizenshipValidator(ICitizenshipRepository citizenshipRepos)
        {
            _citizenshipRepos = citizenshipRepos;
        }

        public async Task<bool> ValidateCitizenshipStatusAsync(string status)
        {
            if (string.IsNullOrWhiteSpace(status)) 
                return false;

            var statuses = await _citizenshipRepos.GetAllAsync();

            return statuses.Any(s => s.Status == status);
        }
    }
}
