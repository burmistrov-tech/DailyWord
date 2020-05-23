using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DailyWord.Models
{
    public interface IModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
