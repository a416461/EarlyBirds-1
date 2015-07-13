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
    [RoutePrefix("channels")]
    public class ChannelController : ApiController
    {
        private EarlyBirdsContext Context = new EarlyBirdsContext();

        [Route]
        public IHttpActionResult Get()
        {
            return Ok(Context.Channels.ToList().Select(channel => ChannelConverter.ToDto(channel)));
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            Channel channel = Context.Channels.FirstOrDefault(c => c.Id == id);
            if (channel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ChannelConverter.ToDto(channel));
            }
        }

        [Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            Channel channel = Context.Channels.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
            if (channel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ChannelConverter.ToDto(channel));
            }
        }

        [Route("{channelId:int}/users")]
        public IHttpActionResult GetUsers(int channelId)
        {
            Channel channel = Context.Channels.FirstOrDefault(i => i.Id == channelId);
            if (channel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(channel.Users.ToList().Select(u => UserConverter.ToDto(u)));
            }
        }

        [Route("{channelName}/users")]
        public IHttpActionResult GetUsers(string channelName)
        {
            Channel channel = Context.Channels.FirstOrDefault(c => c.Name.ToLower() == channelName.ToLower());
            if (channel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(channel.Users.ToList().Select(u => UserConverter.ToDto(u)));
            }
        }

        [Route("{channelId:int}/tickets")]
        public IHttpActionResult GetTickets(int channelId)
        {
            Channel channel = Context.Channels.FirstOrDefault(i => i.Id == channelId);
            if (channel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(channel.Tickets.ToList().Select(t => TicketConverter.ToDto(t)));
            }
        }

        [Route("{channelName}/tickets")]
        public IHttpActionResult GetTickets(string channelName)
        {
            Channel channel = Context.Channels.FirstOrDefault(c => c.Name.ToLower() == channelName.ToLower());
            if (channel == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(channel.Tickets.ToList().Select(t => TicketConverter.ToDto(t)));
            }
        }
        
        [Route]
        public IHttpActionResult Post(Channel channel)
        {
            Channel chan = new Channel(channel.Name, channel.Category, new ChatLog(channel.Id));
            Context.Channels.Add(channel);
            Context.SaveChanges();
            return Created(this.Request.RequestUri.AbsolutePath + "/" + channel.Id, channel);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, Channel channel)
        {
            Channel existing = Context.Channels.FirstOrDefault(i => i.Id == id);
            if (existing == null)
            {
                return NotFound();
            }    
            else
            {
                existing.Name = channel.Name;
                Context.SaveChanges();
                return Ok(existing);
            }
        }

        [Route("{channelId:int}")]
        public IHttpActionResult Delete(int channelId)
        {
            Channel channel = Context.Channels.FirstOrDefault(i => i.Id == channelId);
            if (channel == null)
            {
                return NotFound();
            }
            else
            {
                Context.Channels.Remove(channel);
                Context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("{channelId:int}/add-user/{userId:int}")]
        public IHttpActionResult PutUser(int channelId, int userId)
        {
            Channel channel = Context.Channels.FirstOrDefault(i => i.Id == channelId);
            User user = Context.Users.FirstOrDefault(i => i.Id == userId);
            if (channel == null || user == null)
            {
                return NotFound();
            }
            else
            {
                channel.Users.Add(user);
                Context.SaveChanges();
                return Ok();
            }
        }

        [Route("{channelId:int}/remove-user/{userId:int}")]
        public IHttpActionResult DeleteUser(int channelId, int userId)
        {
            Channel channel = Context.Channels.FirstOrDefault(i => i.Id == channelId);
            User user = Context.Users.FirstOrDefault(i => i.Id == userId);
            if (channel == null)
            {
                return NotFound();
            }
            else
            {
                Context.Users.Remove(user);
                Context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
