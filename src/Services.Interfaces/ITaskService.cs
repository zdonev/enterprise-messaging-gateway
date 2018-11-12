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

        IEnumerable<TaskDetailDto> GetTaskList(string search = null, string sortOrder = null, int? skip = null, int? take = null);
        //TaskDetailDTO GetAgreementDetailById(int id);
        TaskDetailDto AddTask(TaskDetailCreateDto dto);
        void UpdateTask(TaskDetailDto dto);
        void DeleteTask(int id);
    }
}
