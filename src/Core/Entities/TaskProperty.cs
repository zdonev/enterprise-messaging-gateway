using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    public class TaskProperty : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual Task Task { get; set; }
    }
}
