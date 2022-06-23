using LoanSolution.Core.Entities;
using LoanSolution.Core.Repositories;

namespace LoanSolution.Persistence.Repositories
{
    public class HardcodedCitizenshipRepository : ICitizenshipRepository
    {
        public async Task<List<Citizenship>> GetAllAsync()
        {
            await Task.Delay(50);

            return new List<Citizenship> {
                new Citizenship { Id = 1, Status = "Citizen"},
                new Citizenship { Id = 2, Status = "Permanent Resident"}
            };
        }
    }
}
