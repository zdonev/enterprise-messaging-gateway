using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EnterpriseMessagingGateway.Core.Interfaces;
using EnterpriseMessagingGateway.Core.Entities;
using System.Data.Entity;

namespace EnterpriseMessagingGateway.Infrastructure.Repositories
{
    public class AgreementRepository : IAgreementRepository
    {
        private readonly ApplicationDbContext _context;
        public AgreementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Agreement Add(Agreement entity)
        {

            _context.Agreements.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Agreement entity)
        {
            _context.Agreements.Remove(entity);
            _context.SaveChanges();
            
        }

        public Agreement GetById(int id)
        { 
            return _context.Agreements
                    .Include(a => a.PropertyList)
                    .Include(a => a.ResolverList)
                    .Where(a => a.Id == id)
                    .SingleOrDefault();
        }

        public IEnumerable<Agreement> List()
        {
            return _context.Agreements.AsEnumerable();
        }

        public IEnumerable<Agreement> List(Expression<Func<Agreement, bool>> filter = null, Func<IQueryable<Agreement>, IOrderedQueryable<Agreement>> orderBy = null, string includeProperties = null, int? skip = default(int?), int? take = default(int?))
        {
            return _context.Agreements.Where(filter).AsEnumerable();
        }

        public IEnumerable<Agreement> ResolveAgreement(string test)
        {
            throw new NotImplementedException();
        }

        public void Update(Agreement entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
