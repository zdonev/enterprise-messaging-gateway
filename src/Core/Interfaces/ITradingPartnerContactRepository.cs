using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Core.Entities;

namespace EnterpriseMessagingGateway.Core.Interfaces
{
    public interface ITradingPartnerContactRepository : IRepository<TradingPartnerContact>
    {        
        void AddProperty(int contactId, TradingPartnerContactProperty entity);
    }
}
