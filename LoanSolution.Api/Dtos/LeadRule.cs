namespace LoanSolution.Api.Dtos
{
    public class LeadRule
    {
        private bool _qualified;
        public bool Qualified() => _qualified;

        private string _rule;
        public string Rule => _rule;

        private string _message;
        public string Message => _message;

        private string _decision;
        public string Decision => _decision;

        public LeadRule(string ruleName)
        {
            _rule = ruleName;
        }

        public void Pass(string message = "Qualified")
        {
            _message = message;
            _decision = "Qualified";
            _qualified = true;
        }

        public void Unknown(string message)
        {
            _decision = "Unknown";
            _qualified = false;
            _message = message;
        }

        public void Fail(string message)
        {
            _message = message;
            _qualified = false;
            _decision = "Unqualified";
        }

        
        
    }

}
