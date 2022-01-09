using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CarService_Server.Models;
using CarService_Server.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarService_Server.Controllers
{
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            var clients = ClientRepository.GetClients();

            return Ok(clients);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            var client = ClientRepository.GetClient(id);

            if (client != null)
            {
                return Ok(client);
            } else
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Client client)
        {
            ClientRepository.AddClient(client);

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Client client, long id)
        {
            var dbClient = ClientRepository.GetClient(id);

            if (dbClient != null)
            {
                ClientRepository.UpdateClient(client);

                return Ok();
            } else
            {
                return NotFound();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var client = ClientRepository.GetClient(id);

            if (client != null)
            {
                ClientRepository.DeleteClient(client);
                return Ok();
            } else
            {
                return NotFound();
            }
        }
    }
}
