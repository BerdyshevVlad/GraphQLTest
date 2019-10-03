using GraphQLTest.DataAcess.Repositories.Interfaces;
using GraphQLTest.Database.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLTest.DataAcess.Repositories
{
    public class LandlordRepository : ILandlordRepository
    {
        IMongoDatabase _database; // база данных

        public LandlordRepository(IMongoDatabase database)
        {
            _database = database;
        }

        private IMongoCollection<Landlord> Landlords
        {
            get { return _database.GetCollection<Landlord>("Landlords"); }
        }

        public Landlord Add(Landlord landlord)
        {
            Landlords.InsertOne(landlord);
            return landlord;
        }


        public List<Landlord> GetAll()
        {
            return Landlords.Find(new BsonDocument()).ToList();
        }


       
    }
}
