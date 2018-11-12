using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    public class TradingPartnerContactProperty : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual TradingPartnerContact Contact { get; set; }
    }
}
