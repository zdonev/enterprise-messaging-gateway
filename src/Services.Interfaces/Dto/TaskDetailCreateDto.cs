using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMessagingGateway.Services.Interfaces.Dto
{
    public class TaskDetailCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool GlobalTracking { get; set; }
        public bool GlobalArchiving { get; set; }
        public string Type { get; set; }

        public ICollection<TaskParameterCreateDto> TaskParameters { get; set; } = new List<TaskParameterCreateDto>();
        public ICollection<TaskPropertyCreateDto> Properties { get; set; } = new List<TaskPropertyCreateDto>();
    }
}
