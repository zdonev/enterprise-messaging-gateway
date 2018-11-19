using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Interfaces
{
    public interface IReadRepository<T> where T : BaseEntity
    {
        IQueryable<T> List();

        IEnumerable<T> List(Expression<Func<T, bool>> filter = null,
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                            string includeProperties = null,
                            int? skip = null,
                            int? take = null);
    }
}
