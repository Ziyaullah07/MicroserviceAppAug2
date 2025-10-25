using Microsoft.AspNetCore.Mvc;
using PaymentService.Application.DTOs;
using PaymentService.Application.Services.Abstractions;
using PaymentService.Infrastructure.Providers.Abstractions;

namespace PaymentService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : Controller
    {
        IPaymentAppService _paymentService;
        IPaymentProvider _paymentProvider;
        public PaymentController(IPaymentAppService paymentAppService, IPaymentProvider paymentProvider)
        {
            _paymentService = paymentAppService;
            _paymentProvider = paymentProvider;
        }

        [HttpPost]
        public IActionResult CreateOrder(RazorPayOrderDTO order)
        {
            string orderId = _paymentProvider.CreateOrder(order);
            return Ok(orderId);
        }

        [HttpPost]
        public IActionResult VerifyPayment(PaymentConfirmDTO payment)
        {
            string status = _paymentProvider.VerifyPayment(payment);
            return Ok(status);
        }

        [HttpPost]
        public IActionResult SavePaymentDetails(PaymentDetailDTO payment)
        {
            bool status = _paymentService.SavePaymentDetails(payment);
            return Ok(status);
        }
    }
}
