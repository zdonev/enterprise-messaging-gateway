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
        private readonly IRepository<TradingPartnerProperty> _propertyRepository;
        private readonly IRepository<TradingPartnerContact> _contactRepository;
        private readonly IRepository<TradingPartnerContactProperty> _contactPropRepository;

        public TradingPartnerService(IRepository<TradingPartner> tpRepository,
                                        IRepository<TradingPartnerProperty> propertyRepository,
                                        IRepository<TradingPartnerContact> contactRepository,
                                        IRepository<TradingPartnerContactProperty> contactPropRepository)
        {
            _tpRepository = tpRepository;
            _propertyRepository = propertyRepository;
            _contactRepository = contactRepository;
            _contactPropRepository = contactPropRepository;
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


        public TradingPartnerContactDetailDto AddContact(int tpid, TradingPartnerContactDetailCreateDto dto)
        {
            var entity = AutoMapper.Mapper.Map<TradingPartnerContact>(dto);

            var tp = _tpRepository.GetById(tpid);
            entity.TradingPartner = tp;
            _contactRepository.Add(entity);

            return AutoMapper.Mapper.Map<TradingPartnerContactDetailDto>(entity);
        }

        public TradingPartnerContactDetailDto GetContact(int tpid, int id)
        {
            var entity = _contactRepository.GetById(id);
            return AutoMapper.Mapper.Map<TradingPartnerContactDetailDto>(entity);
        }

        public TradingPartnerContactDto UpdateContact(int tpid, TradingPartnerContactDto dto)
        {
             var entity = AutoMapper.Mapper.Map<TradingPartnerContact>(dto);

            _contactRepository.Update(entity);

            var updatedEntity = _contactRepository.GetById(entity.Id);

            return AutoMapper.Mapper.Map<TradingPartnerContactDto>(updatedEntity);
        }

        public void DeleteContact(int tpid, int id)
        {
            var entity = _contactRepository.GetById(id);
            _contactRepository.Delete(entity);
        }

        public TradingPartnerContactPropertyDto AddContactProperty(int tpid, int contactid, TradingPartnerContactPropertyCreateDto dto)
        {
            var entity = AutoMapper.Mapper.Map<TradingPartnerContactProperty>(dto);

            var contact = _contactRepository.GetById(tpid);
            entity.Contact = contact;
            _contactPropRepository.Add(entity);

            return AutoMapper.Mapper.Map<TradingPartnerContactPropertyDto>(entity);
        }

        public TradingPartnerContactPropertyDto GetContactProperty(int tpid, int contactid, int id)
        {
            var entity = _contactPropRepository.GetById(id);
            return AutoMapper.Mapper.Map<TradingPartnerContactPropertyDto>(entity);
        }

        public TradingPartnerContactPropertyDto UpdateContactProperty(int tpid, int contactid, TradingPartnerContactPropertyDto dto)
        {
            var entity = AutoMapper.Mapper.Map<TradingPartnerContactProperty>(dto);

            _contactPropRepository.Update(entity);

            return AutoMapper.Mapper.Map<TradingPartnerContactPropertyDto>(entity);
        }

        public void DeleteContactProperty(int tpid, int contactid, int id)
        {
            var entity = _contactPropRepository.GetById(id);
            _contactPropRepository.Delete(entity);
        }

        public TradingPartnerPropertyDto AddProperty(int tpid, TradingPartnerPropertyCreateDto dto)
        {
            var entity = AutoMapper.Mapper.Map<TradingPartnerProperty>(dto);

            var tradingPartner = _tpRepository.GetById(tpid);
            entity.TradingPartner = tradingPartner;
            _propertyRepository.Add(entity);

            return AutoMapper.Mapper.Map<TradingPartnerPropertyDto>(entity);
        }

        public TradingPartnerPropertyDto GetProperty(int tpid, int id)
        {
            var entity = _propertyRepository.GetById(id);
            return AutoMapper.Mapper.Map<TradingPartnerPropertyDto>(entity);
        }

        public TradingPartnerPropertyDto UpdateProperty(int tpid, TradingPartnerPropertyDto dto)
        {
            var entity = AutoMapper.Mapper.Map<TradingPartnerProperty>(dto);

            _propertyRepository.Update(entity);

            return AutoMapper.Mapper.Map<TradingPartnerPropertyDto>(entity);
        }

        public void DeleteProperty(int tpid, int id)
        {
            var entity = _propertyRepository.GetById(id);
            _propertyRepository.Delete(entity);
        }
    }
}
