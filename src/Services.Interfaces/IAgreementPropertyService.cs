using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;

namespace EnterpriseMessagingGateway.Services.Interfaces
{
    public interface IAgreementPropertyService
    {
        AgreementPropertyDto Get(int id);
        ICollection<AgreementPropertyDto> GetAll(int agreementId);
        AgreementPropertyDto Add(AgreementPropertyDto property);
        AgreementPropertyDto Remove(int id);
        AgreementPropertyDto Update(AgreementPropertyDto property);

    }
}
