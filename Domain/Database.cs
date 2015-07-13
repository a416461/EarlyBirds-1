using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class Database
    {
        private static readonly SqlDatabase db = new SqlDatabase(ConfigurationManager.ConnectionStrings["EarlyBirds"].ConnectionString);
        
        public static List<User> Users
        {
            get
            {
                DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Users");
                return db.ExecuteDataSet(cmd).Tables[0].AsEnumerable().Select(i =>
                {
                    UserType? uType = i["UserType"] == DBNull.Value ? (UserType?)null : (UserType)i["UserType"];
                    return new User();
                }).ToList();
            }
        }
        
        public static List<Client> Clients
        {
            get
            {
                DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Clients");
                return db.ExecuteDataSet(cmd).Tables[0].AsEnumerable().Select(i =>
                {
                    return new Client();
                }).ToList();
            }
        }

        public static List<Channel> Channels
        {
            get
            {
                DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Channels");
                return db.ExecuteDataSet(cmd).Tables[0].AsEnumerable().Select(i =>
                {
                    return new Channel();
                }).ToList();
            }
        }

        public static List<Ticket> Tickets
        {
            get
            {
                DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Tickets");
                return db.ExecuteDataSet(cmd).Tables[0].AsEnumerable().Select(i =>
                {
                    return new Ticket();
                }).ToList();
            }
        }

        public static List<ChatLog> Chats
        {
            get
            {
                DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM ChatLogs");
                return db.ExecuteDataSet(cmd).Tables[0].AsEnumerable().Select(i =>
                {
                    return new ChatLog();
                }).ToList();
            }
        }

        public static List<Message> Messages
        {
            get
            {
                DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Messages");
                return db.ExecuteDataSet(cmd).Tables[0].AsEnumerable().Select(i =>
                {
                    return new Message();
                }).ToList();
            }
        }

        public static List<ChannelUser> ChannelUsers
        {
            get
            {
                DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM ChannelUsers");
                return db.ExecuteDataSet(cmd).Tables[0].AsEnumerable().Select(i =>
                {
                    return new ChannelUser
                    {
                        ChannelId = (int)i["ChannelId"],
                        UserId = (int)i["UserId"]

                    };
                }).ToList();
            }
        }

        public static List<ChannelTicket> ChannelTickets
        {
            get
            {
                DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM ChannelTickets");
                return db.ExecuteDataSet(cmd).Tables[0].AsEnumerable().Select(i =>
                {
                    return new ChannelTicket
                    {
                        ChannelId = (int)i["ChannelId"],
                        TicketId = (int)i["TicketId"]
                    };
                }).ToList();
            }
        }

        public static List<UserChat> UserChats = new List<UserChat>() { };

        public static void DatabaseInsertMessage(string text, int userId, int chatId)
        {
            DbCommand cmd = db.GetStoredProcCommand("dbo.MessageProcedure");
            db.AddInParameter(cmd, "@Text", DbType.String, text);
            db.AddInParameter(cmd, "@UserId", DbType.Int32, userId);
            db.AddInParameter(cmd, "@ChatId", DbType.Int32, chatId);
            db.ExecuteNonQuery(cmd);
        }

        public static void DatabaseUpdateTicketResponse(string text, int id)
        {
            DbCommand cmd = db.GetSqlStringCommand("UPDATE Tickets SET Response='"+ text +"' WHERE Id=" + id);
            db.ExecuteNonQuery(cmd);
        }

        public static void DatabaseDeleteTicket(int id)
        {
            DbCommand cmd = db.GetSqlStringCommand("DELETE FROM ChannelTickets WHERE TicketId=" + id);
            db.ExecuteNonQuery(cmd);
            cmd = db.GetSqlStringCommand("DELETE FROM Tickets WHERE Id=" + id);
            db.ExecuteNonQuery(cmd);
        }
    }

    public class ChannelUser
    {
        public int ChannelId { get; set; }
        public int UserId { get; set; }

        public Channel Channel
        {
            get
            {
                return Database.Channels.First(i => i.Id == this.ChannelId);
            }
        }

        public User User
        {
            get
            {
                return Database.Users.First(i => i.Id == this.UserId);
            }
        }
    }

    public class ChannelTicket
    {
        public int ChannelId { get; set; }
        public int TicketId { get; set; }

        public Channel Channel
        {
            get
            {
                return Database.Channels.First(channel => channel.Id == this.ChannelId);
            }
        }

        public Ticket Ticket
        {
            get
            {
                return Database.Tickets.First(ticket => ticket.Id == this.TicketId);
            }
        }
    }

    public class UserChat
    {
        public int UserId { get; set; }
        public int ChatId { get; set; }

        public User User
        {
            get
            {
                return Database.Users.First(user => user.Id == this.UserId);
            }
        }

        public ChatLog ChatLog
        {
            get
            {
                return Database.Chats.First(chatlog => chatlog.Id == this.ChatId);
            }
        }
    }
}
