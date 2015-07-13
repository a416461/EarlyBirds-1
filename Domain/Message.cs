using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Message
    {
        public int Id { get; private set; }
        public int ChatLogId { get; private set; }
        public int UserId { get; private set; }
        public string Text { get; private set; }

        public Message(string text, int userId, int chatLogId)
        {
            this.Text = text;
            this.UserId = userId;
            this.ChatLogId = chatLogId;
        }

        public Message() { }

    }
}
