using System;
using System.Xml.Serialization;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    [Serializable]
    public class AgreementProperty : BaseEntity
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string PropertyDescription { get; set; }

        [XmlIgnore]
        public virtual Agreement Agreement { get; set; }
    }
}
