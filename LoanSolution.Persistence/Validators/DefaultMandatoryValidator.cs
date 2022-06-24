using LoanSolution.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSolution.Persistence.Validators
{
    public class DefaultMandatoryValidator : IMandatoryValidator
    {
        public bool CheckAnyHasValue(params string[] values)
        {
            return values.Any(value => !string.IsNullOrWhiteSpace(value));
        }
    }
}
