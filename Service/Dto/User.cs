using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Dto
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public UserType? UserType { get; set; }
        public DateTime DateJoined { get; set; }
        public List<Dto.Message> Messages { get; set; }
        public List<int> ChannelIds { get; set; }
        public List<int> ChatIds { get; set; }
    }
}
