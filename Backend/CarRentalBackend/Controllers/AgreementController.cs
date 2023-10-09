using CarRental.DAL.IRepo;
using CarRental.Shared.DTO_s;
using CarRental.Shared.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Presentation.Controllers
{
    public class AgreementController : Controller
    {
        private readonly IAgreementRepo _agreement;
        private readonly IReqForReturn _request;
        public AgreementController(IAgreementRepo agreement, IReqForReturn request)
        {
            _agreement = agreement;
            _request = request;
        }


        [HttpGet]
        [Route("GetAllAgreement")]
        public async Task<IActionResult> GetAll()
        {
            try {
                return Ok(await _agreement.ViewAllAgreements());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("GetAgreementByID")]
        public async Task<IActionResult> AgreementById(Guid Id)
        {
            try
            {
                return Ok(await _agreement.GetAgreementByID(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddAgreement")]
        public async Task<IActionResult> AddAgreement(RentalAgreement agreement)
        {
            try
            {
                await _agreement.GenerateAgreement(agreement);

                var response = new { message = "Added Successfully" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateAgreement")]
        public async Task<IActionResult> UpdateAgreement(RentalAgreement agreement)
        {
            try
            {
                await _agreement.UpdateAgreement(agreement);
                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteAgreement")]
        public bool Delete(Guid rentalid)
        {
            try
            {
                _agreement.DeleteAgreement(rentalid);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpGet]
        [Route("AgreementByUserId")]
        public async Task<IActionResult> AllUserAgreements(Guid userId)
        {
            try
            {
                var agreement = await _agreement.ViewAllAgreements();
                var agreementofuser = agreement.Where(item => item.UserId == userId);
                return Ok(agreementofuser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        //------------------------------------------------------REQUESTS ------------------------------------------------------------------------------------------------




        [HttpPut]
        [Route("RequestForReturn")]
        public bool ReturnRequest(Guid rentalagreementId)
        {
            try
            {
                if (rentalagreementId != null)
                {
                    _request.RequestForReturn(rentalagreementId);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }



        [HttpPut]
        [Route("AcceptRequestForReturn")]
        public bool AcceptReturnRequest(Guid rentalagreementId)
        {
            try
            {
                if (rentalagreementId != null)
                {
                    _request.ReturnRequestApproved(rentalagreementId);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

    }
}

