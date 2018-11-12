using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMessagingGateway.Services.Interfaces.Dto
{
    public class TaskParameterDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }

        public string Type { get; set; }
    }
}
