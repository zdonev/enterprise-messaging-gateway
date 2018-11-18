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
    public class TradingPartnerContactPropertyController : ApiController
    {
        private readonly IRepository<TradingPartnerContactProperty> _repository;
        private readonly ITradingPartnerService _tpService;
        private readonly ILogger _log = Log.ForContext<TradingPartnerContactProperty>();


        public TradingPartnerContactPropertyController(IRepository<TradingPartnerContactProperty> repository,
                               ITradingPartnerService tpService)
        {
            _repository = repository;
            _tpService = tpService;
        }

        [HttpPost]
        [Route("{tpid}/contacts/{contactid}/properties")]
        [ResponseType(typeof(TradingPartnerContactPropertyCreateDto))]
        public IHttpActionResult CreateContactProperty(int tpid, int contactid, [FromBody] TradingPartnerContactPropertyCreateDto property)
        {
            if (property == null)
            {
                return BadRequest("Invalid Property Object!");
            }                        

            return Ok(_tpService.AddContactProperty(tpid, contactid, property));
        }


        [HttpGet]
        [Route("{tpid}/contacts/{contactid}/properties/{id}")]
        [ResponseType(typeof(TradingPartnerContactPropertyDto))]
        public IHttpActionResult GetContactProperty(int tpid, int contactid, int id)
        {
            try
            {
                var entity = _tpService.GetContactProperty(tpid, contactid, id);

                if (entity == null)
                {
                    return NotFound();
                }
                _log.Information("Received Record {0}", id);
                var dto = AutoMapper.Mapper.Map<TradingPartnerContactPropertyDto>(entity);
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
        [Route("{tpid}/contacts/{contactid}/properties")]
        [ResponseType(typeof(IEnumerable<TradingPartnerContactPropertyDto>))]
        public IHttpActionResult GetProperties(int tpid, int contactid, [FromUri] PropertyResourceParameters parameters)
        {
            try
            {
                parameters = parameters ?? new PropertyResourceParameters();
                IEnumerable<TradingPartnerContactProperty> entities;

                if (!string.IsNullOrEmpty(parameters.SearchQuery))
                {
                    var searchQuery = parameters.SearchQuery.ToLower();
                    entities = _repository.List(p => (p.Name.ToLower().Contains(searchQuery)
                                                || p.Value.ToLower().Contains(searchQuery))
                                                && p.Contact.Id == contactid
                                                , q => q.OrderBy(e => e.Name), "", parameters.PageNumber - 1, parameters.PageSize).ToList();
                }
                else
                {
                    entities = _repository.List(p => p.Contact.Id == contactid
                                                , q => q.OrderBy(e => e.Name), "", parameters.PageNumber - 1, parameters.PageSize).ToList();
                }

                if (entities == null)
                {
                    return NotFound();
                }
                var contactsDto = AutoMapper.Mapper.Map<IEnumerable<TradingPartnerContactPropertyDto>>(entities);


                return Ok(contactsDto);
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));

            }

        }


        [HttpPut]
        [Route("{tpid}/contacts/{contactid}/properties")]
        [ResponseType(typeof(IEnumerable<TradingPartnerContactPropertyDto>))]
        public IHttpActionResult UpdateProperty(int tpid, int contactid, [FromBody] TradingPartnerContactPropertyDto dto)
        {
            try
            {
                var entity = _tpService.GetContactProperty(tpid, contactid, dto.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                var updatedEntity = _tpService.UpdateContactProperty(tpid, contactid, dto);

                return Ok(AutoMapper.Mapper.Map<TradingPartnerContactPropertyDto>(updatedEntity));
            }
            catch (Exception ex)
            {
                //LOG
                //return StatusCode(HttpStatusCode.InternalServerError);
                return InternalServerError(new Exception("An unexpected error occured! Please try again later!"));
            }
        }

        [HttpDelete]
        [Route("{tpid}/contacts/{contactid}/properties/{id}")]
        public IHttpActionResult DeleteProperty(int tpid, int contactid, int id)
        {
            try
            {
                var entity = _tpService.GetContactProperty(tpid, contactid, id);

                if (entity == null)
                {
                    return NotFound();
                }

                _tpService.DeleteContactProperty(tpid, contactid, id);                

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
