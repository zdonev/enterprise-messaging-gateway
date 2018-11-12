using EnterpriseMessagingGateway.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace EnterpriseMessagingGateway.Core.Entities
{
    [Serializable]
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool GlobalTracking { get; set; }
        public bool GlobalArchiving { get; set; }

        public TaskType Type { get; set; }

        public virtual ICollection<AgreementTask> AgreementTasks { get; set; }

        public virtual ICollection<TaskParameter> TaskParameters { get; set; }

        public virtual ICollection<TaskProperty> Properties { get; set; }
    }
}

public enum TaskType
{
    Internal,
    External
}
