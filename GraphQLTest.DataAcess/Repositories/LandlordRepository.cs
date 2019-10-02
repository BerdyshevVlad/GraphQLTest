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
        IMongoDatabase database; // база данных
        IGridFSBucket gridFS;   // файловое хранилище

        public LandlordRepository()
        {
            string connectionString = "mongodb+srv://giftshare:Qwe123%21%21@cluster0-stn6x.mongodb.net/GraphQLTestDbMongo?retryWrites=true&w=majority";
            var connection = new MongoUrlBuilder(connectionString);
            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            // получаем доступ к самой базе данных
            database = client.GetDatabase(connection.DatabaseName);
            // получаем доступ к файловому хранилищу
            gridFS = new GridFSBucket(database);
        }

        private IMongoCollection<Landlord> Landlords
        {
            get { return database.GetCollection<Landlord>("Landlords"); }
        }

        public Landlord Add(Landlord landlord)
        {
            Landlords.InsertOne(landlord);
            return landlord;
        }


        public List<Landlord> Get()
        {
            return Landlords.Find(new BsonDocument()).ToList();
        }
    }
}
