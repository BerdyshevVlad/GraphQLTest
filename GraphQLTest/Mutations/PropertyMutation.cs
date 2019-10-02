using GraphQL.Types;
using GraphQLTest.DataAcess.Repositories.Interfaces;
using GraphQLTest.Database.Models;
using GraphQLTest.GQLTypes.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.Mutations
{
    public class PropertyMutation : ObjectGraphType
    {

        //    mutation($property: PropertyInputType!){
        //        addproperty(property: $property){
        //          id,
        //          name
        //        }
        //    }

        //variable
        //        {
        //          "property": {
        //              "name":"new (first) record from mutation",
        //              "city": "Kharkiv",
        //              "street": "",
        //              "family": "Shakhtar"
        //           }
        //         }



        public PropertyMutation(IPropertyRepository propertyRepository)
        {
            Field<PropertyType>("addproperty", arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<PropertyInputType>> { Name = "property" }),
                resolve: context =>
                 {
                     var property = context.GetArgument<Property>("property");
                     return propertyRepository.Add(property);
                 });
        }
    }
}
