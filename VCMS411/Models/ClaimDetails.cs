using System;
using System.Collections.Generic;

namespace VCMS411.Models
{
    public partial class ClaimDetails
    {
        public int ClaimId { get; set; }
        public string VehicleBill { get; set; }
        public string DriverLicenseNo { get; set; }
        public byte[] ClaimDocuments { get; set; }
        public string ClaimReason { get; set; }
        public double ClaimAmount { get; set; }
        public string BankBranch { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        public string IfscCode { get; set; }
        public string ClaimStatus { get; set; }
        public int? UserId { get; set; }
        public int? PolicyId { get; set; }

        public PolicyDetails Policy { get; set; }
        public UserDetails User { get; set; }
    }
}
