using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using System.Data.Entity;

namespace EnterpriseMessagingGateway.Infrastructure.Repositories
{
    public class TradingPartnerRepository : IRepository<TradingPartner>
    {
        private readonly ApplicationDbContext _context;

        public TradingPartnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public TradingPartner Add(TradingPartner entity)
        {
            _context.TradingPartners.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(TradingPartner entity)
        {
            _context.TradingPartners.Remove(entity);
            _context.SaveChanges();
        }

        public TradingPartner GetById(int id)
        {
            return _context.TradingPartners
                    .Include(testc => testc.Identifiers)
                    .Include(t => t.Contacts.Select(p => p.Properties))
                    .Include(t => t.Properties)
                    .Where(a => a.Id == id)
                    .SingleOrDefault();
        }

        public IEnumerable<TradingPartner> List()
        {
            return _context.TradingPartners.ToList();
        }

        public IEnumerable<TradingPartner> List(Expression<Func<TradingPartner, bool>> filter = null, Func<IQueryable<TradingPartner>, IOrderedQueryable<TradingPartner>> orderBy = null, string includeProperties = null, int? skip = default(int?), int? take = default(int?))
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TradingPartner> query = _context.Set<TradingPartner>();

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

        public void Update(TradingPartner entity)
        {
            var tp = GetById(entity.Id);

            if (tp != null)
            {
                // Update parent
                _context.Entry(tp).CurrentValues.SetValues(entity);

                // Delete children 
                foreach (var tpProperty in tp.Properties.ToList())
                {
                    if (!entity.Properties.Any(c => c.Id == tpProperty.Id))
                        _context.TradingPartnerProperties.Remove(tpProperty);
                }

                foreach (var tpIdentifier in tp.Identifiers.ToList())
                {
                    if (!entity.Identifiers.Any(c => c.Id == tpIdentifier.Id))
                        _context.TradingPartnerIdentifiers.Remove(tpIdentifier);
                }

                foreach (var tpContact in tp.Contacts.ToList())
                {
                    if (!entity.Contacts.Any(c => c.Id == tpContact.Id))
                        _context.Contacts.Remove(tpContact);
                }

                // Update and Insert Properties
                foreach (var entityPropery in entity.Properties)
                {
                    var existingChild = tp.Properties
                        .Where(c => c.Id == entityPropery.Id)
                        .SingleOrDefault();

                    if (existingChild != null)
                        // Update child
                        _context.Entry(existingChild).CurrentValues.SetValues(entityPropery);
                    else
                    {
                        // Insert child
                        var newProperty = new TradingPartnerProperty
                        {
                            Name = entityPropery.Name,
                            Value = entityPropery.Value
                        };
                        tp.Properties.Add(newProperty);
                    }
                }

                // Update and Insert Identifiers
                foreach (var entityIdentifier in entity.Identifiers)
                {
                    var existingChild = tp.Identifiers
                        .Where(c => c.Id == entityIdentifier.Id)
                        .SingleOrDefault();

                    if (existingChild != null)
                        // Update child
                        _context.Entry(existingChild).CurrentValues.SetValues(entityIdentifier);
                    else
                    {
                        // Insert child
                        var newIdentifier = new TradingPartnerIdentifier
                        {
                            Identifier = entityIdentifier.Identifier,
                            Qualifier = entityIdentifier.Qualifier
                        };
                        tp.Identifiers.Add(newIdentifier);
                    }
                }

                // Update and Insert Contacts
                foreach (var entityContact in entity.Contacts)
                {
                    var existingChild = tp.Contacts
                        .Where(c => c.Id == entityContact.Id)
                        .SingleOrDefault();

                    if (existingChild != null && existingChild.Id != 0)
                    {
                        // Update child
                        _context.Entry(existingChild).CurrentValues.SetValues(entityContact);
                        //existingChild.Properties.ToList().ForEach(p => _context.ContactProperties.Remove(p));

                        foreach (var property in entityContact.Properties)
                        {
                            var newProperty = new TradingPartnerContactProperty
                            {
                                Name = property.Name,
                                Value = property.Value
                            };
                            existingChild.Properties.Add(newProperty);
                        }

                    }                        
                    else
                    {
                        // Insert child
                        var newContact = new TradingPartnerContact
                        {
                            City = entityContact.City,
                            Country = entityContact.Country,
                            Email = entityContact.Email,
                            Name = entityContact.Name,
                            Phone = entityContact.Phone,
                            PostalCode = entityContact.PostalCode,
                            Role = entityContact.Role,
                            State = entityContact.State,
                            Street = entityContact.Street
                        };

                        foreach (var property in entityContact.Properties)
                        {
                            var newProperty = new TradingPartnerContactProperty
                            {
                                Name = property.Name,
                                Value = property.Value
                            };
                            newContact.Properties.Add(newProperty);
                        }                       

                        tp.Contacts.Add(newContact);

                        
                    }
                }

                _context.SaveChanges();
            }
        }
    }
}
