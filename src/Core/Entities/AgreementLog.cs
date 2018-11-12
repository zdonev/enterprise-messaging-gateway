using System;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    [Serializable]
    public class AgreementLog : BaseEntity
    {
        public DateTime Timestamp { get; set; }
        public string User { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
        public string Action { get; set; }

        public virtual Agreement Agreement { get; set; }
    }
}
