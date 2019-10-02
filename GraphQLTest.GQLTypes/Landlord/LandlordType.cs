using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTest.GQLTypes.Landlord
{
    public class LandlordType : ObjectGraphType<Database.Models.Landlord>
    {
        public LandlordType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.PhoneNumber);
        }
    }
}
