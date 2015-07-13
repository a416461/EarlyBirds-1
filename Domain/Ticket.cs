using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Ticket
    {
        public int Id { get; private set; }
        public int ClientId { get; private set; }
        public bool IsResolved { get; private set; }
        public string Question { get; private set; }
        public string Response { get; set; }

        public virtual ICollection<Channel> Channels { get; protected set; }

        public DateTime TimeSubmitted { get; private set; }
        public DateTime? TimeResolved { get; private set; }

        public Ticket(string question, int clientId)
        {
            this.Question = question;
            this.ClientId = clientId;
            this.TimeSubmitted = DateTime.Now;
            this.IsResolved = false;
            this.Channels = new List<Channel>();
        }

        public Ticket() { }

        public void Resolve(bool b)
        {
            if (b)
            {
                this.IsResolved = true;
                if (this.TimeResolved == null)
                {
                    this.TimeResolved = DateTime.Now;
                }
            }
            else
            {
                this.IsResolved = false;
                this.TimeResolved = DateTime.Now;
            }
        }

        public void Edit(string s)
        {
            this.Response = s;
        }
    }
}
