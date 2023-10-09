using CarRental.DAL.Data;
using CarRental.DAL.IRepo;
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
    public class ReqForReturnRepo : IReqForReturn
    {
        private readonly AppDbContext _appDBContext;
        private readonly ICarRepo _carRepo;
        public ReqForReturnRepo(AppDbContext context,ICarRepo carRepo)
        {
            _appDBContext = context;
            _carRepo = carRepo;
        }
        public async Task RequestForReturn(Guid rentalagreementId)
        {
            var agreement = _appDBContext.rentalagreement.FirstOrDefault(x => x.RentalAgreementId == rentalagreementId);
            if (agreement != null)
            {
                agreement.RequestForReturn = true;
                _appDBContext.Entry(agreement).State = EntityState.Modified;
                await _appDBContext.SaveChangesAsync();
            }

        }

        public async Task ReturnRequestApproved(Guid rentalagreementId)
        {
            var agreement = _appDBContext.rentalagreement.FirstOrDefault(x => x.RentalAgreementId == rentalagreementId);
            if (agreement != null)
            {
                agreement.ReturnRequestAccepted = true;
                _appDBContext.Entry(agreement).State = EntityState.Modified;
                _carRepo.IsAvailableChange(agreement.CarId);
                await _appDBContext.SaveChangesAsync();
            }

        }
    }
}
