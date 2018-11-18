using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using System.Data.Entity;

namespace EnterpriseMessagingGateway.Infrastructure.Repositories
{
    public class TradingPartnerContactRepository : IRepository<TradingPartnerContact>
    {
        private readonly ApplicationDbContext _context;

        public TradingPartnerContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TradingPartnerContact Add(TradingPartnerContact entity)
        {
            _context.Contacts.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void AddProperty(int contactId, TradingPartnerContactProperty entity)
        {
            var contact = _context.Contacts
                   .Where(a => a.Id == contactId)
                   .SingleOrDefault();
            contact.Properties.Add(entity);            
            _context.SaveChanges();
        }

        public void Delete(TradingPartnerContact entity)
        {
            _context.Contacts.Remove(entity);
            _context.SaveChanges();
        }

        public TradingPartnerContact GetById(int id)
        {
            return _context.Contacts
                    .Include(t => t.Properties)
                    .Where(a => a.Id == id)
                    .SingleOrDefault();
        }

        public IEnumerable<TradingPartnerContact> List()
        {
            return _context.Contacts.ToList();
                    //.Include(t => t.TaskParameters)
        }

        public IEnumerable<TradingPartnerContact> List(Expression<Func<TradingPartnerContact, bool>> filter = null, Func<IQueryable<TradingPartnerContact>, IOrderedQueryable<TradingPartnerContact>> orderBy = null, string includeProperties = null, int? skip = default(int?), int? take = default(int?))
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TradingPartnerContact> query = _context.Set<TradingPartnerContact>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.AsEnumerable();
        }

        public void Update(TradingPartnerContact entity)
        {
            var dbEntity = _context.Contacts.Where(c => c.Id == entity.Id).SingleOrDefault();

            _context.Entry(dbEntity).CurrentValues.SetValues(entity);
            //_dbContext.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
