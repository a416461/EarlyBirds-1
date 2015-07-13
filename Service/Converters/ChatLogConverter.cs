using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class ChatLogConverter
    {
        public static Dto.ChatLog ToDto(Dmn.ChatLog domain)
        {
            return new Dto.ChatLog()
            {
                Id = domain.Id,
                ChannelId = domain.ChannelId,
                TimeCreated = domain.TimeCreated,
                Users = domain.Users.ToList().Select(user => UserConverter.ToDto(user)).ToList(),
                Messages = domain.Messages.ToList().Select(message => MessageConverter.ToDto(message)).ToList()
            };
        }
    }
}
