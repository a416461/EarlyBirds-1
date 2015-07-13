using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class EarlyBirdsInitializer : DropCreateDatabaseIfModelChanges<EarlyBirdsContext>
    {
        protected override void Seed(EarlyBirdsContext context)
        {
            List<User> users = GetUsers();
            users.ForEach(i => context.Users.Add(i));

            List<Client> clients = GetClients();
            clients.ForEach(i => context.Clients.Add(i));

            List<ChatLog> chatLogs = GetChatLogs();
            chatLogs.ForEach(i => context.ChatLogs.Add(i));
            context.SaveChanges();

            List<Channel> channels = GetChannels(chatLogs);
            channels.ForEach(i => context.Channels.Add(i));

            List<Message> messages = GetMessages();
            messages.ForEach(i => context.Messages.Add(i));

            List<Ticket> tickets = GetTickets();
            tickets.ForEach(i => context.Tickets.Add(i));

             channels[0].Users.Add(users.ElementAt(0));
             channels[1].Users.Add(users.ElementAt(0));
             channels[2].Users.Add(users.ElementAt(0));
             channels[3].Users.Add(users.ElementAt(0));

            channels[0].Tickets.Add(tickets.ElementAt(0));
            channels[0].Tickets.Add(tickets.ElementAt(1));
            channels[1].Tickets.Add(tickets.ElementAt(2));
            channels[1].Tickets.Add(tickets.ElementAt(3));
            channels[2].Tickets.Add(tickets.ElementAt(4));
            channels[2].Tickets.Add(tickets.ElementAt(5));
            channels[3].Tickets.Add(tickets.ElementAt(6));
            channels[3].Tickets.Add(tickets.ElementAt(7));

            context.SaveChanges();
        }

        private List<Channel> GetChannels(List<ChatLog> chats)
        {
            List<Channel> channels = new List<Channel>()
            {
                new Channel("Vintage Software", "General Support", chats[0]),
                new Channel("Star Wars", "Entertainment", chats[1]),
                new Channel("MLS", "Sports", chats[2]),
                new Channel("Oddities", "Misc.", chats[3])
            };
            return channels;
        }

        private List<ChatLog> GetChatLogs()
        {
            List<ChatLog> chatLogs = new List<ChatLog>()
            {
                new ChatLog(1),
                new ChatLog(2),
                new ChatLog(3),
                new ChatLog(4)
            };
            return chatLogs;
        }

        private List<Client> GetClients()
        {
            List<Client> clients = new List<Client>()
            {
                new Client("Andy", "Stevens"),
                new Client("Bob", "Person"),
                new Client("Joe", "Guy"),
                new Client("JarJar", "Binks"),
                new Client("Boba", "Fett"),
                new Client("Han", "Solo"),
                new Client("Steve", "Ballmer"),
                new Client("Peter", "Dinklage"),
                new Client("Sean", "Bean"),
                new Client("Piers", "Brosnan"),
                new Client("Tom", "Hardy"),
                new Client("Carli", "Lloyd"),
                new Client("Serena", "Williams"),
                new Client("Roy", "Hibbert")
            };
            return clients;
        }

        private List<Message> GetMessages()
        {
            List<Message> messages = new List<Message>()
            {
                new Message("hi", 1, 1),
                new Message("hi2", 1, 2),
                new Message("hi3", 1, 3),
                new Message("hi4", 1, 4)
            };
            return messages;
        } 

        private List<Ticket> GetTickets()
        {
            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket("Is this thing on?", 1),
                new Ticket("Why is my name so generic?", 2),
                new Ticket("What's the budget for AGS?", 3),
                new Ticket("Where is Naboo?", 4),
                new Ticket("How can I kill Han Solo?", 5),
                new Ticket("How can I make the Kessel Run faster?", 6),
                new Ticket("Why did I lose Microsoft so much money?", 7),
                new Ticket("Why is my voice acting in Destiny so bad?", 8),
                new Ticket("Is it necessary for me to die in every movie?", 9),
                new Ticket("Am I the best James Bond?", 10)
            };
            return tickets;
        }

        private List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User("Bob", "Jenkis", UserType.Admin),
                new User("Arnold", "Schwarzenegger", UserType.Admin),
                new User("Ronda", "Rousey", UserType.Admin),
                new User("Darron", "Su", UserType.Representative),
                new User("Marc", "Ohlhausen", UserType.Representative),
                new User("Lebron", "James", UserType.Representative),
                new User("Audrey", "Hepburn", UserType.Representative),
                new User("Hope", "Solo", UserType.Representative),
                new User("David", "Blatt", UserType.Representative),
                new User("Bill", "Gates", UserType.Admin), 
                new User("Darth", "Vader", UserType.Admin),
                new User("Luke", "Skywalker", UserType.Representative),
                new User("Gandalf", "Grey", UserType.Admin),
                new User("Patrick", "Jane", UserType.Representative)
            };
            return users;
        } 
    }
}
