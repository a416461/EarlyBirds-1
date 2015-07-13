using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class TicketConverter
    {
        public static Dto.Ticket ToDto(Dmn.Ticket domain)
        {
            return new Dto.Ticket()
            {
                Id = domain.Id,
                ClientId = domain.ClientId,
                IsResolved = domain.IsResolved,
                Question = domain.Question,
                Response = domain.Response
            };
        }
    }
}
