using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Oasis.Api.Models;
using Oasis.Api.Services;

namespace Oasis.Api.Controllers
{
    [Route("api/Cards")]
    public class CardsControllers : Controller
    {
        CardServices _in;
        // Constructor
        public CardsControllers(IConfiguration configuration)
        {
            string _cm = configuration["ConnectionString:MongoUrl"];
            _in = new CardServices(_cm);
        }

        // GET api/cards
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return _in.GetAllCard();
        }

        // GET api/cards/1
        [HttpGet("{id}")]
        public object Get(string id)
        {
            return _in.GetCard(id);
        }

        // POST api/cards
        [HttpPost]
        public CardsModel Post([FromBody]CardsModel card)
        {
		   return _in.CreateCard(card);
        }

        // PUT api/cards/1
        [HttpPut("{id}")]
        public CardsModel Put(string id, [FromBody]CardsModel card)
        {
			return _in.Update(id, card);
        }

        // DELETE api/cards/1
        [HttpDelete("{id}")]
        public object Delete(string id)
        {
			_in.Remove(id);
            return Ok();
        }
    }
}
