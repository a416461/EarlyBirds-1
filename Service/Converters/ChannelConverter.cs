using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class ChannelConverter
    {
        public static Dto.Channel ToDto(Dmn.Channel domain)
        {
            return new Dto.Channel()
            {
                Name = domain.Name,
                Category = domain.Category,
                Id = domain.Id,
                AdminId = domain.AdminId,
                Users = domain.Users.ToList().Select(user => UserConverter.ToDto(user)).ToList(),
                Tickets = domain.Tickets.ToList().Select(ticket => TicketConverter.ToDto(ticket)).ToList(),
                ChatLog = ChatLogConverter.ToDto(domain.Chat)
            };
        }
    }
}
