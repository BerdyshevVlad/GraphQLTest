using GraphQLTest.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLTest.DataAcess.Repositories.Interfaces
{
    public interface ILandlordRepository
    {
        Landlord Add(Landlord landlord);
    }
}
