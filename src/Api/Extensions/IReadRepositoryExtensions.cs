using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using EnterpriseMessagingGateway.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseMessagingGateway.Api.Extensions
{
    public static class IReadRepositoryExtensions
    {
        public static PagedList<Task> ToPagedList(this IReadRepository<Task> repo, TaskResourceParameters parameters)
        {
            parameters = parameters ?? new TaskResourceParameters();
            var tasks = repo.List().OrderBy(t => t.Name).AsQueryable();

            if (!string.IsNullOrEmpty(parameters.Name))
            {
                tasks = tasks.Where(t => t.Name.ToLower() == parameters.Name.ToLower());
            }

            if (!string.IsNullOrEmpty(parameters.SearchQuery))
            {
                var searchQuery = parameters.SearchQuery.ToLower();
                tasks = tasks.Where(t => t.Name.ToLower().Contains(searchQuery)
                                         || t.Description.ToLower().Contains(searchQuery));
            }

            return PagedList<Task>.Create(tasks, parameters.PageNumber, parameters.PageSize);
        }
    }
}