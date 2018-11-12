using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;

namespace EnterpriseMessagingGateway.Services.Interfaces
{
    public interface IAgreementService
    {
        AgreementDto GetAgreementById(int id);

        IEnumerable<AgreementDto> GetAgreementList();
        AgreementDetailDto GetAgreementDetailById(int id);
        AgreementDetailDto AddAgreement(AgreementDetailDto entity);
        void UpdateAgreement(AgreementDetailDto entity);
        void DeleteAgreement(int id);

    }
}
