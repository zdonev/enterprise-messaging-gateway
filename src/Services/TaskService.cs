using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnterpriseMessagingGateway.Services.Interfaces;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using Serilog;

namespace EnterpriseMessagingGateway.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<Task> _taskRepository;
        private readonly IReadRepository<Task> _taskReadRepository;
        private readonly ILogger _log = Log.ForContext<TaskService>();

        public TaskService(IRepository<Task> taskRepository
                             , IReadRepository<Task> taskReadRepository)
        {
            _taskRepository = taskRepository;
            _taskReadRepository = taskReadRepository;
        }
        public TaskDetailDto AddTask(TaskDetailCreateDto dto)
        {
            var entity = AutoMapper.Mapper.Map<Task>(dto);

            var newTask = _taskRepository.Add(entity);

            return AutoMapper.Mapper.Map<TaskDetailDto>(newTask);
        }

        public void DeleteTask(int id)
        {
            var entity = _taskRepository.GetById(id);
            _taskRepository.Delete(entity);
        }

        public TaskDetailDto GetTaskById(int id)
        {
            var entity = _taskRepository.GetById(id);
            return AutoMapper.Mapper.Map<TaskDetailDto>(entity);
        }

        public IEnumerable<TaskDetailDto> GetTaskList(string search = null, string sortOrder = null, int? skip = null, int? take = null)
        {

            throw new NotImplementedException();
            //return  _taskRepository.List(s => s.Name.Contains(search) || search == null,
            //                     null,
            //                     "",
            //                     skip,
            //                     take).ToDTOList();

        }

        public void UpdateTask(TaskDetailDto dto)
        {
            throw new NotImplementedException();
            //var task = dto.ToEntity();
            //_taskRepository.Update(task);
        }
    }
}
