using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;

namespace EnterpriseMessagingGateway.Services.Interfaces
{
    public interface ITradingPartnerService
    {
        TradingPartnerDetailDto GetTradingPartnerById(int id);
        TradingPartnerDetailDto AddTradingPartner(TradingPartnerDetailCreateDto dto);
        TradingPartnerDetailDto UpdateTradingPartner(TradingPartnerDetailDto dto);
        void DeleteTradingPartner(int id);
    }
}
