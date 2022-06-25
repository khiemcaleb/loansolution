using LoanSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSolution.Core.Repositories
{
    public interface IIndustryRepository
    {
        Task<List<Industry>> GetAllAsync();
    }
}
