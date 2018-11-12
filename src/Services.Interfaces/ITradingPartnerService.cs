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
        IEnumerable<TradingPartnerDetailDto> GetTradingPartnerList(string search = null, string sortOrder = null, int? skip = null, int? take = null);
        TradingPartnerDetailDto AddTask(TradingPartnerDetailDto dto);
        void UpdateTask(TradingPartnerDetailDto dto);
        void DeleteTask(int id);
    }
}
