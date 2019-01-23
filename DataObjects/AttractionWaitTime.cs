using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DisneyWaitTime.DataObjects
{

    public class AttractionWaitTime
    {
        [BsonId]
        public ObjectId _ID { get; set; }
        [BsonElement("id")]
        public int ID { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } 
        [BsonElement("attractionType")]
        public string AttractionType { get; set; }
        [BsonElement("fastPass")]
        public bool FastPass { get; set; }
        [BsonElement("singleRider")]
        public bool SingleRider { get; set; }
        [BsonElement("postedWaitMinutes")]
        public int PostedWaitMinutes { get; set; }
        [BsonElement("status")]
        public string Status { get; set; }
        [BsonElement("rollUpStatus")]
        public string RollUpStatus { get; set; }
        [BsonElement("rollUpWaitTimeMessage")]
        public string RollUpWaitTimeMessage { get; set; }
    }
}