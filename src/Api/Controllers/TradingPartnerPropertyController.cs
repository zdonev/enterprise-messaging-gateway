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
    [RoutePrefix("api/tradingpartners")]
    public class TradingPartnerPropertyController : ApiController
    {
        private readonly IRepository<TradingPartnerProperty> _repository;
        private readonly ITradingPartnerService _tpService;
        private readonly ILogger _log = Log.ForContext<TradingPartnerContactProperty>();


        public TradingPartnerPropertyController(IRepository<TradingPartnerProperty> repository,
                               ITradingPartnerService tpService)
        {
            _repository = repository;
            _tpService = tpService;
        }

        [HttpPost]
        [Route("{tpid}/properties")]
        [ResponseType(typeof(TradingPartnerPropertyDto))]
        public IHttpActionResult Create(int tpid, [FromBody] TradingPartnerPropertyCreateDto property)
        {
            if (property == null)
            {
                return BadRequest("Invalid Property Object!");
            }                        

            return Ok(_tpService.AddProperty(tpid, property));
        }


        [HttpGet]
        [Route("{tpid}/properties/{id}")]
        [ResponseType(typeof(TradingPartnerPropertyDto))]
        public IHttpActionResult Get(int tpid, int id)
        {
            try
            {
                var entity = _tpService.GetProperty(tpid, id);

                if (entity == null)
                {
                    return NotFound();
                }
                _log.Information("Received Record {0}", id);
                var dto = AutoMapper.Mapper.Map<TradingPartnerPropertyDto>(entity);
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
        [Route("{tpid}/properties")]
        [ResponseType(typeof(IEnumerable<TradingPartnerPropertyDto>))]
        public IHttpActionResult GetProperties(int tpid, [FromUri] PropertyResourceParameters parameters)
        {
            try
            {
                parameters = parameters ?? new PropertyResourceParameters();
                IEnumerable<TradingPartnerProperty> entities;

                if (!string.IsNullOrEmpty(parameters.SearchQuery))
                {
                    var searchQuery = parameters.SearchQuery.ToLower();
                    entities = _repository.List(p => (p.Name.ToLower().Contains(searchQuery)
                                                || p.Value.ToLower().Contains(searchQuery))
                                                && p.TradingPartner.Id == tpid
                                                , q => q.OrderBy(e => e.Name), "", parameters.PageNumber - 1, parameters.PageSize).ToList();
                }
                else
                {
                    entities = _repository.List(p => p.TradingPartner.Id == tpid
                                                , q => q.OrderBy(e => e.Name), "", parameters.PageNumber - 1, parameters.PageSize).ToList();
                }

                if (entities == null)
                {
                    return NotFound();
                }
                var propertyList = AutoMapper.Mapper.Map<IEnumerable<TradingPartnerContactPropertyDto>>(entities);


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
        [Route("{tpid}/properties")]
        [ResponseType(typeof(TradingPartnerPropertyDto))]
        public IHttpActionResult UpdateProperty(int tpid, [FromBody] TradingPartnerPropertyDto dto)
        {
            try
            {
                var entity = _tpService.GetProperty(tpid, dto.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(_tpService.UpdateProperty(tpid, dto));
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));
            }
        }

        [HttpDelete]
        [Route("{tpid}/properties/{id}")]
        public IHttpActionResult DeleteProperty(int tpid, int id)
        {
            try
            {
                var entity = _tpService.GetProperty(tpid, id);

                if (entity == null)
                {
                    return NotFound();
                }

                _tpService.DeleteProperty(tpid, id);                

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
