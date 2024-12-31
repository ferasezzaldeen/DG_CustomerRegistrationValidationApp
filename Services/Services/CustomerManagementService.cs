using Core.Dtos;
using Microsoft.Extensions.Logging;
using Services.Interfaces;

namespace Services.Services
{
    public class CustomerManagementService : ICustomerManagementService
    {
        private readonly IAzureBusService _azureBusService;
        private readonly ILogger<CustomerManagementService> _logger;

        public CustomerManagementService(IAzureBusService azureBusService, ILogger<CustomerManagementService> logger)
        {
            _azureBusService = azureBusService;
            _logger = logger;
        }

        public async Task ValidateNewCustomer(CustomerReqDto reqModel)
        {
            _logger.LogInformation("Service Log: a new Customer has been received");
            await _azureBusService.PublishNewCustomer(reqModel);
            _logger.LogInformation("Service Log: Customer has been send to be validate via service bus");

        }
    }
}
