using CarRental.BL.Services;
using CarRental.DAL.Data;
using CarRental.DAL.IRepo;
using CarRental.Shared.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarRental.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        private readonly IUserRepo _user;
        public UserController(IUserRepo user, AppDbContext appDbContext,IConfiguration configuration)
        {
            _user = user;
            _appDbContext = appDbContext;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<IActionResult> Post(User objUser)
        {
            try
            {
                var result = await _user.AddUser(objUser);
                if (result.UserId == default)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
                }
                return Ok("Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        [Route("GetUserByID")]
        public async Task<IActionResult> GetUserByID(Guid Id)
        {
            try
            {
                return Ok(await _user.GetUserByID(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        [HttpPost]
        [Route("LoginUser")]
        public IActionResult Login(Login user)
        {
            var userAvaliable = _appDbContext.user.FirstOrDefault(u => u.Email == user.Username && u.Password == user.Password);
            if (userAvaliable != null)
            {
                return Ok(new JwtService(_configuration).GenerateToken(
                    userAvaliable.UserId.ToString(),
                    userAvaliable.Name,
                    userAvaliable.Email,
                    userAvaliable.PhoneNo.ToString(),
                    userAvaliable.IsAdmin
                    )
                    );
            }
            return Ok("Failure");

        }
    }
}
