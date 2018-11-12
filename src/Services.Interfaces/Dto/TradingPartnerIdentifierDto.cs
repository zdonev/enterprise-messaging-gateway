using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMessagingGateway.Services.Interfaces.Dto
{
    public class TradingPartnerIdentifierDto
    {
        public int Id { get; set; }
        public string Qualifier { get; set; }
        public string Identifier { get; set; }
    }
}
