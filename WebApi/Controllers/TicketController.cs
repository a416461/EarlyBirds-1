using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dto = Service.Dto;
using Domain;
using Service.Converters;

namespace WebApi.Controllers
{
    [RoutePrefix("tickets")]
    public class TicketController : ApiController
    {
        private EarlyBirdsContext Context = new EarlyBirdsContext();

        [Route]
        public IHttpActionResult Get()
        {
            return Ok(Context.Tickets.ToList().Select(ticket => TicketConverter.ToDto(ticket)));
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            Ticket ticket = Context.Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(TicketConverter.ToDto(ticket));
            }
        }

        [Route("{ticketId:int}/channels")]
        public IHttpActionResult GetChannels(int ticketId)
        {
            Ticket ticket = Context.Tickets.FirstOrDefault(t => t.Id == ticketId);
            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Context.Tickets.ToList().Select(c => TicketConverter.ToDto(c)));
            }
        }

        [Route("{ticketId:int}")]
        public IHttpActionResult Delete(int ticketId)
        {
            Ticket existing = Context.Tickets.FirstOrDefault(i => i.Id == ticketId);
            if (existing == null)
            {
                return NotFound();
            }
            else
            {
                Context.Tickets.Remove(existing);
                Context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("{ticketId:int}")]
        public IHttpActionResult Put(int ticketId, Dto.Ticket response)
        {
            Ticket ticket = Context.Tickets.FirstOrDefault(i => i.Id == ticketId);
            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                ticket.Edit(response.Response);
                Context.SaveChanges();
                return Ok(TicketConverter.ToDto(ticket));
            }

        }
    }
}

