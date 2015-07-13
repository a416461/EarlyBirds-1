using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class Channel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Id { get; set; }
        public int AdminId { get; set; }
        public List<Dto.User> Users { get; set; }
        public List<Dto.Ticket> Tickets { get; set; }
        public Dto.ChatLog ChatLog { get; set; }
    }
}
