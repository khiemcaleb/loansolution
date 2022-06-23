using LoanSolution.Core.Validators;
using System.Text.RegularExpressions;

namespace LoanSolution.Persistence.Validators
{
    public class ExternalBusinessNumberValidator : IBusinessNumberValidator
    {
        public async Task<bool> CheckAustralianBusinessNumber(string businessNumber)
        {
            var minified = MinifyPhoneNumber(businessNumber);

            if (string.IsNullOrEmpty(minified))
                return false;

            await Task.Delay(50);

            return Regex.IsMatch(minified, @"^\d{11}$");
        }

        private string MinifyPhoneNumber(string businessNumber)
        {
            var result = Regex
                .Matches(businessNumber, @"([\+]|[0-9])")
                .Aggregate("", (current, match) => current + match.Value, number => number);

            return result;
        }
    }
}
