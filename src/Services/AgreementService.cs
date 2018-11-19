using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using EnterpriseMessagingGateway.Services.Interfaces;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;

namespace EnterpriseMessagingGateway.Services
{
    public class AgreementService : IAgreementService //, IAgreementPropertyService
    {
        private readonly IRepository<Agreement> _agreementRepository;

        public AgreementService(IRepository<Agreement> agreementRepository)
        {
            _agreementRepository = agreementRepository;
        }


        //public AgreementPropertyDTO Add(AgreementPropertyDTO property)
        //{
        //    var entity = property.ToEntity();
        //    throw new NotImplementedException();
        //}

        

        public ICollection<AgreementPropertyDto> GetAll(int agreementId)
        {
            throw new NotImplementedException();

        }

        public IEnumerable<Agreement> List(Expression<Func<Agreement, bool>> predicate)
        {
            return _agreementRepository.List(predicate);
        }

        public AgreementPropertyDto Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agreement> ResolveAgreement()
        {
            //return _agreementRepository.List(a => a.DocumentType == "" &&
            //                                        a.Sender.TradingPartnerIDs.;
            return new List<Agreement>();
        }


        public AgreementDto GetAgreementById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AgreementDto> GetAgreementList()
        {
            throw new NotImplementedException();
        }

        public AgreementDetailDto GetAgreementDetailById(int id)
        {
            throw new NotImplementedException();
        }

        public AgreementDetailDto AddAgreement(AgreementDetailDto entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateAgreement(AgreementDetailDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAgreement(int id)
        {
            throw new NotImplementedException();
        }
    }
}
