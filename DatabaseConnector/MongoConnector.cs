using System;
using System.Net;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using DisneyWaitTime.DataObjects;

namespace DisneyWaitTime.DatabaseConnector
{
    public class MongoConnection :IWaitTimeDatabaseConnector
    {
            private MongoClient client;
            private readonly string ConnectionString = "";
            private bool IsConnectionOpen = false;
            public void OpenConnection()
            {
                IsConnectionOpen = true;
                client = new MongoClient(ConnectionString);
            }
            public void CloseConnection()
            {
                IsConnectionOpen = false;
                client = null;
            }

            public void SendWaitTimeData(List<AttractionWaitTime> data)
            {
                if(!IsConnectionOpen)
                    return;
                IMongoDatabase database = client.GetDatabase("disneywaittimes");
                IMongoCollection<AttractionWaitTime>  waitTimes = database.GetCollection<AttractionWaitTime>("attractionwaittimes");

                waitTimes.InsertMany(data);

            }
    }
}