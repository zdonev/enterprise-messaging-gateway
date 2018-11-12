using System.Collections.Generic;
using EnterpriseMessagingGateway.Core.Entities;

namespace EnterpriseMessagingGateway.Core.Interfaces
{
    public interface IAgreementRepository : IRepository<Agreement>
    {        
        IEnumerable<Agreement> ResolveAgreement(string test);
    }
}
