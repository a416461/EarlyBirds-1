using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using Service.Converters;

namespace WebApi.Controllers
{
    [RoutePrefix("clients")]
    public class ClientController : ApiController
    {
        private EarlyBirdsContext Context = new EarlyBirdsContext();

        [Route]
        public IHttpActionResult Get()
        {
            return Ok(Context.Clients.ToList().Select(client => ClientConverter.ToDto(client)));
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            Client client = Context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ClientConverter.ToDto(client));
            }
        }

        [Route("{lastname}")]
        public IHttpActionResult Get(string lastName)
        {
            Client client = Context.Clients.FirstOrDefault(c => c.LastName.ToLower() == lastName.ToLower());
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ClientConverter.ToDto(client));
            }
        }

        [Route("{clientId:int}/tickets")]
        public IHttpActionResult GetTickets(int clientId)
        {
            Client client = Context.Clients.FirstOrDefault(i => i.Id == clientId);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(client.Tickets.ToList().Select(t => TicketConverter.ToDto(t)));
            }
        }

        [Route("{lastName}/tickets")]
        public IHttpActionResult GetTickets(string lastName)
        {
            Client client = Context.Clients.FirstOrDefault(i => i.LastName.ToLower() == lastName.ToLower());
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(client.Tickets.ToList().Select(t => TicketConverter.ToDto(t)));
            }
        }

        [Route("{clientId:int}")]
        public IHttpActionResult Put(int clientId, Client client)
        {
            Client existing = Context.Clients.FirstOrDefault(i => i.Id == clientId);
            if (existing == null)
            {
                return NotFound();
            }
            else
            {
                existing.FirstName = client.FirstName;
                existing.LastName = client.LastName;
                Context.SaveChanges();
                return Ok(existing);
            }
        }

        [Route("{clientId:int}")]
        public IHttpActionResult Delete(int clientId)
        {

            Client client = Context.Clients.FirstOrDefault(i => i.Id == clientId);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                Context.Clients.Remove(client);
                Context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }

        }

    }
}
