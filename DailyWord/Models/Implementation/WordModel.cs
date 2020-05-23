using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;
using System.ComponentModel;

namespace DailyWord.Models
{
    public class WordModel : IWordModel
    {
        [BsonId]        
        public ObjectId Id { get; set; }
        [DisplayName("Daily word")]
        public string Value { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        public DateTime DateTime { get; set; }
    }
}
