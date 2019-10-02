using GraphQL.Types;
using GraphQLTest.GQLTypes.Landlord;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTest.GQLTypes.Property
{
    /// <summary>
    /// Needed for insertng property object to database
    /// </summary>
    public class PropertyInputType : InputObjectGraphType
    {
        public PropertyInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("city");
            Field<StringGraphType>("street");
            Field<StringGraphType>("family");
            Field<IntGraphType>("value");

            Field<LandlordInputType>("landlord");

        }
    }
}
