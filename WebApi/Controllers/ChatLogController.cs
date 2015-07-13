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
    [RoutePrefix("chatlogs")]
    public class ChatLogController : ApiController
    {
        private EarlyBirdsContext Context = new EarlyBirdsContext();

        [Route]
        public IHttpActionResult Get()
        {
            return Ok(Context.ChatLogs.ToList().Select(chat => ChatLogConverter.ToDto(chat)));
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            ChatLog chatlog = Context.ChatLogs.FirstOrDefault(c => c.Id == id);
            if (chatlog == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ChatLogConverter.ToDto(chatlog));
            }
        }

        [Route("{chatId:int}/messages")]
        public IHttpActionResult GetMessages(int chatId)
        {
            ChatLog chatLog = Context.ChatLogs.FirstOrDefault(c => c.Id == chatId);
            if (User == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(chatLog.Messages.ToList().Select(m => MessageConverter.ToDto(m)));
            }
        }

        [Route]
        public IHttpActionResult Post(ChatLog chatLog)
        {
            Context.ChatLogs.Add(chatLog);
            Context.SaveChanges();
            return Created(this.Request.RequestUri.AbsolutePath + "/" + chatLog.Id, chatLog);
        }

        [Route("{chatId:int}")]
        public IHttpActionResult Delete(int chatId)
        {
            ChatLog chat = Context.ChatLogs.FirstOrDefault(i => i.Id == chatId);
            if (chat == null)
            {
                return NotFound();
            }
            else
            {
                Context.ChatLogs.Remove(chat);
                Context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("{chatId:int}/add-user/{userId:int}")]
        public IHttpActionResult PutUser(int chatId, int userId)
        {
            ChatLog chatLog = Context.ChatLogs.FirstOrDefault(i => i.Id == chatId);
            User user = Context.Users.FirstOrDefault(i => i.Id == userId);
            if (chatLog == null || user == null)
            {
                return NotFound();
            }
            else
            {
                chatLog.Users.Add(user);
                user.Chats.Add(chatLog);
                Context.SaveChanges();
                return Ok();
            }
        }

        [Route("{chatId:int}/remove-user/{userId:int}")]
        public IHttpActionResult DeleteUser(int chatId, int userId)
        {
            ChatLog chatLog = Context.ChatLogs.FirstOrDefault(i => i.Id == chatId);
            User user = Context.Users.FirstOrDefault(i => i.Id == userId);
            if (chatLog == null || user == null)
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

        [Route("{chatId:int}/send-message")]
        public IHttpActionResult PostMessage(int chatId, Message message)
        {
            ChatLog chatLog = Context.ChatLogs.FirstOrDefault(i => i.Id == chatId);
            if (chatLog == null)
            {
                return NotFound();
            }
            else
            {
                Context.Messages.Add(message);
                Context.SaveChanges();
                return Ok();
            }
        }
    }
}
