using System;
using System.Xml.Serialization;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    [Serializable]
    public class DocumentTypeResolver : BaseEntity
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public LookupType LookupType { get; set; }

        [XmlIgnore]
        public virtual DocumentType DocumentType { get; set; }
    }
}


public enum LookupType
{
    System,
    Custom
}