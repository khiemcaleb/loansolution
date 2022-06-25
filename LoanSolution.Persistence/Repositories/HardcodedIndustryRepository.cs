using LoanSolution.Core.Entities;
using LoanSolution.Core.Repositories;

namespace LoanSolution.Persistence.Repositories
{
    public class HardcodedIndustryRepository : IIndustryRepository
    {
        public async Task<List<Industry>> GetAllAsync()
        {
            await Task.CompletedTask;
            return new List<Industry>
            {
                new Industry
                {
                    Id = 1,
                    Name = "Industry 1",
                    Status = IndustryStatus.Allowed
                },
                new Industry
                {
                    Id = 2,
                    Name = "Industry 2",
                    Status = IndustryStatus.Banned
                },
                new Industry
                {
                    Id = 3,
                    Name = "Industry 3",
                    Status = IndustryStatus.Inactive
                },
                new Industry
                {
                    Id = 4,
                    Name = "Industry 4",
                    Status = IndustryStatus.Allowed
                }

            };
        }
    }
}
