using System;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    [Serializable]
    public class MessageArchive : BaseEntity
    {
        public string ActivityId { get; set; }
        public string TaskName { get; set; }
        public int Sequence { get; set; }
        public string Context { get; set; }
        public string Payload { get; set; }       
        public DateTime DateCreated { get; set; }
    }
}
