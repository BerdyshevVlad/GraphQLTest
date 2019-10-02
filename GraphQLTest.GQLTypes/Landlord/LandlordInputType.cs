using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTest.GQLTypes.Landlord
{
    public class LandlordInputType : InputObjectGraphType
    {
        public LandlordInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("phoneNumber");

        }
    }
}
