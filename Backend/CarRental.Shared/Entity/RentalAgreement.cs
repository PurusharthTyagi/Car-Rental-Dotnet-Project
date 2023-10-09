using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Shared.Entity
{
    public class RentalAgreement
    {
        public Guid RentalAgreementId { get; set; }
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }   
        public double TotalCost { get; set; }
        public bool RequestForReturn { get; set; }
        public bool ReturnRequestAccepted { get; set; }
    }
}
