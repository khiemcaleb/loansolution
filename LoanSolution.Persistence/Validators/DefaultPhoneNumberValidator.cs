using LoanSolution.Core.Validators;
using System.Text.RegularExpressions;

namespace LoanSolution.Persistence.Validators
{
    public class DefaultPhoneNumberValidator : IPhoneNumberValidator
    {
        private bool CheckAustralianMobileFormat(string phoneNumber)
        {
            var minified = MinifyPhoneNumber(phoneNumber);

            if (string.IsNullOrWhiteSpace(minified))
                return false;

            return Regex.IsMatch(minified, @"^(04|\+614)\d{8}$");
        }

        private bool CheckAustralianLandlineFormat(string phoneNumber)
        {
            var minified = MinifyPhoneNumber(phoneNumber);

            if (string.IsNullOrWhiteSpace(minified))
                return false;

            return Regex.IsMatch(minified, @"^(02|03|07|08)\d{8}$");
        }        

        public bool CheckAustralianPhoneNumberFormat(string phoneNumber)
        {
            return CheckAustralianMobileFormat(phoneNumber) || CheckAustralianLandlineFormat(phoneNumber);
        }

        private string MinifyPhoneNumber(string phoneNumber)
        {
            var result = Regex
                .Matches(phoneNumber, @"([\+]|[0-9])")
                .Aggregate("", (current, match) => current + match.Value, number => number);

            return result;
        }
    }
}
