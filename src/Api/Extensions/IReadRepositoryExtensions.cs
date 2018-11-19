using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using EnterpriseMessagingGateway.Services.Helpers;
using EnterpriseMessagingGateway.Services.Interfaces;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;
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

        public static PagedList<TradingPartner> ToPagedList(this IReadRepository<TradingPartner> repo, TradingPartnerResourceParameters parameters, IPropertyMappingService propertyMappingService)
        {
            parameters = parameters ?? new TradingPartnerResourceParameters();

            if (!propertyMappingService.ValidMappingExistsFor<TradingPartnerDetailDto, TradingPartner>(parameters.OrderBy))
            {
                throw new Exception("Invalid OrderBy!");
                //return BadRequest("Invalid OrderBy!!!");
                //TODO => throw exception and return Bad Request to client
            }

            var tp = repo.List()
                         .ApplySort(parameters.OrderBy, propertyMappingService.GetPropertyMapping<TradingPartnerDetailDto, TradingPartner>());

            if (!string.IsNullOrEmpty(parameters.Name))
            {
                tp = tp.Where(t => t.Name.ToLower() == parameters.Name.ToLower());
            }

            if (!string.IsNullOrEmpty(parameters.Description))
            {
                tp = tp.Where(t => t.Description.ToLower() == parameters.Description.ToLower());
            }

            if (!string.IsNullOrEmpty(parameters.Qualifier))
            {
                tp = tp.Where(t => t.Identifiers.Any(i => i.Qualifier == parameters.Qualifier.ToLower()));
            }

            if (!string.IsNullOrEmpty(parameters.Identifier))
            {
                tp = tp.Where(t => t.Identifiers.Any(i => i.Identifier == parameters.Identifier.ToLower()));
            }

            if (!string.IsNullOrEmpty(parameters.PropertyName))
            {
                tp = tp.Where(t => t.Properties.Any(i => i.Name == parameters.PropertyName.ToLower()));
            }

            if (!string.IsNullOrEmpty(parameters.PropertyValue))
            {
                tp = tp.Where(t => t.Properties.Any(i => i.Value == parameters.PropertyValue.ToLower()));
            }

            if (!string.IsNullOrEmpty(parameters.SearchQuery))
            {
                var searchQuery = parameters.SearchQuery.ToLower();
                tp = tp.Where(t => t.Name.ToLower().Contains(searchQuery)
                              || t.Description.ToLower().Contains(searchQuery)
                              || t.Identifiers.Any(i => i.Qualifier.Contains(searchQuery))
                              || t.Identifiers.Any(i => i.Identifier.Contains(searchQuery))
                              || t.Properties.Any(i => i.Name.Contains(searchQuery))
                              || t.Properties.Any(i => i.Value.Contains(searchQuery))
                              );
            }

            return PagedList<TradingPartner>.Create(tp, parameters.PageNumber, parameters.PageSize);
        }


        public static PagedList<DocumentTypeResolver> ToPagedList(this IReadRepository<DocumentTypeResolver> repo, ResolverResourceParameters parameters, IPropertyMappingService propertyMappingService)
        {
            parameters = parameters ?? new ResolverResourceParameters();

            if (!propertyMappingService.ValidMappingExistsFor<DocumentTypeResolverDto, DocumentTypeResolver>(parameters.OrderBy))
            {
                throw new Exception("Invalid OrderBy!");
                //return BadRequest("Invalid OrderBy!!!");
                //TODO => throw exception and return Bad Request to client
            }

            var tp = repo.List()
                         .ApplySort(parameters.OrderBy, propertyMappingService.GetPropertyMapping<DocumentTypeResolverDto, DocumentTypeResolver>());

            if (!string.IsNullOrEmpty(parameters.Name))
            {
                tp = tp.Where(t => t.Name.ToLower() == parameters.Name.ToLower());
            }

            if (!string.IsNullOrEmpty(parameters.Description))
            {
                tp = tp.Where(t => t.Description.ToLower() == parameters.Description.ToLower());
            }

            if (!string.IsNullOrEmpty(parameters.Value))
            {
                tp = tp.Where(t => t.Value.ToLower() == parameters.Value.ToLower());
            }
            
            if (!string.IsNullOrEmpty(parameters.SearchQuery))
            {
                var searchQuery = parameters.SearchQuery.ToLower();
                tp = tp.Where(t => t.Name.ToLower().Contains(searchQuery)
                              || t.Description.ToLower().Contains(searchQuery)
                              || t.Value.ToLower().Contains(searchQuery)
                              );
            }

            return PagedList<DocumentTypeResolver>.Create(tp, parameters.PageNumber, parameters.PageSize);
        }



    }
}