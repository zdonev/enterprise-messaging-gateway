using System;
using System.Collections.Generic;

namespace EnterpriseMessagingGateway.Services.Interfaces
{
    public interface IPropertyMappingService
    {
        bool ValidMappingExistsFor<TSource, TDestination>(string fields);

        Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>();
    }
}
