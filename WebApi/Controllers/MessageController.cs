using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service.Converters;
using Dto = Service.Dto;
using Domain;

namespace WebApi.Controllers
{
    [RoutePrefix("messages")]
    public class MessageController : ApiController
    {
        private EarlyBirdsContext Context = new EarlyBirdsContext();

        [Route]
        public IHttpActionResult Get()
        {
            return Ok(Context.Messages.ToList().Select(message => MessageConverter.ToDto(message)));
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            Message message = Context.Messages.FirstOrDefault(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(MessageConverter.ToDto(message));
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.Message message)
        {
            Context.Messages.Add(new Message(message.Text, message.UserId, message.ChatLogId));
            Context.SaveChanges();
            return Created(this.Request.RequestUri.AbsolutePath + "/" + message.Id, message);
        }
    }
}
