using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; private set; }
        public virtual ICollection<Ticket> Tickets { get; protected set; }

        public Client(string firstName, string lastName)
        {
            if (firstName == null || lastName == null)
            {
                throw new ArgumentNullException();
            }
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Tickets = new List<Ticket>();
        }

        public Client() { }
    }
}
