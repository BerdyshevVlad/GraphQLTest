using GraphQL.Types;
using GraphQLTest.DataAcess.Repositories.Interfaces;
using GraphQLTest.GQLTypes.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.Queries
{
    public class PropertyQuery : ObjectGraphType
    {
        public PropertyQuery(IPropertyRepository propertyRepository)
        {
            Field<ListGraphType<PropertyType>>("properties", resolve: context => propertyRepository.GetAll());
        }
    }
}
