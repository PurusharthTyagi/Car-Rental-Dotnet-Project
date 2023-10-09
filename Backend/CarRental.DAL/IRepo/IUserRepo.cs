using CarRental.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.IRepo
{
    public interface IUserRepo
    {
        public Task<User> AddUser(User objUser);
        public Task<User> GetUserByID(Guid userId);
    }
}
