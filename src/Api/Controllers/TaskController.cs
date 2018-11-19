using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EnterpriseMessagingGateway.Core.Interfaces;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;
using EnterpriseMessagingGateway.Infrastructure.Repositories;
using EnterpriseMessagingGateway.Infrastructure;
using Serilog;
//using EnterpriseMessagingGateway.Api.Helpers;
using System.Web.Http.Routing;
using System.Web.Http.Description;
using EnterpriseMessagingGateway.Services.Interfaces;
using EnterpriseMessagingGateway.Services.Helpers;
using EnterpriseMessagingGateway.Api.Extensions;

namespace EnterpriseMessagingGateway.Api.Controllers
{
    [RoutePrefix("api/tasks")]
    public class TaskController : ApiController
    {
        private readonly ITaskService _taskService;
        private readonly IReadRepository<Task> _taskReadRepository;
        private readonly ILogger _log = Log.ForContext<TaskController>();

        public TaskController(ITaskService taskService,
                                IReadRepository<Task> taskReadRepository)
        {
            _taskService = taskService;
            _taskReadRepository = taskReadRepository;
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(TaskDetailDto))]
        public IHttpActionResult CreateTask(TaskDetailCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Test");
            }


            return Ok(_taskService.AddTask(dto));

            
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(TaskDetailDto))]
        public IHttpActionResult GetTask(int id)
        {
            try
            {
                var task = _taskService.GetTaskById(id);

                if (task == null)
                {
                    return NotFound();
                }
                _log.Information("Received Record {0}", id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

            }

        }

        [HttpGet]
        [Route("", Name = "GetTasks")]
        [ResponseType(typeof(IEnumerable<TaskDetailDto>))]
        public IHttpActionResult GetTasks([FromUri] TaskResourceParameters parameters)
        {
            try
            {

                var pagedList = _taskReadRepository.ToPagedList(parameters);
                    

                var previousPageLink = pagedList.HasPrevious ?
                                        CreateTaskResourceUri(parameters,
                                        ResourceUriType.PreviousPage) : null;

                var nextPageLink = pagedList.HasNext ?
                                    CreateTaskResourceUri(parameters,
                                    ResourceUriType.NextPage) : null;

                var taskDto = AutoMapper.Mapper.Map<IEnumerable<TaskDetailDto>>(pagedList);

                var response = Request.CreateResponse(HttpStatusCode.OK, taskDto);
                response.Headers.Add("X-Pagination-PageNumber", pagedList.CurrentPage.ToString());
                response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(pagedList.MetaData(previousPageLink, nextPageLink)));
                return ResponseMessage(response);
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
        [ResponseType(typeof(TaskDto))]
        public IHttpActionResult UpdateTask([FromBody] TaskDto dto)
        {
            try
            {
                var taskExists = _taskService.GetTaskById(dto.Id);

                if (taskExists == null)
                {
                    return NotFound();
                }

                return Ok(_taskService.UpdateTask(dto));
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
        public IHttpActionResult DeleteTask(int id)
        {
            try
            {
                var entity = _taskService.GetTaskById(id);

                if (entity == null)
                {
                    return NotFound();
                }
                _taskService.DeleteTask(id);

                return Ok();
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

            }

        }

        private string CreateTaskResourceUri(
            TaskResourceParameters parameters,
            ResourceUriType type)
        {

            var _urlHelper = new UrlHelper(Request);

            int pageAdjustment = type.GetPageAdjustment();

            return Url.Link("GetTasks",
                    new
                    {
                        searchQuery = parameters.SearchQuery,
                        name = parameters.Name,
                        pageNumber = parameters.PageNumber + pageAdjustment,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy
                    });
        }

    }
}
