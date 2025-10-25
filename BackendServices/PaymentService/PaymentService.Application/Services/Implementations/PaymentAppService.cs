using AutoMapper;
using PaymentService.Application.DTOs;
using PaymentService.Application.Repositories;
using PaymentService.Application.Services.Abstractions;
using PaymentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Services.Implementations
{
    public class PaymentAppService : IPaymentAppService
    {
        IMapper _mapper;
        IPaymentRepository _paymentRepository;
        public PaymentAppService(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public bool SavePaymentDetails(PaymentDetailDTO model)
        {
            PaymentDetail payment = _mapper.Map<PaymentDetail>(model);
            return _paymentRepository.SavePaymentDetails(payment);
        }
    }
}
