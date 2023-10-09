using CarRental.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Shared.DTO_s
{
    public class RentalAgreementDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double PhoneNo { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public double RentalPricePerDay { get; set; }


    }
}
