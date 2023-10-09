using CarRental.DAL.IRepo;
using CarRental.Shared.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Presentation.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepo _car;
        public CarController(ICarRepo car)
        {
            _car = car;
        }


        [HttpGet]
        [Route("GetAllCars")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _car.ViewAllCars());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetCarByID/{Id}")]
        public async Task<IActionResult> GetCarById(Guid Id)
        {
            try
            {
                return Ok(await _car.GetCarbyID(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddCar")]
        public async Task<IActionResult> AddaCar([FromBody]Car car)
        {
            try
            {
                var result = await _car.AddCar(car);
                if (result.CarId == default(Guid))
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

        [HttpPut]
        [Route("UpdateCar")]
        public async Task<IActionResult> UpdateCar([FromBody]Car car)
        {
            try
            {
                await _car.UpdateCar(car);
                var response = new { message = "Added Successfully" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteCar")]
        public bool Delete(Guid carid)
        {
            try {
                _car.DeleteCar(carid);
                return true;
            }
            catch
                {
                return false;
            }
        }

        [HttpGet]
        [Route("CarByMaker/{maker}")]
        public async Task<IActionResult> CarByMaker(string maker)
        {
            try
            {
                var cars = await _car.ViewAllCars();
                var carsByMaker = cars.Where(item => item.Maker == maker);
                if(carsByMaker!=null)
                {
                    return Ok(carsByMaker);
                }
                else
                {
                    return NotFound();
                }
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        [Route("CarByModel/{model}")]
        public async Task<IActionResult> CarByModel(string model)
        {
            try
            {
                var cars = await _car.ViewAllCars();
                var carsByModel = cars.Where(item => item.Model == model);
                if (carsByModel != null)
                {
                    return Ok(carsByModel);
                }
                else
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        [Route("CarByPrice/{price}")]
        public async Task<IActionResult> CarByPrice(double price)
        {
            try
            {
                var cars = await _car.ViewAllCars();
                var carsByPrice = cars.Where(item => item.RentalPricePerDay <= price);
                if (carsByPrice != null)
                {
                    return Ok(carsByPrice);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
