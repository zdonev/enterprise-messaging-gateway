using System;
using System.Collections.Generic;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    [Serializable]
    public class TaskParameter : BaseEntity
    {
        public string Key { get; set; }
        public bool Required { get; set; }

        public string Description { get; set; }
        public ParameterType Type { get; set; }

        public virtual Task Task { get; set; }
        public virtual ICollection<AgreementTaskParameter> AgreementTaskParameters { get; set; }
    }
}

public enum ParameterType
{
    Number,
    Text,
    Date,
    Bool
}
