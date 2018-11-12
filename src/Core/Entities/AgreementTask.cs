using System;
using System.Collections.Generic;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    [Serializable]
    public class AgreementTask : BaseEntity
    {
        public int Sequence { get; set; }
        public bool IsEnabled { get; set; }
        public bool TrackingOn { get; set; }
        public bool ArchivingOn { get; set; }

        public virtual Agreement Agreement { get; set; }
        public virtual Task Task { get; set; }
        public virtual ICollection<AgreementTaskParameter> AgreementTaskParameters { get; set; }
    }
}
