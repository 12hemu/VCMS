using System;
using System.Collections.Generic;

namespace VCMS411.Models
{
    public partial class UserDetails
    {
        public UserDetails()
        {
            ClaimDetails = new HashSet<ClaimDetails>();
            VehicleDetails = new HashSet<VehicleDetails>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserAge { get; set; }
        public string UserAddress { get; set; }
        public string UserState { get; set; }
        public string UserCountry { get; set; }
        public string UserEmail { get; set; }
        public string UserContact { get; set; }
        public string LicenceNo { get; set; }

        public ICollection<ClaimDetails> ClaimDetails { get; set; }
        public ICollection<VehicleDetails> VehicleDetails { get; set; }
    }
}
