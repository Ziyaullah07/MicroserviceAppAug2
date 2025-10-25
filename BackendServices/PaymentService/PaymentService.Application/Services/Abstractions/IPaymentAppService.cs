using PaymentService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Services.Abstractions
{
    public interface IPaymentAppService
    {
        bool SavePaymentDetails(PaymentDetailDTO model);
    }
}
