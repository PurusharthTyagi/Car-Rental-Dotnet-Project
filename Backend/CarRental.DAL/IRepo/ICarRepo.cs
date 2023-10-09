using CarRental.Shared.DTO_s;
using CarRental.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL.IRepo
{
    public interface ICarRepo
    {
        public Task<Car> AddCar(Car car);
        public Task<IEnumerable<Car>> ViewAllCars();
        public Task<Car> GetCarbyID(Guid carid);
        public Task<Car> UpdateCar(Car carid);
        public bool DeleteCar(Guid carid);
        public bool IsAvailableChange(Guid carId);
    }
}
