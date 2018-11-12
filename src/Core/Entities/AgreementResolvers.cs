using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    [Serializable]
    public class AgreementResolvers : BaseEntity
    {

        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        [XmlIgnore]
        public virtual Agreement Agreement { get; set; }
    }
}
