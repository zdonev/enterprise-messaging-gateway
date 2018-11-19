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
    [RoutePrefix("api/tradingpartners/{tpid}/identifiers")]
    public class TradingPartnerIdentifierController : ApiController
    {
        private readonly IReadRepository<TradingPartnerIdentifier> _readRepository;
        private readonly ITradingPartnerService _tpService;
        private readonly ILogger _log = Log.ForContext<TradingPartnerContactProperty>();


        public TradingPartnerIdentifierController(IReadRepository<TradingPartnerIdentifier> readRepository,
                               ITradingPartnerService tpService)
        {
            _readRepository = readRepository;
            _tpService = tpService;
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(TradingPartnerIdentifierDto))]
        public IHttpActionResult Create(int tpid, [FromBody] TradingPartnerIdentifierCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid Property Object!");
            }                        

            return Ok(_tpService.AddIdentifier(tpid, dto));
        }


        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(TradingPartnerIdentifierDto))]
        public IHttpActionResult Get(int tpid, int id)
        {
            try
            {
                var dto = _tpService.GetIdentifier(tpid, id);

                if (dto == null)
                {
                    return NotFound();
                }
                _log.Information("Received Record {0}", id);
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
        [ResponseType(typeof(IEnumerable<TradingPartnerIdentifierDto>))]
        public IHttpActionResult GetProperties(int tpid, [FromUri] PropertyResourceParameters parameters)
        {
            try
            {
                parameters = parameters ?? new PropertyResourceParameters();
                IEnumerable<TradingPartnerIdentifier> entities;

                if (!string.IsNullOrEmpty(parameters.SearchQuery))
                {
                    var searchQuery = parameters.SearchQuery.ToLower();
                    entities = _readRepository.List(p => (p.Qualifier.ToLower().Contains(searchQuery)
                                                || p.Identifier.ToLower().Contains(searchQuery))
                                                && p.TradingPartner.Id == tpid
                                                , q => q.OrderBy(e => e.Qualifier), "", parameters.PageNumber - 1, parameters.PageSize).ToList();
                }
                else
                {
                    entities = _readRepository.List(p => p.TradingPartner.Id == tpid
                                                , q => q.OrderBy(e => e.Qualifier), "", parameters.PageNumber - 1, parameters.PageSize).ToList();
                }

                if (entities == null)
                {
                    return NotFound();
                }
                var identifierList = AutoMapper.Mapper.Map<IEnumerable<TradingPartnerIdentifierDto>>(entities);


                return Ok(identifierList);
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
        [ResponseType(typeof(TradingPartnerIdentifierDto))]
        public IHttpActionResult UpdateProperty(int tpid, [FromBody] TradingPartnerIdentifierDto dto)
        {
            try
            {
                var entity = _tpService.GetIdentifier(tpid, dto.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(_tpService.UpdateIdentifier(tpid, dto));
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
        public IHttpActionResult DeleteProperty(int tpid, int id)
        {
            try
            {
                var entity = _tpService.GetIdentifier(tpid, id);

                if (entity == null)
                {
                    return NotFound();
                }

                _tpService.DeleteIdentifier(tpid, id);                

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
