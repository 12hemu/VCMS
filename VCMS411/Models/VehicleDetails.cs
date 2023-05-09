using System;
using System.Collections.Generic;

namespace VCMS411.Models
{
    public partial class VehicleDetails
    {
        public VehicleDetails()
        {
            PolicyDetails = new HashSet<PolicyDetails>();
        }

        public int VehicleId { get; set; }
        public string VehicleType { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleNo { get; set; }
        public DateTime VehiclePurchasedDate { get; set; }
        public double VehiclePrice { get; set; }
        public string FuelType { get; set; }
        public int? UserId { get; set; }

        public UserDetails User { get; set; }
        public ICollection<PolicyDetails> PolicyDetails { get; set; }
    }
}
