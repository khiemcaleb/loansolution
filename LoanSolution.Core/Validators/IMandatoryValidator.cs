namespace LoanSolution.Core.Validators
{
    public interface IMandatoryValidator
    {
        public bool CheckAnyHasValue(params string[] values);
    }
}
