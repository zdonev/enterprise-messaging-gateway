using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseMessagingGateway.Services.Helpers
{
    public class TradingPartnerResourceParameters : BaseResourceParameters
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Qualifier { get; set; }
        public string Identifier { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string OrderBy { get; set; } = "Name";

    }
}