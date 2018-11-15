using EnterpriseMessagingGateway.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseMessagingGateway.Api.Extensions
{
    public static class ResourceUriTypeExtensions
    {
        public static int GetPageAdjustment(this ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return -1;
                case ResourceUriType.NextPage:
                    return 1;
                default:
                    return 0;
            }
        }

    }
}