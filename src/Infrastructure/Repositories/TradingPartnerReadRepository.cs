using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using System.Data.Entity;

namespace EnterpriseMessagingGateway.Infrastructure.Repositories
{
    public class TradingPartnerReadRepository : IReadRepository<TradingPartner>
    {
        private readonly ApplicationDbContext _context;

        public TradingPartnerReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<TradingPartner> List()
        {
            return _context.TradingPartners
                    .Include(testc => testc.Identifiers)
                    .Include(t => t.Contacts.Select(p => p.Properties))
                    .Include(t => t.Properties).AsQueryable();
        }
    }
}
