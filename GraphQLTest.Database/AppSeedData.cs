using GraphQLTest.Database.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphQLTest.Database
{
    public static class AppSeedData
    {
        public static void EnsureSeedData(this AppSQLContext db, IMongoDatabase mongoDb)
        {
            if (!db.Properties.Any() || !db.Payments.Any())
            {
                var properties = new List<Property>
                {
                    new Property
                    {
                        City = "Katowice",
                        Family = "Smith",
                        Name = "Big house",
                        Street = "Sokolska",
                        Value = 100000,
                        Payments = new List<Payment>
                        {
                            new Payment
                            {
                                DateCreated = new DateTime(2019, 07, 01),
                                DateOverdue = new DateTime(2019, 07, 15),
                                Paid = true,
                                Value = 1500
                            },
                            new Payment
                            {
                                DateCreated = new DateTime(2019, 08, 01),
                                DateOverdue = new DateTime(2019, 08, 15),
                                Paid = true,
                                Value = 1500
                            },
                            new Payment
                            {
                                DateCreated = new DateTime(2019, 09, 01),
                                DateOverdue = new DateTime(2019, 09, 15),
                                Paid = false,
                                Value = 1500
                            }
                        }
                    },
                    new Property
                    {
                        City = "Warszawa",
                        Family = "Nowak",
                        Name = "White house",
                        Street = "Wiejska",
                        Value = 300500,
                        Payments = new List<Payment>
                        {
                            new Payment
                            {
                                DateCreated = new DateTime(2019, 07, 01),
                                DateOverdue = new DateTime(2019, 07, 15),
                                Paid = true,
                                Value = 3000
                            },
                            new Payment
                            {
                                DateCreated = new DateTime(2019, 08, 01),
                                DateOverdue = new DateTime(2019, 08, 15),
                                Paid = true,
                                Value = 3000
                            },
                            new Payment
                            {
                                DateCreated = new DateTime(2019, 09, 01),
                                DateOverdue = new DateTime(2019, 09, 15),
                                Paid = false,
                                Value = 3000
                            }
                        }
                    },
                    new Property
                    {
                        City = "Gdańska",
                        Family = "Pomorscy",
                        Name = "Sea house",
                        Street = "Gdańska",
                        Value = 51000,
                        Payments = new List<Payment>
                        {
                            new Payment
                            {
                                DateCreated = new DateTime(2019, 07, 01),
                                DateOverdue = new DateTime(2019, 07, 15),
                                Paid = true,
                                Value = 800
                            },
                            new Payment
                            {
                                DateCreated = new DateTime(2019, 08, 01),
                                DateOverdue = new DateTime(2019, 08, 15),
                                Paid = true,
                                Value = 800
                            },
                            new Payment
                            {
                                DateCreated = new DateTime(2019, 09, 01),
                                DateOverdue = new DateTime(2019, 09, 15),
                                Paid = true,
                                Value = 800
                            }
                        }
                    }
                };

                var mockPropertyWithLandlord = new Property();
                var landlord = SeedMongoDb(mongoDb);
                if (landlord != null)
                {

                    mockPropertyWithLandlord.City = "Rostov";
                    mockPropertyWithLandlord.Family = "Berdiev";
                    mockPropertyWithLandlord.Name = "\"Big Beef-Foot\" house";
                    mockPropertyWithLandlord.Street = "Sobaka str.";
                    mockPropertyWithLandlord.Value = 51000;
                    mockPropertyWithLandlord.LandlordId = landlord.Id;
                    mockPropertyWithLandlord.Payments = new List<Payment>
                        {
                            new Payment
                            {
                                DateCreated = new DateTime(2015, 07, 01),
                                DateOverdue = new DateTime(2015, 07, 15),
                                Paid = false,
                                Value = 300
                            },
                            new Payment
                            {
                                DateCreated = new DateTime(2018, 09, 01),
                                DateOverdue = new DateTime(2018, 09, 15),
                                Paid = true,
                                Value = 537
                            }
                    };
                }

                db.Properties.AddRange(properties);
                db.Properties.Add(mockPropertyWithLandlord);
                db.SaveChanges();
            }
        }


        private static Landlord SeedMongoDb(IMongoDatabase mongoDb)
        {
            var existingCollections = mongoDb.ListCollectionNames().ToList();
            if (!existingCollections.Contains("Landlords"))
            {
                mongoDb.CreateCollection("Landlords");
            }
            
            if (mongoDb.GetCollection<Landlord>("Landlords").AsQueryable().Any())
            {
                return null;
            }

            var landlord = new Landlord()
            {
                Name = "Antony",
                PhoneNumber = "+380123456789"
            };

            var landlords = mongoDb.GetCollection<Landlord>("Landlords");
            landlords.InsertOne(landlord);

            return landlord;
        }
    }
}
