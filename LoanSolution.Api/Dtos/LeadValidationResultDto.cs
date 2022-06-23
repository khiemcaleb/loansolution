namespace LoanSolution.Api.Dtos
{
    public class LeadValidationResultDto
    {
        private readonly List<LeadRule> _ruleResults;
        public bool Qualified() => _ruleResults.All(x => x.Qualified());

        public string Decision { get
            {
                return Qualified() ? "Qualified" : "Unqualified";
            } }


        public LeadValidationResultDto()
        {
            _ruleResults = new List<LeadRule>();
        }

        public List<LeadRule> ValidationResult => _ruleResults
                                                            .Where(x => !x.Qualified())
                                                            .ToList();
        public void AddRuleResult(LeadRule ruleResult) => _ruleResults.Add(ruleResult);
    }

}
