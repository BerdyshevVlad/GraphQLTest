using GraphQL.Types;
using GraphQLTest.DataAcess.Repositories.Interfaces;
using GraphQLTest.Database.Models;
using GraphQLTest.GQLTypes.Landlord;
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













        //        mutation($property: PropertyInputType!)
        //        {
        //            addproperty(property: $property) {
        //                id,
        //                name
        //            }
        //        }


        //  {
        //  "property":{
        //    "name": "Big Towr 1",
        //    "city":"Rostov",
        //    "street":"Sobaka str",
        //    "family":"Berdiev",
        //    "value":300,

        //  	"landlord":{
        //    	"name":"Anastasya",
        //    	"phoneNumber":"+380662156"
        //  	}
        //	}
        //}



        public PropertyMutation(IPropertyRepository propertyRepository, ILandlordRepository landlordRepository)
        {
            Field<PropertyType>("addproperty", arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<PropertyInputType>> { Name = "property" }),
                resolve: context =>
                 {
                     var property = context.GetArgument<Property>("property");
                     landlordRepository.Add(property.Landlord);
                     property.LandlordId = property.Landlord.Id;
                     var prop = propertyRepository.Add(property);


                     return property;

                 });
        }
    }
}
