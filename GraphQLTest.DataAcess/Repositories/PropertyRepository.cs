using GraphQLTest.DataAcess.Repositories.Interfaces;
using GraphQLTest.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphQLTest.DataAcess.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly Database.AppSQLContext _db;

        public PropertyRepository(Database.AppSQLContext db)
        {
            _db = db;
        }

        public IEnumerable<Property> GetAll()
        {
            return _db.Properties;
        }

        public Property GetById(int id)
        {
            return _db.Properties.SingleOrDefault(x => x.Id == id);
        }

        public Property Add(Property property)
        {
            _db.Properties.Add(property);
            _db.SaveChanges();
            return property;
        }
    }
}
