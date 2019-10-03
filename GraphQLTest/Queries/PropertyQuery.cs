using GraphQL.Types;
using GraphQLTest.DataAcess.Repositories.Interfaces;
using GraphQLTest.Database.Models;
using GraphQLTest.GQLTypes.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTest.Queries
{
    public class PropertyQuery : ObjectGraphType
    {
        public PropertyQuery(IPropertyRepository propertyRepository,ILandlordRepository landlordRepository)
        {
            Field<ListGraphType<PropertyType>>("properties", resolve: context =>
            {
                var properties = propertyRepository.GetAll();
                var landlords = landlordRepository.GetAll();

                var result = landlords.GroupJoin(properties,p=>p.Id,l=>l.LandlordId, (p, propertiesGroup) => new 
                {
                    Properties = propertiesGroup,
                    LandlordId = p.Id,
                    LandlordName=p.Name,
                    LandlordPhoneNumber=p.PhoneNumber
                });

                List<Property> propertyList = new List<Property>();

                var res = result.SelectMany(x =>x.Properties.Select(p=>
                {
                    return new Property()
                    {
                        Id = p.Id,
                        City = p.City,
                        Family = p.Family,
                        Name = p.Name,
                        Payments = p.Payments,
                        Street = p.Street,
                        Value = p.Value,
                        Landlord = new Landlord()
                        {
                            Id = x.LandlordId,
                            Name = x.LandlordName,
                            PhoneNumber = x.LandlordPhoneNumber
                        }
                    };
                })).ToList();

                return propertyList;
            });
        }
    }
}
