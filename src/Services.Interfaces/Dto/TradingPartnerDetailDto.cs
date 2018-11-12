using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMessagingGateway.Services.Interfaces.Dto
{
    public class TradingPartnerDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<TradingPartnerIdentifierDto> Identifiers { get; set; } = new List<TradingPartnerIdentifierDto>();
        public virtual ICollection<TradingPartnerPropertyDto> Properties { get; set; } = new List<TradingPartnerPropertyDto>();
        public virtual ICollection<TradingPartnerContactDetailDto> Contacts { get; set; } = new List<TradingPartnerContactDetailDto>();
    }
}
