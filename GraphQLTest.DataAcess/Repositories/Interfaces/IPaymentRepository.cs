using GraphQLTest.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTest.DataAcess.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllForProperty(int propertyId);
        IEnumerable<Payment> GetAllForProperty(int propertyId, int lastAmount);
    }
}
