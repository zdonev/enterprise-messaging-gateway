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

namespace EnterpriseMessagingGateway.Api.Controllers
{
    [Route("api/tasks")]
    public class TaskController : ApiController
    {
        private readonly ITaskService _taskService;
        private readonly ILogger _log = Log.ForContext<TaskController>();

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        [Route("api/tasks")]
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
        [Route("api/tasks/{id}")]
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

        //[HttpGet]
        //[Route("api/tasks", Name = "GetTasks")]        
        //[ResponseType(typeof(IEnumerable<TaskDetailDto>))]
        //public IHttpActionResult GetTask([FromUri] TaskResourceParameters parameters)
        //{
        //    try
        //    {
        //        var tasks = _taskReadRepository.List()
        //            .OrderBy(t => t.Name).AsQueryable();

        //        if (!string.IsNullOrEmpty(parameters.Name))
        //        {
        //            tasks = tasks.Where(t => t.Name.ToLower() == parameters.Name.ToLower());
        //        }

        //        if (!string.IsNullOrEmpty(parameters.SearchQuery))
        //        {
        //            var searchQuery = parameters.SearchQuery.ToLower();
        //            tasks = tasks.Where(t => t.Name.ToLower().Contains(searchQuery)
        //                                     || t.Description.ToLower().Contains(searchQuery));
        //        }


        //        var pagedList = PagedList<Task>.Create(tasks, parameters.PageNumber, parameters.PageSize);

        //        if (tasks == null)
        //        {
        //            return NotFound();
        //        }

        //        var previousPageLink = pagedList.HasPrevious ?
        //                                CreateTaskResourceUri(parameters,
        //                                ResourceUriType.PreviousPage) : null;

        //        var nextPageLink = pagedList.HasNext ?
        //                            CreateTaskResourceUri(parameters,
        //                            ResourceUriType.NextPage) : null;               

        //        var taskDto = AutoMapper.Mapper.Map<IEnumerable<TaskDetailDto>>(pagedList);

        //        var response = Request.CreateResponse(HttpStatusCode.OK, taskDto);
        //        response.Headers.Add("X-Pagination-PageNumber", pagedList.CurrentPage.ToString());
        //        response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(pagedList.MetaData(previousPageLink, nextPageLink)));
        //        return ResponseMessage(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        //LOG
        //        //return StatusCode(HttpStatusCode.InternalServerError);
        //        return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

        //    }

        //}


        //[HttpPut]
        //[Route("api/tasks")]
        //[ResponseType(typeof(TaskDetailDto))]
        //public IHttpActionResult UpdateTask([FromBody] TaskDetailDto task)
        //{
        //    try
        //    {
        //        var taskExists = _taskRepository.GetById(task.Id);

        //        if (taskExists == null)
        //        {
        //            return NotFound();
        //        }

        //        var taskEntity = AutoMapper.Mapper.Map<Task>(task);
        //         _taskRepository.Update(taskEntity);

        //        var taskUpdated = _taskRepository.GetById(task.Id);

        //        return Ok(AutoMapper.Mapper.Map<TaskDetailDto>(taskUpdated));
        //    }
        //    catch (Exception ex)
        //    {
        //        //LOG
        //        //return StatusCode(HttpStatusCode.InternalServerError);
        //        return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

        //    }

        //}

        //[HttpDelete]
        //[Route("api/tasks/{id}")]
        //public IHttpActionResult DeleteTask(int id)
        //{
        //    try
        //    {
        //        var task = _taskRepository.GetById(id);

        //        if (task == null)
        //        {
        //            return NotFound();
        //        }
        //         _taskRepository.Delete(task);

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        //LOG
        //        //return StatusCode(HttpStatusCode.InternalServerError);
        //        return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

        //    }

        //}

        //private string CreateTaskResourceUri(
        //    TaskResourceParameters taskResourceParameters,
        //    ResourceUriType type)
        //{

        //    var _urlHelper = new UrlHelper(Request);

        //    switch (type)
        //    {
        //        case ResourceUriType.PreviousPage:
        //            return Url.Link("GetTasks",
        //              new
        //              {
        //                  searchQuery = taskResourceParameters.SearchQuery,
        //                  name = taskResourceParameters.Name,
        //                  pageNumber = taskResourceParameters.PageNumber - 1,
        //                  pageSize = taskResourceParameters.PageSize
        //              });
        //        case ResourceUriType.NextPage:
        //            return Url.Link("GetTasks",
        //              new
        //              {
        //                  searchQuery = taskResourceParameters.SearchQuery,
        //                  name = taskResourceParameters.Name,
        //                  pageNumber = taskResourceParameters.PageNumber + 1,
        //                  pageSize = taskResourceParameters.PageSize
        //              });

        //        default:
        //            return Url.Link("GetTasks",
        //            new
        //            {
        //                searchQuery = taskResourceParameters.SearchQuery,
        //                name = taskResourceParameters.Name,
        //                pageNumber = taskResourceParameters.PageNumber,
        //                pageSize = taskResourceParameters.PageSize
        //            });
        //    }
        //}
    }
}
