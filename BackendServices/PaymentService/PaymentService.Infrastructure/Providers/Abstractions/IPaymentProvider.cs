using PaymentService.Application.DTOs;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Infrastructure.Providers.Abstractions
{
    public interface IPaymentProvider
    {
        string CreateOrder(RazorPayOrderDTO order);
        Payment GetPaymentDetails(string paymentId);
        string VerifyPayment(PaymentConfirmDTO payment);
    }
}
