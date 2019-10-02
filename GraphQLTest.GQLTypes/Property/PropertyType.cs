using GraphQL.Types;
using GraphQLTest.GQLTypes.Landlord;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTest.GQLTypes.Property
{
    public class PropertyType : ObjectGraphType<Database.Models.Property>
    {
        public PropertyType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Value);
            Field(x => x.City);
            Field(x => x.Family);
            Field(x => x.Street);

            Field(x => x.Landlord, type: typeof(LandlordType));
        }
    }
}
