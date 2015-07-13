using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class UserConverter
    {
        public static Dto.User ToDto(Dmn.User domain)
        {
            return new Dto.User()
            {
                FirstName = domain.FirstName,
                Id = domain.Id,
                LastName = domain.LastName,
                UserType = domain.UserT,
                Messages = domain.Messages.ToList().Select(message => MessageConverter.ToDto(message)).ToList(),
                ChannelIds = domain.Channels.ToList().Select(i => i.Id).ToList(),
                ChatIds = domain.Chats.Select(i => i.Id).ToList()
            };
        }
    }
}
