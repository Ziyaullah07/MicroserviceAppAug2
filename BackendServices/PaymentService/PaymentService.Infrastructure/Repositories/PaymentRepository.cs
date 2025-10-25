using PaymentService.Application.Repositories;
using PaymentService.Domain.Entities;
using PaymentService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        PaymentServiceDbContext _db;
        public PaymentRepository(PaymentServiceDbContext db)
        {
            _db = db;
        }
        public bool SavePaymentDetails(PaymentDetail model)
        {
            _db.PaymentDetails.Add(model);
            _db.SaveChanges();
            return true;
        }
    }
}
