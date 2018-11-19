using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseMessagingGateway.Services.Helpers
{
    public class ResolverResourceParameters : BaseResourceParameters
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string OrderBy { get; set; } = "Name";
    }
}