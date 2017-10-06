using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson.Serialization;
using Oasis.Api.Models;

namespace Oasis.Api.Services
{
    public class CardServices
    {
        MongoClient _cl;
		IMongoDatabase _db;
        IMongoCollection<CardsModel> _co;

        public CardServices(string _cm)
        {
			_cl = new MongoClient(_cm);
			_db = _cl.GetDatabase("oasis");
			_co = _db.GetCollection<CardsModel>("Cards");
        }

        public IEnumerable<CardsModel> GetAllCard()
		{
            return _co.Find(new BsonDocument()).ToList();
		}

		public CardsModel GetCard(string cardId)
		{
            var filter = Builders<CardsModel>.Filter.Eq("_id", ObjectId.Parse(cardId));
			return _co.Find(filter).First();
		}

        public CardsModel CreateCard(CardsModel card)
		{
            var document = new BsonDocument 
            { 
                { "name", card.name }
            };
            _co.InsertOne(BsonSerializer.Deserialize<CardsModel>(document));
			return card;
		}

		public CardsModel Update(string cardId, CardsModel card)
		{
            var updateDef = Builders<CardsModel>.Update.Set(o => o.name, card.name);
            _co.UpdateOne(o => o._id == ObjectId.Parse(cardId), updateDef);
            return card;
		}

		public CardsModel Remove(string cardId)
		{
            var filter = Builders<CardsModel>.Filter.Eq("_id", ObjectId.Parse(cardId));
            _co.DeleteOne(filter);
            return null;
		}
    }
}
