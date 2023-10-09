using CarRental.Shared.DTO_s;
using CarRental.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.IRepo
{
    public interface IAgreementRepo
    {
        public Task GenerateAgreement(RentalAgreement rentalagreement);
        public Task<RentalAgreement> UpdateAgreement(RentalAgreement rentalagreement);
        public Task<RentalAgreement> GetAgreementByID(Guid rentalid);
        public bool DeleteAgreement(Guid rentalid);
        public Task<IEnumerable<RentalAgreement>> ViewAllAgreements();
    }
}
