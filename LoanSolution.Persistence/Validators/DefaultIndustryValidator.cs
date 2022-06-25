using LoanSolution.Core.Entities;
using LoanSolution.Core.Repositories;
using LoanSolution.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSolution.Persistence.Validators
{
    public class DefaultIndustryValidator : IIndustryValidator
    {
        private readonly IIndustryRepository _industryRepos;
        public DefaultIndustryValidator(IIndustryRepository industryRepos)
        {
            _industryRepos = industryRepos;
        }

        public async Task<IndustryValidationResult> ValidateIndustryAsync(string industryName)
        {
            var result = new IndustryValidationResult();

            var industries = await _industryRepos.GetAllAsync();

            var industry = industries.FirstOrDefault(x => x.Name == industryName);
            if (industry == null)
                return result.Unknown();

            switch (industry.Status)
            {
                case IndustryStatus.Allowed:
                    return result.Allowed();
                case IndustryStatus.Banned:
                    return result.Banned();                
                default:
                    return result.Unknown();
            }
        }
    }
}
