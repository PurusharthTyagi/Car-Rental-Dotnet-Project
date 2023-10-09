using CarRental.DAL.Data;
using CarRental.DAL.IRepo;
using CarRental.Shared.DTO_s;
using CarRental.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Repo
{
    public class AgreementRepo : IAgreementRepo
    {
        private readonly AppDbContext _appDBContext;
        private readonly ICarRepo _carRepo;
        public AgreementRepo(AppDbContext context, ICarRepo carRepo )
        {
            _appDBContext = context;
            _carRepo = carRepo;
        }
        public bool DeleteAgreement(Guid rentalid)
        {

            bool result = false;
            var agreement = _appDBContext.car.Find(rentalid);
            if (agreement != null)
            {
                _appDBContext.Entry(agreement).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task GenerateAgreement(RentalAgreement rentalagreement)
        {

           // _carRepo.IsAvailableChange(rentalagreement.CarId);

            rentalagreement.RentalAgreementId = Guid.NewGuid();
            _appDBContext.rentalagreement.Add(rentalagreement);
            _carRepo.IsAvailableChange(rentalagreement.CarId);
            await _appDBContext.SaveChangesAsync();

        }

        public async Task<RentalAgreement> GetAgreementByID(Guid rentalid)
        {
            return await _appDBContext.rentalagreement.FindAsync(rentalid);
        }

        public async Task<RentalAgreement> UpdateAgreement(RentalAgreement rentalagreement)
        {
            _appDBContext.Entry(rentalagreement).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return rentalagreement;
        }

        public async Task<IEnumerable<RentalAgreement>> ViewAllAgreements()
        {
            return await _appDBContext.rentalagreement.ToListAsync();
        }
    }
}
