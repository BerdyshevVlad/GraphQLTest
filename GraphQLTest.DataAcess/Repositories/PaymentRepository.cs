
using GraphQLTest.DataAcess.Repositories.Interfaces;
using GraphQLTest.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphQLTest.DataAcess.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly Database.AppSQLContext _db;

        public PaymentRepository(Database.AppSQLContext db)
        {
            _db = db;
        }

        public IEnumerable<Payment> GetAllForProperty(int propertyId)
        {
            return _db.Payments.Where(x => x.PropertyId == propertyId);
        }
        public IEnumerable<Payment> GetAllForProperty(int propertyId, int lastAmount)
        {
            return _db.Payments.Where(x => x.PropertyId == propertyId)
                .OrderByDescending(x => x.DateCreated)
                .Take(lastAmount);
        }
    }
}
