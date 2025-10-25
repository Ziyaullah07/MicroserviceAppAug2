﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using PaymentService.Application.DTOs;
using PaymentService.Infrastructure.Providers.Abstractions;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Infrastructure.Providers.Implementations
{
    public class PaymentProvider : IPaymentProvider
    {
        RazorpayClient _client;
        IMapper _mapper;
        IConfiguration _configuration;
        public PaymentProvider(IMapper mapper, IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new RazorpayClient(_configuration["RazorPay:Key"], _configuration["RazorPay:Secret"]);
            _mapper = mapper;
        }
        private static string getActualSignature(string payload, string secret)
        {
            byte[] secretBytes = StringEncode(secret);
            HMACSHA256 hashHmac = new HMACSHA256(secretBytes);
            var bytes = StringEncode(payload);

            return HashEncode(hashHmac.ComputeHash(bytes));
        }

        private static byte[] StringEncode(string text)
        {
            var encoding = new ASCIIEncoding();
            return encoding.GetBytes(text);
        }

        private static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        public string CreateOrder(RazorPayOrderDTO order)
        {
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", 50000); // amount in the smallest currency unit
            options.Add("receipt", "order_rcptid_11");
            options.Add("currency", "INR");
            Order data = _client.Order.Create(options);
            return data["id"].ToString();
        }

        public Payment GetPaymentDetails(string paymentId)
        {
            return _client.Payment.Fetch(paymentId);
        }

        public string VerifyPayment(PaymentConfirmDTO payment)
        {
            string payload = string.Format("{0}|{1}", payment.OrderId, payment.PaymentId);
            string secret = RazorpayClient.Secret;
            string actualSignature = getActualSignature(payload, secret);
            bool status = actualSignature.Equals(payment.Signature);
            if (status)
            {
                Payment paymentDetails = GetPaymentDetails(payment.PaymentId);
                return paymentDetails["status"].ToString();
            }
            return "";
        }
    }
}
