using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ChatLog
    {
        public int Id { get; private set; }
        public int? ChannelId { get; private set; }
        public DateTime TimeCreated { get; private set; }

        public virtual ICollection<Message> Messages { get; protected set; }

        public virtual ICollection<User> Users { get; protected set; }

        public ChatLog(int channelId)
        {
            this.TimeCreated = DateTime.Now;
            this.ChannelId = channelId;
            this.Messages = new List<Message>();
            this.Users = new List<User>();
        }

        public ChatLog() { }
    }
}