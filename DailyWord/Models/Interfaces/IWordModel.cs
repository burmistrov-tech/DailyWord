using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyWord.Models
{
    [BsonSerializer(typeof(ImpliedImplementationInterfaceSerializer<IWordModel, WordModel>))]
    public interface IWordModel : IModel
    {
        public string Value { get; set; }
        public string Email { get; set; }
        public DateTime DateTime { get; set; }
    }
}
