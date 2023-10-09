using CarRental.DAL.Data;
using CarRental.DAL.IRepo;
using CarRental.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Repo
{
    public class UserRepo:IUserRepo
    {
        public readonly AppDbContext _appDbContext;
        public UserRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> AddUser(User objUser)
        {
            objUser.UserId = Guid.NewGuid();

            _appDbContext.user.Add(objUser);

            await _appDbContext.SaveChangesAsync();

            return objUser;
        }

        public async Task<User> GetUserByID(Guid userId)

        {
            return await _appDbContext.user.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
