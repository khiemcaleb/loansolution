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


        public LeadsController(IMandatoryValidator mandatoryValidator, IBusinessNumberValidator businessNumberValidator, IPhoneNumberValidator phoneNumberValidator, ILoanValidator loanValidator)
        {
            _mandatoryValidator = mandatoryValidator;
            _businessNumberValidator = businessNumberValidator;
            _phoneNumberValidator = phoneNumberValidator;
            _loanValidator = loanValidator;
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
            if (_mandatoryValidator.CheckAnyHasValue(dto.PhoneNumber, dto.BusinessNumber))
                numberRule.Pass();
            else
                numberRule.Fail($"Either {nameof(dto.PhoneNumber)} or {nameof(dto.BusinessNumber)} is required");
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
                loanRule.Unknown("Loan Amount is invalid");
            generalResult.AddRuleResult(loanRule);


            return Ok(generalResult);
        }
    }
}
