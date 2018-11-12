using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using System.Data.Entity;

namespace EnterpriseMessagingGateway.Infrastructure.Repositories
{
    public class TaskRepository : IRepository<Task>
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Add(Task entity)
        {
            _context.Tasks.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Task entity)
        {
            _context.Tasks.Remove(entity);
            _context.SaveChanges();
        }

        public Task GetById(int id)
        {
            return _context.Tasks
                    .Include(t => t.TaskParameters)
                    .Where(a => a.Id == id)
                    .SingleOrDefault();
        }

        public IEnumerable<Task> List()
        {
            return _context.Tasks.ToList();
                    //.Include(t => t.TaskParameters)
        }

        public IEnumerable<Task> List(Expression<Func<Task, bool>> filter = null, Func<IQueryable<Task>, IOrderedQueryable<Task>> orderBy = null, string includeProperties = null, int? skip = default(int?), int? take = default(int?))
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<Task> query = _context.Set<Task>();

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

        public void Update(Task entity)
        {
            var task = GetById(entity.Id);

            if (task != null)
            {
                // Update parent
                _context.Entry(task).CurrentValues.SetValues(entity);

                // Delete children
                foreach (var taskParameter in task.TaskParameters.ToList())
                {
                    if (!entity.TaskParameters.Any(c => c.Id == taskParameter.Id))
                        _context.TaskParameters.Remove(taskParameter);
                }

                // Update and Insert children
                foreach (var entityParameters in entity.TaskParameters)
                {
                    var existingChild = task.TaskParameters
                        .Where(c => c.Id == entityParameters.Id)
                        .SingleOrDefault();

                    if (existingChild != null && existingChild.Id != 0)
                        // Update child
                        _context.Entry(existingChild).CurrentValues.SetValues(entityParameters);
                    else
                    {
                        // Insert child
                        var newParameter = new TaskParameter
                        {
                            Description = entityParameters.Description,
                            Key = entityParameters.Key,
                            Required = entityParameters.Required,
                            Type = entityParameters.Type
                        };
                        task.TaskParameters.Add(newParameter);
                    }
                }

                _context.SaveChanges();
            }

        }
    }
}
