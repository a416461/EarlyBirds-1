using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class Ticket
    {
        public int Id;
        public int ClientId { get; set; }
        public bool IsResolved { get; set; }
        public string Question { get; set; }
        public string Response { get; set; }
    }
}
