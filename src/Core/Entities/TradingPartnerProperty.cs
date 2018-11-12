using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    public class TradingPartnerProperty : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual TradingPartner TradingPartner { get; set; }
    }
}
