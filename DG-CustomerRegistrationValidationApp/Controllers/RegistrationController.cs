using Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace DG_CustomerRegistrationValidationApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ICustomerManagementService _customerManagementService;

        public RegistrationController(ICustomerManagementService customerManagementService)
        {
            _customerManagementService = customerManagementService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer(CustomerReqDto reqModel)
        {
            await _customerManagementService.ValidateNewCustomer(reqModel);
            return StatusCode(200, "Your Application has been submitted successfully");
        }
    }
}
