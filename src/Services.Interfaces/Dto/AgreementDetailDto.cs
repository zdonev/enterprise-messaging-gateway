using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMessagingGateway.Services.Interfaces.Dto
{
    public class AgreementDetailDto
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public bool CheckForDuplicate { get; set; }

        public string DocumentType { get; set; }
        public string Channel { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public ICollection<AgreementPropertyDto> PropertyList { get; set; }
        //public virtual ICollection<AgreementLog> Logs { get; set; }
        public ICollection<AgreementTaskDto> TaskList { get; set; }
        public ICollection<AgreementResolversDto> ResolverList { get; set; }

    }
}
