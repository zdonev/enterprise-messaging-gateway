using System;
using System.Linq;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;

namespace EnterpriseMessagingGateway.Infrastructure.Repositories
{
    public class TaskReadRepository : IReadRepository<Task>
    {
        private readonly ApplicationDbContext _context;

        public TaskReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Task> List()
        {
           return _context.Tasks.AsQueryable();
        }
    }
}
