using Azure.Messaging.ServiceBus;
using Core.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Services.Interfaces;

namespace Services.Services
{
    public class AzureBusService : IAzureBusService
    {
        private readonly ServiceBusSender _publisher;
        private readonly ILogger<AzureBusService> _logger;

        public AzureBusService(ServiceBusClient serviceBusClient, IConfiguration configuration, ILogger<AzureBusService> logger)
        {
            var queueName = configuration["ServiceBus:QueueName"];
            _publisher = serviceBusClient.CreateSender(queueName);
            _logger = logger;
        }

        public async Task PublishNewCustomer(CustomerReqDto customerModel)
        {
            try
            {
                var messageContent = JsonConvert.SerializeObject(customerModel);
                var message = new ServiceBusMessage(messageContent);
                await _publisher.SendMessageAsync(message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending message: {ex.Message}");
            }
        }
    }
}
