using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Net;
using Domain;
using Service.Converters;

namespace WebApi.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {

        private EarlyBirdsContext Context = new EarlyBirdsContext();
        
        [Route]
        public IHttpActionResult Get()
        {
            return Ok(Context.Users.ToList().Select(user => UserConverter.ToDto(user)));
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            User user = Context.Users.FirstOrDefault(i => i.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(UserConverter.ToDto(user));
            }
        }

        [Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            User user = Context.Users.FirstOrDefault(i => i.LastName == name);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(UserConverter.ToDto(user));
            }
        }

        [Route("{userId:int}/messages")]
        public IHttpActionResult GetMessages(int userId)
        {
            User user = Context.Users.FirstOrDefault(i => i.Id == userId);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user.Messages.ToList().Select(m => MessageConverter.ToDto(m)));
            }
        }

        [Route("{name}/messages")]
        public IHttpActionResult GetMessages(string name)
        {
            User user = Context.Users.FirstOrDefault(i => i.LastName.ToLower() == name.ToLower());
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user.Messages.ToList().Select(m => MessageConverter.ToDto(m)));
            }
        }

        [Route("{userId:int}/channels")]
        public IHttpActionResult GetChannels(int userId)
        {
            User user = Context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user.Channels.ToList().Select(c => ChannelConverter.ToDto(c)));
            }
        }

        [Route("{name}/channels")]
        public IHttpActionResult GetChannels(string name)
        {
            User user = Context.Users.FirstOrDefault(u => u.LastName.ToLower() == name.ToLower());
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user.Channels.ToList().Select(c => ChannelConverter.ToDto(c)));
            }
        }

        [Route]
        public IHttpActionResult Post(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return Created(this.Request.RequestUri.AbsolutePath + "/" + user.Id, user);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, User user)
        {
            User existing = Context.Users.FirstOrDefault(i => i.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            else
            {
                existing.FirstName = user.FirstName;
                existing.LastName = user.LastName;
                Context.SaveChanges();
                return Ok(existing);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            User existing = Context.Users.FirstOrDefault(i => i.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            else
            {
                Context.Users.Remove(existing);
                Context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
