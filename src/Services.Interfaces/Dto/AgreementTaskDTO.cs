using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMessagingGateway.Services.Interfaces.Dto
{
    public class AgreementTaskDto
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public bool IsEnabled { get; set; }
        public bool TrackingOn { get; set; }
        public bool ArchivingOn { get; set; }

        public string TaskName { get; set; }
        public ICollection<AgreementTaskParameterDto> AgreementTaskParameters { get; set; }
    }
}
