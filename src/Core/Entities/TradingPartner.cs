using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    public class TradingPartner : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }

        [XmlIgnore]
        public virtual ICollection<TradingPartnerIdentifier> Identifiers { get; set; } = new List<TradingPartnerIdentifier>();
        [XmlIgnore]
        public virtual ICollection<TradingPartnerProperty> Properties { get; set; } = new List<TradingPartnerProperty>();
        [XmlIgnore]
        public virtual ICollection<TradingPartnerContact> Contacts { get; set; } = new List<TradingPartnerContact>();
    }
}
