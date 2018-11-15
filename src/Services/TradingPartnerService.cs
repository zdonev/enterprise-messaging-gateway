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
        private readonly ITradingPartnerRepository _tpRepository;

        public TradingPartnerService(ITradingPartnerRepository tpRepository)
        {
            _tpRepository = tpRepository;
        }


        public TradingPartnerDetailDto AddTradingPartner(TradingPartnerDetailCreateDto dto)
        {
            var entity = AutoMapper.Mapper.Map<TradingPartner>(dto);

            var newEntity = _tpRepository.Add(entity);

            return AutoMapper.Mapper.Map<TradingPartnerDetailDto>(newEntity);
        }


        public void DeleteTradingPartner(int id)
        {
            var entity = _tpRepository.GetById(id);
            _tpRepository.Delete(entity);
        }

        public TradingPartnerDetailDto GetTradingPartnerById(int id)
        {
            var entity = _tpRepository.GetById(id);
            return AutoMapper.Mapper.Map<TradingPartnerDetailDto>(entity);
        }


        public TradingPartnerDetailDto UpdateTradingPartner(TradingPartnerDetailDto dto)
        {
            var entity = AutoMapper.Mapper.Map<TradingPartner>(dto);
            _tpRepository.Update(entity);

            var updatedEntity = _tpRepository.GetById(entity.Id);

            return AutoMapper.Mapper.Map<TradingPartnerDetailDto>(updatedEntity);
        }
    }
}
