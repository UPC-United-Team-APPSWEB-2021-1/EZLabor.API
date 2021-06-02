using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLabor.API.Accounts.Domain.Model
{
    public class Proposal
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double PaymentAmount { get; set; }
        public EMoneyType MoneyType { get; set; }
        public EProposalState ProposalState { get; set; }


        public Employer Employer { get; set; }
        public int EmployerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int FreelancerId { get; set; }
    }
}
