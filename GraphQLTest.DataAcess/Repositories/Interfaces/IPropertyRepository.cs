using GraphQLTest.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTest.DataAcess.Repositories.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
        Property GetById(int id);
        Property Add(Property property);
    }
}
