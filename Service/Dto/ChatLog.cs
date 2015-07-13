using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class ChatLog
    {
        public int Id { get; set; }
        public int? ChannelId { get; set; }
        public DateTime TimeCreated { get; set; }
        public List<Dto.Message> Messages { get; set; }
        public List<Dto.User> Users { get; set; }
    }
}
