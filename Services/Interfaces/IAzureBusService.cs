using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAzureBusService
    {
        Task PublishNewCustomer(CustomerReqDto customerModel);
    }
}
