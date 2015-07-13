using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum UserType { Representative, Admin }
    
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get;  set; }
        public int Id { get; private set; }
        public UserType? UserT;
        public DateTime DateJoined { get; private set; } 

        public virtual ICollection<Channel> Channels { get; protected set; }

        public virtual ICollection<ChatLog> Chats { get; protected set; }

        public virtual ICollection<Message> Messages { get; protected set; }
        
        public User()
        {

        }

        public User(string firstName, string lastName, UserType type)
        {
            if (firstName == null || lastName == null)
            {
                throw new ArgumentNullException();
            }
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserT = type;
            this.DateJoined = DateTime.Now;
            this.Messages = new List<Message>();
            this.Chats = new List<ChatLog>();
            this.Channels = new List<Channel>();
        }
    }
}
