using EnterpriseMessagingGateway.Core.Entities;

namespace EnterpriseMessagingGateway.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Agreement> Agreements {get;}
        void Complete();
    }
}
