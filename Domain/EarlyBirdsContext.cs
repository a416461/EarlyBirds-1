using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EarlyBirdsContext : DbContext
    {
        public EarlyBirdsContext() : base("EarlyBirds") { }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<ChatLog> ChatLogs { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{ }

    }
}
