using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Core.Interfaces;
using EnterpriseMessagingGateway.Services.Interfaces;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;
using EnterpriseMessagingGateway.Services.Helpers;

namespace EnterpriseMessagingGateway.Api.Controllers
{
    [RoutePrefix("api/tasks/{taskid}/parameters")]
    public class TaskParameterController : ApiController
    {
        private readonly IReadRepository<TaskParameter> _readRepository;
        private readonly ITaskService _taskService;
        private readonly ILogger _log = Log.ForContext<TaskParameterController>();


        public TaskParameterController(IReadRepository<TaskParameter> readRepository,
                               ITaskService taskService)
        {
            _readRepository = readRepository;
            _taskService = taskService;
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(TaskParameterDto))]
        public IHttpActionResult Create(int taskid, [FromBody] TaskParameterCreateDto property)
        {
            if (property == null)
            {
                return BadRequest("Invalid Property Object!");
            }                        

            return Ok(_taskService.AddParameter(taskid, property));
        }


        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(TaskParameterDto))]
        public IHttpActionResult Get(int taskid, int id)
        {
            try
            {
                var entity = _taskService.GetParameter(taskid, id);

                if (entity == null)
                {
                    return NotFound();
                }
                _log.Information("Received Record {0}", id);
                var dto = AutoMapper.Mapper.Map<TaskParameterDto>(entity);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

            }
        }


        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<TaskParameterDto>))]
        public IHttpActionResult GetParameters(int taskid, [FromUri] PropertyResourceParameters parameters)
        {
            try
            {
                parameters = parameters ?? new PropertyResourceParameters();
                IEnumerable<TaskParameter> entities;

                if (!string.IsNullOrEmpty(parameters.SearchQuery))
                {
                    var searchQuery = parameters.SearchQuery.ToLower();
                    entities = _readRepository.List(p => (p.Key.ToLower().Contains(searchQuery))
                                                && p.Task.Id == taskid
                                                , q => q.OrderBy(e => e.Key), "", parameters.PageNumber - 1, parameters.PageSize).ToList();
                }
                else
                {
                    entities = _readRepository.List(p => p.Task.Id == taskid
                                                , q => q.OrderBy(e => e.Key), "", parameters.PageNumber - 1, parameters.PageSize).ToList();
                }

                if (entities == null)
                {
                    return NotFound();
                }
                var propertyList = AutoMapper.Mapper.Map<IEnumerable<TaskParameterDto>>(entities);


                return Ok(propertyList);
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

            }

        }


        [HttpPut]
        [Route("")]
        [ResponseType(typeof(TaskParameterDto))]
        public IHttpActionResult Update(int taskid, [FromBody] TaskParameterDto dto)
        {
            try
            {
                var entity = _taskService.GetParameter(taskid, dto.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(_taskService.UpdateParameter(taskid, dto));
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteProperty(int taskid, int id)
        {
            try
            {
                var entity = _taskService.GetParameter(taskid, id);

                if (entity == null)
                {
                    return NotFound();
                }

                _taskService.DeleteParameter(taskid, id);                

                return Ok();
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

            }

        }
    }
}
