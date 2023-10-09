using CarRental.DAL.Data;
using CarRental.DAL.IRepo;
using CarRental.Shared.DTO_s;
using CarRental.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.Repo
{
    public class CarRepo : ICarRepo
    {
        private readonly AppDbContext _appDBContext;
        public CarRepo(AppDbContext context)
        {
            _appDBContext = context;
        }

        public async Task<Car> AddCar(Car car)
        {
            car.CarId = Guid.NewGuid();
            _appDBContext.car.Add(car);
            await _appDBContext.SaveChangesAsync();
            return car;
        }

        public bool DeleteCar(Guid carid)
        {
            bool result = false;
            var car = _appDBContext.car.Find(carid);
            if (car != null)
            {
                _appDBContext.Entry(car).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<Car> GetCarbyID(Guid carid)
        {
            return await _appDBContext.car.FindAsync(carid);
        }

        public  async Task<Car> UpdateCar(Car car)
        {
            _appDBContext.Entry(car).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return car;
        }

        public async Task<IEnumerable<Car>> ViewAllCars()
        {
            return await _appDBContext.car.ToListAsync();
        }



        //------------------------------------------------------------


        public bool IsAvailableChange(Guid carId)
        {
            var availablecar = _appDBContext.car.Find(carId);
            if (availablecar.IsAvailable == true)
            {
                availablecar.IsAvailable = false;
            }
            else
            {
                availablecar.IsAvailable = true;
            }
            _appDBContext.Entry(availablecar).State = EntityState.Modified;
            _appDBContext.SaveChangesAsync();
            return true;

        }
    }
}