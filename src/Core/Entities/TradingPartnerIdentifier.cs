using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    public class TradingPartnerIdentifier : BaseEntity
    {
        public string Qualifier { get; set; }
        public string Identifier { get; set; }

        public virtual TradingPartner TradingPartner { get; set; }
    }
}
