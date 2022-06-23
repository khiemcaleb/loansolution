using LoanSolution.Core.Entities;

namespace LoanSolution.Core.Repositories
{
    public interface ICitizenshipRepository
    {
        Task<List<Citizenship>> GetAllAsync();
    }
}
