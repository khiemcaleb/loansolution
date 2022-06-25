using LoanSolution.Api.Dtos;
using LoanSolution.Core.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly IMandatoryValidator _mandatoryValidator;
        private readonly IBusinessNumberValidator _businessNumberValidator;
        private readonly IPhoneNumberValidator _phoneNumberValidator;
        private readonly ILoanValidator _loanValidator;
        private readonly ICitizenshipValidator _citizenshipValidator;
        private readonly IIndustryValidator _industryValidator;

        public LeadsController(IMandatoryValidator mandatoryValidator, IBusinessNumberValidator businessNumberValidator, IPhoneNumberValidator phoneNumberValidator, ILoanValidator loanValidator, ICitizenshipValidator citizenshipValidator, IIndustryValidator industryValidator)
        {
            _mandatoryValidator = mandatoryValidator;
            _businessNumberValidator = businessNumberValidator;
            _phoneNumberValidator = phoneNumberValidator;
            _loanValidator = loanValidator;
            _citizenshipValidator = citizenshipValidator;
            _industryValidator = industryValidator;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]LeadDto dto)
        {
            if (dto == null) 
                return BadRequest();

            var generalResult = new LeadValidationResultDto();

            var nameRule = new LeadRule("requiredName");
            if (_mandatoryValidator.CheckAnyHasValue(dto.FirstName, dto.LastName))
                nameRule.Pass();
            else
                nameRule.Fail($"Either {nameof(dto.FirstName)} or {nameof(dto.LastName)} is required");
            generalResult.AddRuleResult(nameRule);

            var numberRule = new LeadRule("requiredNumber");
            if (_mandatoryValidator.CheckAnyHasValue(dto.PhoneNumber, dto.EmailAddress))
                numberRule.Pass();
            else
                numberRule.Fail($"Either {nameof(dto.PhoneNumber)} or {nameof(dto.EmailAddress)} is required");
            generalResult.AddRuleResult(numberRule);

            var phoneNumberRule = new LeadRule("phoneNumber");
            if (_phoneNumberValidator.CheckAustralianPhoneNumberFormat(dto.PhoneNumber))
                phoneNumberRule.Pass();
            else
                phoneNumberRule.Fail($"{nameof(dto.PhoneNumber)} must be in Australian phone number format");
            generalResult.AddRuleResult(phoneNumberRule);

            var businessNumberRule = new LeadRule("businessNumber");
            if (await _businessNumberValidator.CheckAustralianBusinessNumber(dto.BusinessNumber))
                businessNumberRule.Pass();
            else
                businessNumberRule.Fail($"Incorrect {nameof(dto.BusinessNumber)}");
            generalResult.AddRuleResult(businessNumberRule);

            var loanRule = new LeadRule("loanRule");
            if (await _loanValidator.ValidateLoanAmountAsync(dto.LoanAmount))
                loanRule.Pass();
            else
                loanRule.Unknown($"{nameof(dto.LoanAmount)} is invalid");
            generalResult.AddRuleResult(loanRule);

            var timeTradingRule = new LeadRule("timeTrading");
            if (await _loanValidator.ValidateTimeTradingAsync(dto.TimeTrading))
                timeTradingRule.Pass();
            else
                timeTradingRule.Unknown($"{nameof(dto.TimeTrading)} is invalid");
            generalResult.AddRuleResult(timeTradingRule);

            var citizenshipRule = new LeadRule("citizenship");
            if (await _citizenshipValidator.ValidateCitizenshipStatusAsync(dto.CitizenshipStatus))
                citizenshipRule.Pass();
            else
                citizenshipRule.Unknown($"{dto.CitizenshipStatus} is not provided or is not of the known values");
            generalResult.AddRuleResult(citizenshipRule);

            var countryCodeRule = new LeadRule("countryCode");
            if (await _loanValidator.ValidateCountryCodeAsync(dto.CountryCode))
                countryCodeRule.Pass();
            else
                countryCodeRule.Unknown($"{dto.CountryCode} is not available");
            generalResult.AddRuleResult(countryCodeRule);

            var industryRule = new LeadRule("industry");
            var industryResult = await _industryValidator.ValidateIndustryAsync(dto.Industry);
            if (industryResult.IsAllowed)
                industryRule.Pass();
            else
            {
                if (industryResult.IsBanned)
                    industryRule.Fail($"{nameof(dto.Industry)} is not allowed.");
                else
                    industryRule.Unknown($"{nameof(dto.Industry)} is not known");
            }
            generalResult.AddRuleResult(industryRule);

            return Ok(generalResult);
        }
    }
}
