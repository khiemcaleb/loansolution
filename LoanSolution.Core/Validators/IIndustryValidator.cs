using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSolution.Core.Validators
{
    public class IndustryValidationResult
    {
        public bool IsAllowed { get; set; }
        public bool IsBanned { get; set; }

        public IndustryValidationResult Unknown()
        {

            IsAllowed = false;
            IsBanned = false;
            return this;
        }

        public IndustryValidationResult Allowed()
        {
            IsAllowed = true;
            IsBanned = false;
            return this;
        }

        public IndustryValidationResult Banned()
        {
            IsAllowed = false;
            IsBanned = true;
            return this;
        }
    }

    public interface IIndustryValidator
    {
        Task<IndustryValidationResult> ValidateIndustryAsync(string industry);
    }
}
