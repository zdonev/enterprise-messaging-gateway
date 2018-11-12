using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using EnterpriseMessagingGateway.Core.SharedKernel;

namespace EnterpriseMessagingGateway.Core.Entities
{
    [Serializable]
    public class DocumentType : BaseEntity
    {
        public DocumentType()
        {
            ResolverList = new List<DocumentTypeResolver>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DocType { get; set; } //ICSM, EDI X12, etc..
        //public string TransactionType { get; set; } //ICSMPO, 850, OrderRequest etc...
        public string Channel { get; set; }
        public string AgreementResolutionMap { get; set; }
       

        [XmlIgnore]
        public virtual ICollection<Agreement> Agreements { get; set; }
        [XmlIgnore]
        public virtual ICollection<DocumentTypeResolver> ResolverList { get; set; }

    }
}
