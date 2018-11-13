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
        TaskDetailDto UpdateTask(TaskDetailDto dto);
        void DeleteTask(int id);
    }
}
