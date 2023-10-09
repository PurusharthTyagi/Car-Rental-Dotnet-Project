using CarRental.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.IRepo
{
    public interface IReqForReturn
    {
        public Task RequestForReturn(Guid rentalagreementId);
        public Task ReturnRequestApproved(Guid rentalagreementId);
    }
}
