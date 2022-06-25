using LoanSolution.Core.Validators;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Caching.Memory;

namespace LoanSolution.Persistence.Validators
{
    public class ExternalBusinessNumberValidator : IBusinessNumberValidator
    {
        private readonly IMemoryCache _cache;

        public ExternalBusinessNumberValidator(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<bool> CheckAustralianBusinessNumber(string businessNumber)
        {
            var minified = MinifyPhoneNumber(businessNumber);

            if (string.IsNullOrEmpty(minified))
                return false;

            if (!_cache.TryGetValue($"bn-{businessNumber}", out bool cachedResult))
            {
                await Task.Delay(500);
                cachedResult = Regex.IsMatch(minified, @"^\d{11}$");

                _cache.Set($"bn-{businessNumber}", cachedResult, TimeSpan.FromDays(1));
            }

            return cachedResult;
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
