using System;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    [Serializable]
    public class AgreementTaskParameter : BaseEntity
    {
        public string Value { get; set; }

        public virtual AgreementTask AgreementTask { get; set; }
        public virtual TaskParameter TaskParameter { get; set; }
    }
}
