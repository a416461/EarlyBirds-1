using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Channel
    {
        public string Name { get; set; }
        public string Category { get; private set; }
        public int Id { get; private set; }
        public int AdminId { get; private set; }

        public virtual ICollection<User> Users { get; protected set; }

        public virtual ICollection<Ticket> Tickets { get; protected set; }

        public virtual ChatLog Chat { get; protected set; }

        public Channel() { }

        public Channel(string name, string category, ChatLog chat)
        {
            this.Name = name;
            this.Category = category;
            this.Users = new List<User>();
            this.Tickets = new List<Ticket>();
            this.Chat = chat;
        }
    }
}