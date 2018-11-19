using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnterpriseMessagingGateway.Services.Interfaces;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using Serilog;
using EnterpriseMessagingGateway.Services.Helpers;

namespace EnterpriseMessagingGateway.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<Task> _taskRepository;
        private readonly IRepository<TaskProperty> _taskPropertyRepository;
        private readonly IRepository<TaskParameter> _taskParameterRepository;
        private readonly IReadRepository<Task> _taskReadRepository;
        private readonly ILogger _log = Log.ForContext<TaskService>();

        public TaskService(IRepository<Task> taskRepository,
                             IReadRepository<Task> taskReadRepository,
                             IRepository<TaskProperty> taskPropertyRepository,
                             IRepository<TaskParameter> taskParameterRepository)
        {
            _taskRepository = taskRepository;
            _taskReadRepository = taskReadRepository;
            _taskPropertyRepository = taskPropertyRepository;
            _taskParameterRepository = taskParameterRepository;
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


        public TaskDto UpdateTask(TaskDto dto)
        {
            var entity = AutoMapper.Mapper.Map<Task>(dto);
            _taskRepository.Update(entity);

            var updatedEntity = _taskRepository.GetById(entity.Id);

            return AutoMapper.Mapper.Map<TaskDto>(updatedEntity);
        }

        public TaskPropertyDto AddProperty(int taskid, TaskPropertyCreateDto dto)
        {
            var entity = AutoMapper.Mapper.Map<TaskProperty>(dto);

            var task = _taskRepository.GetById(taskid);
            entity.Task = task;
            _taskPropertyRepository.Add(entity);

            return AutoMapper.Mapper.Map<TaskPropertyDto>(entity);
        }

        public TaskPropertyDto GetProperty(int taskid, int id)
        {
            var entity = _taskPropertyRepository.GetById(id);
            return AutoMapper.Mapper.Map<TaskPropertyDto>(entity);
        }

        public TaskPropertyDto UpdateProperty(int taskid, TaskPropertyDto dto)
        {
            var entity = AutoMapper.Mapper.Map<TaskProperty>(dto);

            _taskPropertyRepository.Update(entity);

            return AutoMapper.Mapper.Map<TaskPropertyDto>(entity);
        }

        public void DeleteProperty(int taskid, int id)
        {
            var entity = _taskPropertyRepository.GetById(id);
            _taskPropertyRepository.Delete(entity);
        }

        public TaskParameterDto AddParameter(int taskid, TaskParameterCreateDto dto)
        {
            var entity = AutoMapper.Mapper.Map<TaskParameter>(dto);

            var task = _taskRepository.GetById(taskid);
            entity.Task = task;
            _taskParameterRepository.Add(entity);

            return AutoMapper.Mapper.Map<TaskParameterDto>(entity);
        }

        public TaskParameterDto GetParameter(int taskid, int id)
        {
            var entity = _taskParameterRepository.GetById(id);
            return AutoMapper.Mapper.Map<TaskParameterDto>(entity);
        }

        public TaskParameterDto UpdateParameter(int taskid, TaskParameterDto dto)
        {
            var entity = AutoMapper.Mapper.Map<TaskParameter>(dto);

            _taskParameterRepository.Update(entity);

            return AutoMapper.Mapper.Map<TaskParameterDto>(entity);
        }

        public void DeleteParameter(int taskid, int id)
        {
            var entity = _taskParameterRepository.GetById(id);
            _taskParameterRepository.Delete(entity);
        }
    }
}
