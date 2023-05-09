using System;
using System.Collections.Generic;

namespace VCMS411.Models
{
    public partial class InsuranceCompanyDetails
    {
        public InsuranceCompanyDetails()
        {
            PolicyDetails = new HashSet<PolicyDetails>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyContact { get; set; }
        public string CompanyAddress { get; set; }

        public ICollection<PolicyDetails> PolicyDetails { get; set; }
    }
}
