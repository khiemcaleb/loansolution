namespace LoanSolution.Core.Validators
{
    public interface IPhoneNumberValidator
    {
        bool CheckAustralianPhoneNumberFormat(string phoneNumber);
        //bool CheckAustralianMobileFormat(string phoneNumber);
        //bool CheckAustralianLandlineFormat(string phoneNumber);
    }
}
