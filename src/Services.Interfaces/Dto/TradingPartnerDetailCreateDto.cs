using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMessagingGateway.Services.Interfaces.Dto
{
    public class TradingPartnerDetailCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<TradingPartnerIdentifierCreateDto> Identifiers { get; set; } = new List<TradingPartnerIdentifierCreateDto>();
        public virtual ICollection<TradingPartnerPropertyCreateDto> Properties { get; set; } = new List<TradingPartnerPropertyCreateDto>();
        public virtual ICollection<TradingPartnerContactDetailCreateDto> Contacts { get; set; } = new List<TradingPartnerContactDetailCreateDto>();
    }
}
