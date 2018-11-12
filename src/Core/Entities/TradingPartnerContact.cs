using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    public class TradingPartnerContact : BaseEntity
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string  Country { get; set; }

        public virtual ICollection<TradingPartnerContactProperty> Properties { get; set; } = new List<TradingPartnerContactProperty>();
        public virtual TradingPartner TradingPartner { get; set; }

    }
}
