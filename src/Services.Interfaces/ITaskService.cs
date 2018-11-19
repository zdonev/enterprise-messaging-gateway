using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;

namespace EnterpriseMessagingGateway.Services.Interfaces
{
    public interface ITaskService
    {
        TaskDetailDto GetTaskById(int id);                        
        TaskDetailDto AddTask(TaskDetailCreateDto dto);
        TaskDto UpdateTask(TaskDto dto);
        void DeleteTask(int id);

        TaskPropertyDto AddProperty(int taskid, TaskPropertyCreateDto dto);
        TaskPropertyDto GetProperty(int taskid, int id);
        TaskPropertyDto UpdateProperty(int taskid, TaskPropertyDto dto);
        void DeleteProperty(int taskid, int id);

        TaskParameterDto AddParameter(int taskid, TaskParameterCreateDto dto);
        TaskParameterDto GetParameter(int taskid, int id);
        TaskParameterDto UpdateParameter(int taskid, TaskParameterDto dto);
        void DeleteParameter(int taskid, int id);
    }
}
