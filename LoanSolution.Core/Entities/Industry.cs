using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanSolution.Core.Entities
{
    public class Industry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IndustryStatus Status { get; set; }

    }

    public enum IndustryStatus
    {
        Allowed,
        Banned,
        Inactive
    }


}
