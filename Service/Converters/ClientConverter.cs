using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class ClientConverter
    {
        public static Dto.Client ToDto(Dmn.Client domain)
        {
            return new Dto.Client()
            {
                FirstName = domain.FirstName,
                LastName = domain.LastName,
                Id = domain.Id,
                Tickets = domain.Tickets.ToList().Select(ticket => TicketConverter.ToDto(ticket)).ToList()
            };
        }
    }
}
