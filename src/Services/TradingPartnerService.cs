using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using EnterpriseMessagingGateway.Services.Interfaces;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;

namespace EnterpriseMessagingGateway.Services
{
    public class TradingPartnerService : ITradingPartnerService
    {
        private readonly IRepository<TradingPartner> _tpRepository;

        public TradingPartnerService(IRepository<TradingPartner> tpRepository)
        {
            _tpRepository = tpRepository;
        }

        public TradingPartnerDetailDto AddTask(TradingPartnerDetailDto dto)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public TradingPartnerDetailDto GetTradingPartnerById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TradingPartnerDetailDto> GetTradingPartnerList(string search = null, string sortOrder = null, int? skip = default(int?), int? take = default(int?))
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(TradingPartnerDetailDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
