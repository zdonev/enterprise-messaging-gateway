using System.Linq;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Interfaces
{
    public interface IReadRepository<T> where T : BaseEntity
    {
        IQueryable<T> List();
    }
}
