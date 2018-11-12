using EnterpriseMessagingGateway.Core.Entities;

namespace EnterpriseMessagingGateway.Core.Interfaces
{
    public interface ITradingPartnerRepository : IRepository<TradingPartner>
    {        
        void AddContact(int tpId, TradingPartnerContact entity);
    }
}
