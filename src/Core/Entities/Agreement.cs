using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    [Serializable]
    public class Agreement : BaseEntity 
    {
        public Agreement()
        {
            PropertyList = new List<AgreementProperty>();
            ResolverList = new List<AgreementResolvers>();
            Logs = new List<AgreementLog>();
            TaskList = new List<AgreementTask>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string AgreementHash { get; set; }        
        public bool IsEnabled { get; set; }
        public bool CheckForDuplicate { get; set; }

        public virtual DocumentType DocumentType { get; set; }
        public virtual TradingPartner Sender { get; set; }
        public virtual TradingPartner Receiver { get; set; }
        [XmlIgnore]
        public virtual ICollection<AgreementProperty> PropertyList { get; set; }        
        [XmlIgnore] 
        public virtual ICollection<AgreementLog> Logs { get; set; }
        [XmlIgnore]
        public virtual ICollection<AgreementTask> TaskList { get; set; }  
        [XmlIgnore]
        public virtual ICollection<AgreementResolvers> ResolverList { get; set; }
    }
}
