using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Oasis.Api.Models
{
    public class CardsModel
    {

		[BsonId]
		public ObjectId _id { get; set; }

		[BsonElement("name")]
		public string name { get; set; }

    }
}
