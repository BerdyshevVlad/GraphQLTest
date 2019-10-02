using GraphQL.Types;
using GraphQLTest.DataAcess.Repositories.Interfaces;
using GraphQLTest.Database.Models;
using GraphQLTest.GQLTypes.Landlord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.Mutations
{
    public class LandlordMutation : ObjectGraphType
    {
        public LandlordMutation(ILandlordRepository landlordRepository)
        {
            Field<LandlordType>("addLandlord", arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<LandlordInputType>> { Name = "landlord" }),
                resolve: context =>
                {
                    var landlord = context.GetArgument<Landlord>("landlord");
                    return landlordRepository.Add(landlord);
                });
        }
    }
}
