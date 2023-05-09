using System;
using System.Collections.Generic;

namespace VCMS411.Models
{
    public partial class PolicyDetails
    {
        public PolicyDetails()
        {
            ClaimDetails = new HashSet<ClaimDetails>();
        }

        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public double PolicyAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int? VehicleId { get; set; }
        public int? CompanyId { get; set; }

        public InsuranceCompanyDetails Company { get; set; }
        public VehicleDetails Vehicle { get; set; }
        public ICollection<ClaimDetails> ClaimDetails { get; set; }
    }
}
